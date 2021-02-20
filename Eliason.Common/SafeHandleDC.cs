#region

using System;
using System.Security.Permissions;

#endregion

namespace Eliason.Common
{
    public class SafeHandleDC : SafeHandleGDIBase
    {
        public SafeHandleDC(IntPtr handle)
            : base(handle)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        protected override bool ReleaseHandle()
        {
            SafeNativeMethods.SelectObject(handle, IntPtr.Zero);
            bool result = SafeNativeMethods.DeleteDC(handle) != 0;

            if (result)
            {
                SetHandle(IntPtr.Zero);
                SetHandleAsInvalid();
            }

            GC.SuppressFinalize(this);

            return result;
        }
    }
}