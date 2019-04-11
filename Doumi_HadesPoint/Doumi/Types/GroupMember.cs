namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class GroupMember
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <Area>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <X>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private int <Y>k__BackingField;
        */

        public GroupMember(string name, string area, ushort x, ushort y)
        {
            this.Name = name;
            this.Area = area;
            this.X = x;
            this.Y = y;
        }

        public GroupMember CopyFrom(GroupMember value)
        {
            this.Name = value.Name;
            this.Area = value.Area;
            this.X = value.X;
            this.Y = value.Y;
            return this;
        }

        public string Name { get; set; }

        public string Area { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}

