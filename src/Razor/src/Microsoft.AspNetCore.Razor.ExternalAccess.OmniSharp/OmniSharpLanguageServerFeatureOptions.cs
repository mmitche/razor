﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Razor.LanguageServer;
using Microsoft.CodeAnalysis.Razor.Workspaces;

namespace Microsoft.AspNetCore.Razor.ExternalAccess.OmniSharp;

internal class OmniSharpLanguageServerFeatureOptions
{
    internal LanguageServerFeatureOptions InternalLanguageServerFeatureOptions { get; } = new DefaultLanguageServerFeatureOptions();
}
