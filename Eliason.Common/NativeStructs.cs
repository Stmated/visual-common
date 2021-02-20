using System;
using System.Runtime.InteropServices;

namespace Eliason.Common
{
    [Flags]
    public enum GCS
    {
        GCS_COMPREADSTR = 1,
        GCS_COMPREADATTR = 2,
        GCS_COMPREADCLAUSE = 4,
        GCS_COMPSTR = 8,
        GCS_COMPATTR = 16,
        GCS_COMPCLAUSE = 32,
        GCS_CURSORPOS = 128,
        GCS_DELTASTART = 256,
        GCS_RESULTREADSTR = 512,
        GCS_RESULTREADCLAUSE = 1024,
        GCS_RESULTSTR = 2048,
        GCS_RESULTCLAUSE = 4096
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CANDIDATEFORM
    {
        public int dwIndex;
        public int dwStyle;
        public POINT ptCurrentPos;
        public RECT rcArea;
    }
}
