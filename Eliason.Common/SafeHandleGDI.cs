#region

using System;
using System.Security.Permissions;

#endregion

namespace Eliason.Common
{
    public class SafeHandleGDI : SafeHandleGDIBase
    {
        public SafeHandleGDI(IntPtr handle)
            : base(handle)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        protected override bool ReleaseHandle()
        {
            bool result = SafeNativeMethods.DeleteObject(handle);

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