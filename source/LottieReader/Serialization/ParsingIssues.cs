﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityToolkit.WinUI.Lottie.LottieData.Serialization
{
    /// <summary>
    /// Issues.
    /// </summary>
    sealed class ParsingIssues
    {
        readonly HashSet<(string Code, string Description)> _issues = new HashSet<(string Code, string Description)>();
        readonly bool _throwOnIssue;

        internal ParsingIssues(bool throwOnIssue)
        {
            _throwOnIssue = throwOnIssue;
        }

        internal (string Code, string Description)[] GetIssues() => _issues.ToArray();

        // LP0001 has been deprecated.
        // Was: Failed to parse JSON. {message}.

        internal void FatalError(string message) => Report("LP0002", $"Fatal error: {message}");

        internal void AssetType(string type) => Report("LP0005", $"Unsupported asset type: {type}.");

        internal void LayerWithRenderFalse() => Report("LP0006", "Layer with render = false.");

        internal void IllustratorLayers() => Report("LP0007", "Illustrator layers.");

        internal void LayerEffectsIsNotSupported(string layer, string type) => Report("LP0008", $"{layer} has an unsupported layer effect, type = {type}.");

        // LP0009 has been deprecated.
        // Was: Mattes.

        internal void TimeRemappingOfPreComps() => Report("LP0011", "Time remapping of precomp layers.");

        // LP0012 has been deprecated.
        // Was: Unexpected shape content type: {type}.

        // LP0013 has been deprecated.
        // Was: Gradient strokes.

        // LP0014 has been deprecated.
        // Was: Polystar {property} animation.

        internal void Expressions() => Report("LP0015", "Expressions.");

        // LP0016 has been deprecated.
        // Was: Ignored field: {field}.

        internal void UnexpectedField(string field) => Report("LP0017", $"Unexpected field: {field}.");

        internal void UnexpectedValueForType(string type, string value) => Report("LP0018", $"Unexpected {type} type value: {value}.");

        void Report(string code, string description)
        {
            _issues.Add((code, description));

            if (_throwOnIssue)
            {
                throw new NotSupportedException($"{code}: {description}");
            }
        }
    }
}
