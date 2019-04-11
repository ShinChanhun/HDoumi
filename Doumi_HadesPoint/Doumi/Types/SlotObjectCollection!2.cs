namespace Doumi.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Doumi.Nexon.Net;

    public class SlotObjectCollection
        <TPatron, TSlot> : IEnumerable<TSlot>, IEnumerable where TPatron: NexonPatron<TPatron> where TSlot: SlotObject
    {
        private TPatron patron;
        private TSlot[] items;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<TPatron, TSlot> ItemAdded;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<TPatron, byte> ItemRemoved;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<TPatron, TSlot> ItemUsed;

        public SlotObjectCollection(TPatron patron, int capacity)
        {
            this.patron = patron;
            this.items = new TSlot[capacity + 1];
        }

        public void Add(TSlot item)
        {
            if (item != null)
            {
                this[item.Slot] = item;
                if (this.ItemAdded != null)
                {
                    this.ItemAdded(this.patron, item);
                }
            }
        }

        //[IteratorStateMachine(typeof(<GetEnumerator>d__20))]
        public IEnumerator<TSlot> GetEnumerator()
        {
            foreach (TSlot slot5__3 in this.items)
            {
                yield return slot5__3;
               // slot5__3 = default(TSlot);
            }
        }

        public void Remove(byte slot)
        {
            this[slot] = default(TSlot);
            if (this.ItemRemoved != null)
            {
                this.ItemRemoved(this.patron, slot);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public void Use(byte slot)
        {
            TSlot local = this[slot];
            if ((local != null) && (this.ItemUsed != null))
            {
                this.ItemUsed(this.patron, local);
            }
        }

        public int Length =>
            this.items.Length;

        public TSlot this[int slot]
        {
            get
            {
                return this.items[slot];
            }
            set
            {
                this.items[slot] = value;
            }
        }

        /*
        [CompilerGenerated]
        private sealed class <GetEnumerator>d__20 : IEnumerator<TSlot>, IEnumerator, IDisposable
        {
            private int 1__state;
            private TSlot 2__current;
            public SlotObjectCollection<TPatron, TSlot> 4__this;
            private TSlot[] s__1;
            private int s__2;
            private TSlot <slot>5__3;

            [DebuggerHidden]
            public <GetEnumerator>d__20(int 1__state)
            {
                this.1__state = 1__state;
            }

            private bool MoveNext()
            {
                switch (this.1__state)
                {
                    case 0:
                        this.1__state = -1;
                        this.s__1 = this.4__this.items;
                        this.s__2 = 0;
                        while (this.s__2 < this.s__1.Length)
                        {
                            this.<slot>5__3 = this.s__1[this.s__2];
                            this.2__current = this.<slot>5__3;
                            this.1__state = 1;
                            return true;
                        Label_0067:
                            this.1__state = -1;
                            this.<slot>5__3 = default(TSlot);
                            this.s__2++;
                        }
                        this.s__1 = null;
                        return false;

                    case 1:
                        goto Label_0067;
                }
                return false;
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }

            TSlot IEnumerator<TSlot>.Current =>
                this.2__current;

            object IEnumerator.Current =>
                this.2__current;
        }
        */
    }
}

