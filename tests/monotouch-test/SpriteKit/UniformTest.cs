﻿#if !__WATCHOS__

using System;
#if XAMCORE_2_0
using Foundation;
using SpriteKit;
using UIKit;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
#endif
using OpenTK;
using NUnit.Framework;

namespace MonoTouchFixtures.SpriteKit
{
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class UniformTest
	{
		[TestFixtureSetUp]
		public void Setup ()
		{
			TestRuntime.AssertXcodeVersion (8, 0);

			if (Runtime.Arch == Arch.SIMULATOR && IntPtr.Size == 4) {
				// There's a bug in the i386 version of objc_msgSend where it doesn't preserve SIMD arguments
				// when resizing the cache of method selectors for a type. So here we call all selectors we can
				// find, so that the subsequent tests don't end up producing any cache resize (radar #21630410).
				object dummy;
				using (var obj = new SKUniform ("name")) {
					dummy = obj.Name;
					dummy = obj.UniformType;
					dummy = obj.TextureValue;
					dummy = obj.FloatValue;
					dummy = obj.FloatVector2Value;
					dummy = obj.FloatVector3Value;
					dummy = obj.FloatVector4Value;
					dummy = obj.FloatMatrix2Value;
					dummy = obj.FloatMatrix3Value;
					dummy = obj.FloatMatrix4Value;
				}
				using (var obj = new SKUniform ("name", SKTexture.FromImageNamed ("basn3p08.png"))) {
				}
				using (var obj = new SKUniform ("name", 1.0f)) {
				}
				using (var obj = new SKUniform ("name", Vector2.Zero)) {
				}
				using (var obj = new SKUniform ("name", Vector3.Zero)) {
				}
				using (var obj = new SKUniform ("name", Vector4.Zero)) {
				}
				using (var obj = new SKUniform ("name", Matrix2.Identity)) {
				}
				using (var obj = new SKUniform ("name", Matrix3.Identity)) {
				}
				using (var obj = new SKUniform ("name", Matrix4.Identity)) {
				}
			}
		}

		[Test]
		public void Ctors ()
		{
			SKTexture texture;
			Vector2 V2;
			Vector3 V3;
			Vector4 V4;
			Matrix2 M2;
			Matrix3 M3;
			Matrix4 M4;

			using (var obj = new SKUniform ("name")) {
				var M4Zero = new Matrix4 (Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);
				Assert.AreEqual ("name", obj.Name, "1 Name");
				Assert.AreEqual (SKUniformType.None, obj.UniformType, "1 UniformType");
				Assert.IsNull (obj.TextureValue, "1 TextureValue");
				Assert.AreEqual (0.0f, obj.FloatValue, "1 FloatValue");
				Asserts.AreEqual (Vector2.Zero, obj.FloatVector2Value, "1 FloatVector2Value");
				Asserts.AreEqual (Vector3.Zero, obj.FloatVector3Value, "1 FloatVector3Value");
				Asserts.AreEqual (Vector4.Zero, obj.FloatVector4Value, "1 FloatVector4Value");
				Asserts.AreEqual (Matrix2.Zero, obj.FloatMatrix2Value, "1 FloatMatrix2Value");
				Asserts.AreEqual (Matrix3.Zero, obj.FloatMatrix3Value, "1 FloatMatrix3Value");
				Asserts.AreEqual (M4Zero, obj.FloatMatrix4Value, "1 FloatMatrix4Value");

				texture = SKTexture.FromImageNamed ("basn3p08.png");
				V2 = new Vector2 (1, 2);
				V3 = new Vector3 (3, 4, 5);
				V4 = new Vector4 (6, 7, 8, 9);
				M2 = new Matrix2 (1, 2, 3, 4);
				M3 = new Matrix3 (1, 2, 3, 4, 5, 6, 7, 8, 9);
				M4 = new Matrix4 (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

				obj.TextureValue = texture;
				Assert.AreEqual (texture, obj.TextureValue, "2 TextureValue");

				obj.FloatValue = 0.5f;
				Assert.AreEqual (0.5f, obj.FloatValue, "2 FloatValue");

				obj.FloatVector2Value = V2;
				Asserts.AreEqual (V2, obj.FloatVector2Value, "2 FloatVector2Value");

				obj.FloatVector3Value = V3;
				Asserts.AreEqual (V3, obj.FloatVector3Value, "2 FloatVector3Value");

				obj.FloatVector4Value = V4;
				Asserts.AreEqual (V4, obj.FloatVector4Value, "2 FloatVector4Value");

				obj.FloatMatrix2Value = M2;
				Asserts.AreEqual (M2, obj.FloatMatrix2Value, "2 FloatMatrix2Value");

				obj.FloatMatrix3Value = M3;
				Asserts.AreEqual (M3, obj.FloatMatrix3Value, "2 FloatMatrix3Value");

				obj.FloatMatrix4Value = M4;
				Asserts.AreEqual (M4, obj.FloatMatrix4Value, "2 FloatMatrix4Value");
			}

			using (var obj = new SKUniform ("name", texture)) {
				Assert.AreEqual (texture, obj.TextureValue, "3 TextureValue");
			}

			using (var obj = new SKUniform ("name", 3.1415f)) {
				Assert.AreEqual (3.1415f, obj.FloatValue, "4 FloatValue");
			}

			using (var obj = new SKUniform ("name", V2)) {
				Asserts.AreEqual (V2, obj.FloatVector2Value, "5 FloatVector2Value");
			}

			using (var obj = new SKUniform ("name", V3)) {
				Asserts.AreEqual (V3, obj.FloatVector3Value, "6 FloatVector3Value");
			}

			using (var obj = new SKUniform ("name", V4)) {
				Asserts.AreEqual (V4, obj.FloatVector4Value, "7 FloatVector4Value");
			}

			using (var obj = new SKUniform ("name", M2)) {
				Asserts.AreEqual (M2, obj.FloatMatrix2Value, "8 FloatMatrix2Value");
			}

			using (var obj = new SKUniform ("name", M3)) {
				Asserts.AreEqual (M3, obj.FloatMatrix3Value, "9 FloatMatrix3Value");
			}

			using (var obj = new SKUniform ("name", M4)) {
				Asserts.AreEqual (M4, obj.FloatMatrix4Value, "10 FloatMatrix4Value");
			}
		}
	}
}

#endif // __WATCHOS__
