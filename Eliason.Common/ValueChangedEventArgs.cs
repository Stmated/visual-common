using System;

namespace Eliason.Common
{
    public class ValueChangedEventArgs : EventArgs
    {
        public ValueChangedBy By { get; set; }
    }
}