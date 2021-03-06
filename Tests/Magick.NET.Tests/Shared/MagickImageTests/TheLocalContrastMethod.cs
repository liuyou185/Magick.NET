﻿// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Shared
{
    public partial class MagickImageTests
    {
        [TestClass]
        public class TheLocalContrastMethod
        {
            [TestMethod]
            public void ShouldOnlyChangeSpecifiedChannels()
            {
                using (IMagickImage image = new MagickImage("plasma:purple", 100, 100))
                {
                    using (IMagickImage allChannels = image.Clone())
                    {
                        allChannels.LocalContrast(2, new Percentage(50));
                        image.LocalContrast(2, new Percentage(50), Channels.Red);

                        var difference = image.Compare(allChannels, ErrorMetric.RootMeanSquared);
                        Assert.AreNotEqual(0, difference);
                    }
                }
            }
        }
    }
}
