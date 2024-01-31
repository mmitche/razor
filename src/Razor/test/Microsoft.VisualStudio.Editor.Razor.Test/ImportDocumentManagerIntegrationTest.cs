﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System.IO;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Test.Common;
using Microsoft.AspNetCore.Razor.Test.Common.Editor;
using Microsoft.CodeAnalysis.Razor.ProjectSystem;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.VisualStudio.Editor.Razor.Documents;

public class ImportDocumentManagerIntegrationTest : ProjectSnapshotManagerDispatcherTestBase
{
    private readonly string _directoryPath;
    private readonly string _projectPath;
    private readonly RazorProjectFileSystem _fileSystem;
    private readonly RazorProjectEngine _projectEngine;

    public ImportDocumentManagerIntegrationTest(ITestOutputHelper testOutput)
        : base(testOutput)
    {
        _projectPath = TestProjectData.SomeProject.FilePath;
        _directoryPath = Path.GetDirectoryName(_projectPath);

        _fileSystem = RazorProjectFileSystem.Create(Path.GetDirectoryName(_projectPath));

        // These tests rely on MVC's import behavior.
        _projectEngine = RazorProjectEngine.Create(
            FallbackRazorConfiguration.MVC_2_1,
            _fileSystem,
            AspNetCore.Mvc.Razor.Extensions.RazorExtensions.Register);
    }

    [UIFact]
    public void Changed_TrackerChanged_ResultsInChangedHavingCorrectArgs()
    {
        // Arrange
        var testImportsPath = Path.Combine(_directoryPath, "_ViewImports.cshtml");

        var tracker = Mock.Of<IVisualStudioDocumentTracker>(
            t => t.FilePath == Path.Combine(_directoryPath, "Views", "Home", "_ViewImports.cshtml") &&
            t.ProjectPath == _projectPath &&
            t.ProjectSnapshot == Mock.Of<IProjectSnapshot>(p => p.GetProjectEngine() == _projectEngine && p.GetDocument(It.IsAny<string>()) == null, MockBehavior.Strict), MockBehavior.Strict);

        var anotherTracker = Mock.Of<IVisualStudioDocumentTracker>(
            t => t.FilePath == Path.Combine(_directoryPath, "anotherFile.cshtml") &&
            t.ProjectPath == _projectPath &&
            t.ProjectSnapshot == Mock.Of<IProjectSnapshot>(p => p.GetProjectEngine() == _projectEngine && p.GetDocument(It.IsAny<string>()) == null, MockBehavior.Strict), MockBehavior.Strict);

        var fileChangeTrackerFactory = new Mock<IFileChangeTrackerFactory>(MockBehavior.Strict);
        var fileChangeTracker = new Mock<IFileChangeTracker>(MockBehavior.Strict);
        fileChangeTracker
            .Setup(f => f.FilePath)
            .Returns(testImportsPath);
        fileChangeTracker.Setup(f => f.StartListening()).Verifiable();
        fileChangeTrackerFactory
            .Setup(f => f.Create(testImportsPath))
            .Returns(fileChangeTracker.Object);

        var fileChangeTracker2 = new Mock<IFileChangeTracker>(MockBehavior.Strict);
        fileChangeTracker2.Setup(f => f.StartListening()).Verifiable();
        fileChangeTrackerFactory
            .Setup(f => f.Create(Path.Combine(_directoryPath, "Views", "_ViewImports.cshtml")))
            .Returns(fileChangeTracker2.Object);
        fileChangeTrackerFactory
            .Setup(f => f.Create(Path.Combine(_directoryPath, "Views", "Home", "_ViewImports.cshtml")))
            .Returns(Mock.Of<IFileChangeTracker>(MockBehavior.Strict));

        var called = false;
        var manager = new ImportDocumentManager(Dispatcher, fileChangeTrackerFactory.Object);
        manager.OnSubscribed(tracker);
        manager.OnSubscribed(anotherTracker);
        manager.Changed += (sender, args) =>
        {
            called = true;
            Assert.Same(sender, manager);
            Assert.Equal(testImportsPath, args.FilePath);
            Assert.Equal(FileChangeKind.Changed, args.Kind);
            Assert.Collection(
                args.AssociatedDocuments,
                f => Assert.Equal(Path.Combine(_directoryPath, "Views", "Home", "_ViewImports.cshtml"), f),
                f => Assert.Equal(Path.Combine(_directoryPath, "anotherFile.cshtml"), f));
        };

        // Act
        fileChangeTracker.Raise(t => t.Changed += null, new FileChangeEventArgs(testImportsPath, FileChangeKind.Changed));

        // Assert
        Assert.True(called);
    }
}
