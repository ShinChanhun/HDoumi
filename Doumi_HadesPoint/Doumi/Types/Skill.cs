namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Skill : SlotObject
    {
        private string text;

        /*
private string text;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private ushort <Icon>k__BackingField;
[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
private DateTime <LastUsed>k__BackingField;
[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
private TimeSpan <Recharge>k__BackingField;
*/

        public Skill(NexonPacket packet)
        {
            base.Slot = packet.ReadU1();
            this.Icon = packet.ReadU2();
            this.Text = packet.ReadC1();
        }

        private bool ShouldSerializeIcon() => 
            false;

        private bool ShouldSerializeName() => 
            false;

        private bool ShouldSerializeSlot() => 
            false;

        private bool ShouldSerializeText() => 
            false;

        [Browsable(false)]
        public bool CanUse =>
            ((DateTime.Now - this.LastUsed) > this.Recharge);

        public ushort Icon { get; set; }

        [Category("Timing")]
        public DateTime LastUsed { get; set; }

        [Category("Timing")]
        public TimeSpan Recharge { get; set; }

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
    }
}

