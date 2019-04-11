namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Spell : SlotObject
    {
        private string text;

        /*
private string text;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private ushort <Icon>k__BackingField;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private DateTime <LastUsed>k__BackingField;
[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
private string <Note>k__BackingField;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private TimeSpan <Recharge>k__BackingField;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private byte <Span>k__BackingField;
[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
private byte <Type>k__BackingField;
*/

        public Spell(NexonPacket packet)
        {
            base.Slot = packet.ReadU1();
            this.Icon = packet.ReadU2();
            this.Type = packet.ReadU1();
            this.Text = packet.ReadC1();
            this.Note = packet.ReadC1();
            packet.ReadU1();
            this.Span = packet.ReadU1();
        }

        private bool ShouldSerializeIcon() => 
            false;

        private bool ShouldSerializeName() => 
            false;

        private bool ShouldSerializeNote() => 
            false;

        private bool ShouldSerializeSlot() => 
            false;

        private bool ShouldSerializeSpan() => 
            false;

        private bool ShouldSerializeText() => 
            false;

        private bool ShouldSerializeType() => 
            false;

        public ushort Icon { get; set; }

        [Category("Timing")]
        public DateTime LastUsed { get; set; }

        public string Note { get; set; }

        [Category("Timing")]
        public TimeSpan Recharge { get; set; }

        public byte Span { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                int index = value.IndexOf(" (Lev:");
                if (index > 0)
                {
                    base.Name = value.Substring(0, index);
                }
                this.text = value;
            }
        }

        public byte Type { get; set; }
    }
}

