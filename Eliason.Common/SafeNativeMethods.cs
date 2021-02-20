#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

#endregion

namespace Eliason.Common
{
    [SuppressUnmanagedCodeSecurity]
    public static class SafeNativeMethods
    {
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int FillRect(IntPtr hDC, ref RECT lprc, IntPtr hbr);

        [DllImport("Gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateSolidBrush(int crColor);

        [DllImport("Gdi32.dll", SetLastError = false)]
        public static extern IntPtr SelectObject(
            IntPtr hdc,
            IntPtr hgdiobj);

        [DllImport("Gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("Gdi32.dll", SetLastError = true)]
        public static extern uint DeleteDC(IntPtr hdc);

        [DllImport("Gdi32.Dll", SetLastError = true)]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        [DllImport("Gdi32.Dll", SetLastError = true)]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);

        [DllImport("Gdi32.Dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("Gdi32.Dll", SetLastError = true)]
        public static extern uint BitBlt(
            IntPtr hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc,
            int nXSrc,
            int nYSrc,
            uint dwRop);

        [DllImport("user32.dll")]
        public static extern IntPtr GetOpenClipboardWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("Imm32.dll")]
        public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("Imm32.dll", CharSet = CharSet.Unicode)]
        public static extern int ImmGetCompositionStringW(IntPtr hIMC, int dwIndex, byte[] lpBuf, int dwBufLen);

        [DllImport("Imm32.dll", CharSet = CharSet.Unicode)]
        public static extern bool ImmSetCandidateWindow(IntPtr hIMC, IntPtr lpCandidate);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "GetTextExtentPoint32W", SetLastError = true)]
        public static unsafe extern bool GetTextExtentPoint32(
            IntPtr hdc,
            char* lpString,
            int cbString,
            ref Size lpSize);

        [DllImport("Gdi32.Dll", SetLastError = true)]
        public static extern uint StretchBlt(
            IntPtr hdcDest,
            int nXOriginDest,
            int nYOriginDest,
            int nWidthDest,
            int nHeightDest,
            IntPtr hdcSrc,
            int nXOriginSrc,
            int nYOriginSrc,
            int nWidthSrc,
            int nHeightSrc,
            uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern int SetTextColor(
            [In] IntPtr hdc,
            [In] int crColor);

        [DllImport("gdi32.dll")]
        public static extern int GetTextColor(
            [In] IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(
            [In] IntPtr hdc,
            [In] int crColor);

        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(
            [In] IntPtr hdc,
            [In] int iBkMode);

        [DllImport("gdi32.dll")]
        public static extern int GetBkMode(
            [In] IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "TextOutW")]
        public unsafe static extern bool TextOut(
            [In] IntPtr hdc,
            [In] int nXStart,
            [In] int nYStart,
            [In] char* lpString,
            [In] int cbString);

        [DllImport("Gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);
        
        [DllImport("Gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateHatchBrush(int fnStyle, int crColor);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int x, int y, [Out] IntPtr lpPoint);
    }
}