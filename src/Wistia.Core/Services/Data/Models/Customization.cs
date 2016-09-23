#region License, Terms and Conditions
//
// Customization.cs
//
// Author: Kori Francis <twitter.com/djbyter>
// Copyright (C) 2014 Kori Francis. All rights reserved.
// 
// THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW:
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//
#endregion

namespace Wistia.Core.Services.Data.Models
{
    /// <summary>
    /// The Customize API lets you configure each video in your account with specific customizations. 
    /// These customizations will apply to your video both in your account, and wherever you embed it.
    /// http://wistia.com/doc/data-api#customizations
    /// </summary>
    public class Customization
    {
        public string version { get; set; }
        public string playerColor { get; set; }
        public string stillUrl { get; set; }
        public string autoPlay { get; set; }
        public string endVideoBehavior { get; set; }
        public string playButton { get; set; }
        public string smallPlayButton { get; set; }
        public string volumeControl { get; set; }
        public string fullscreenButton { get; set; }
        public string playbar { get; set; }
        public string controlsVisibleOnLoad { get; set; }
        public string branding { get; set; }
        public Plugin plugin { get; set; }
    }
}
