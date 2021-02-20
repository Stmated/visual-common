#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Eliason.Common
{
    public abstract class SafeHandleGDIBase : SafeHandle
    {
        protected SafeHandleGDIBase(IntPtr handle)
            : base(IntPtr.Zero, true)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }
    }
}