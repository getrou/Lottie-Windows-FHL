﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using CommunityToolkit.WinUI.Lottie.WinCompData;

namespace CommunityToolkit.WinUI.Lottie.UIData.CodeGen
{
    /// <summary>
    /// Specifies the configuration of a code generator.
    /// </summary>
#if PUBLIC_UIDataCodeGen
    public
#endif
    sealed class CodegenConfiguration
    {
        public CodegenConfiguration(
            string className,
            IReadOnlyList<string> additionalInterfaces,
            IReadOnlyList<(CompositionObject graphRoot, uint requiredUapVersion)> objectGraphs,
            string nameSpace,
            string rootNamespace,
            IReadOnlyDictionary<Guid, object> sourceMetadata,
            IReadOnlyList<string> toolInfo,
            Version winUIVersion
            )
        {
            ClassName = className;
            AdditionalInterfaces = additionalInterfaces;
            ObjectGraphs = objectGraphs;
            Namespace = nameSpace;
            RootNamespace = rootNamespace;
            SourceMetadata = sourceMetadata;
            ToolInfo = toolInfo;
            WinUIVersion = winUIVersion;
        }

        /// <summary>
        /// The name for the resulting IAnimatedVisualSource implementation.
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// The namespace for the generated code.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// The width of the animated visual.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of the animated visual.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The duration of the animated visual.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Determines whether the code generator should disable optimizations. Setting
        /// it to <c>true</c> may make the generated code easier to modify, although
        /// less efficient.
        /// </summary>
        public bool DisableOptimization { get; set; }

        /// <summary>
        /// When <c>true</c>, the generated IAnimatedVisualSource implementation will
        /// be a subclass of DependencyObject, and any theme properties will be
        /// implemented as DependencyPropertys.
        /// </summary>
        public bool GenerateDependencyObject { get; set; }

        /// <summary>
        /// 0 or more additional interfaces that the generated class will claim
        /// to implement.
        /// </summary>
        public IReadOnlyList<string> AdditionalInterfaces { get; }

        /// <summary>
        /// The object graphs for which source will be generated.
        /// </summary>
        public IReadOnlyList<(CompositionObject graphRoot, uint requiredUapVersion)> ObjectGraphs { get; }

        /// <summary>
        /// The root namespace for the project that will consume the generated code.
        /// This affects the names used to reference files generated by cppwinrt.exe.
        /// </summary>
        public string RootNamespace { get; }

        /// <summary>
        /// Information about the source.
        /// </summary>
        public IReadOnlyDictionary<Guid, object> SourceMetadata { get; }

        /// <summary>
        /// Information about the tool that initiated the code generation.
        /// This information will be included in comments in the generated source.
        /// </summary>
        public IReadOnlyList<string> ToolInfo { get; }

        /// <summary>
        /// When <c>true</c> the generated class is made public.
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// The version of WinUI to target.
        /// </summary>
        public Version WinUIVersion { get; set; }

        public bool ImplementCreateAndDestroyMethods => WinUIVersion >= Version.Parse("2.7");
    }
}
