namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class SignalProperty<T>
    {
        private T field;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action ValueChanged;

        public T Get() => 
            this.field;

        public void Set(T value)
        {
            if (!value.Equals(this.field))
            {
                this.field = value;
                if (this.ValueChanged != null)
                {
                    this.ValueChanged();
                }
            }
        }
    }
}

