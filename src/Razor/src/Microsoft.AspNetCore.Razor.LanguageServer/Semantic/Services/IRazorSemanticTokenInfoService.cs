﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.AspNetCore.Razor.LanguageServer.Semantic;

internal interface IRazorSemanticTokensInfoService
{
    Task<int[]?> GetSemanticTokensAsync(VersionedDocumentContext documentContext, LinePositionSpan range, bool colorBackground, Guid correlationId, CancellationToken cancellationToken);
}
