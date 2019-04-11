namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class DeSpellList
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <DeRento>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <DeBardo>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <DeDefleca>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <DePrava>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <HolyCure>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <DeNarcoli>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <DeSoruma>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <DeVenomo>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Illumena>k__BackingField;
        */

        public DeSpellList()
        {
            this.DeRento = false;
            this.DeBardo = false;
            this.DeDefleca = false;
            this.DePrava = false;
            this.HolyCure = false;
            this.DeNarcoli = false;
            this.DeSoruma = false;
            this.DeVenomo = false;
            this.Illumena = false;
        }

        public bool DeRento { get; set; }

        public bool DeBardo { get; set; }

        public bool DeDefleca { get; set; }

        public bool DePrava { get; set; }

        public bool HolyCure { get; set; }

        public bool DeNarcoli { get; set; }

        public bool DeSoruma { get; set; }

        public bool DeVenomo { get; set; }

        public bool Illumena { get; set; }
    }
}

