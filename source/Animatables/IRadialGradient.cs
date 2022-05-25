// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommunityToolkit.WinUI.Lottie.Animatables
{
#if PUBLIC_Animatables
    public
#endif
    interface IRadialGradient : IGradient
    {
        Animatable<double> HighlightLength { get; }

        Animatable<double> HighlightDegrees { get; }
    }
}
