//
// Unit tests for AVVideoCompositionInstruction
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc. All rights reserved.
//

#if !__WATCHOS__

using System;
#if XAMCORE_2_0
using Foundation;
using UIKit;
using AVFoundation;
#else
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.AVFoundation {

	[TestFixture]
	[Preserve (AllMembers = true)]
	[TestFixture]
	public class VideoCompositionInstructionTest {

		[Test]
		public void Defaults ()
		{
			using (var i = new AVVideoCompositionInstruction ()) {
				Assert.Null (i.BackgroundColor, "BackgroundColor");
				Assert.True (i.EnablePostProcessing, "EnablePostProcessing");
				Assert.Null (i.LayerInstructions, "LayerInstructions");
				Assert.True (i.TimeRange.Start.IsInvalid, "TimeRange.Start");
				Assert.True (i.TimeRange.Duration.IsInvalid, "TimeRange.Duration");
			}
		}

		[Test]
		public void Seven ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (7, 0))
				Assert.Inconclusive ("Requires iOS7");

			using (var i = new AVVideoCompositionInstruction ()) {
				Assert.False (i.ContainsTweening, "ContainsTweening");
				Assert.That (i.PassthroughTrackID, Is.EqualTo (0), "PassthroughTrackID");
				Assert.That (i.RequiredSourceTrackIDs.Length, Is.EqualTo (0), "RequiredSourceTrackIDs");
			}
		}
	}
}

#endif // !__WATCHOS__