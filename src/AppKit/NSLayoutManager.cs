// Copyright 2015 Xamarin, Inc.
using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreGraphics;

namespace XamCore.AppKit {
	partial class NSLayoutManager {
#if !XAMCORE_2_0
		public uint GlyphAtIndex (nint glyphIndex, ref bool isValidIndex)
		{
			return GlyphAtIndexisValidIndex ((nuint) glyphIndex, ref isValidIndex);
		}

		public uint GlyphAtIndex (nint glyphIndex)
		{
			return GlyphCount (glyphIndex);
		}
#endif

		[Availability (Introduced = Platform.Mac_10_0, Deprecated = Platform.Mac_10_11)]
		public CGRect [] GetRectArray (NSRange glyphRange, NSRange selectedGlyphRange, NSTextContainer textContainer)
		{
			if (textContainer == null)
				throw new ArgumentNullException ("textContainer");

			nuint rectCount;
			var retHandle = GetRectArray (glyphRange, selectedGlyphRange, textContainer.Handle, out rectCount);
			var returnArray = new CGRect [rectCount];

			unsafe {
				float *ptr = (float*) retHandle;
				for (nuint i = 0; i < rectCount; ++i) {
					returnArray [i] = new CGRect (ptr [0], ptr [1], ptr [2], ptr [3]);
					ptr += 4;
				}
			}
			return returnArray;
		}
	}
}
