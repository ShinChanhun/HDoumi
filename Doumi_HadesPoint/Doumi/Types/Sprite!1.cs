namespace Doumi.Types
{
    using System;

    public abstract class Sprite<T> : Sprite where T: Sprite<T>
    {
        protected Sprite()
        {
        }

        public abstract T CopyFrom(T value);
    }
}

