namespace Doumi.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated]
    internal class Resources
    {
        private static System.Resources.ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (resourceMan == null)
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Doumi.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap Close =>
            ((Bitmap) ResourceManager.GetObject("Close", resourceCulture));

        internal static byte[] ImagePal =>
            ((byte[]) ResourceManager.GetObject("ImagePal", resourceCulture));

        internal static Bitmap MainBack =>
            ((Bitmap) ResourceManager.GetObject("MainBack", resourceCulture));

        internal static Bitmap Min =>
            ((Bitmap) ResourceManager.GetObject("Min", resourceCulture));

        internal static byte[] SkillEpf =>
            ((byte[]) ResourceManager.GetObject("SkillEpf", resourceCulture));

        internal static byte[] SpellEpf =>
            ((byte[]) ResourceManager.GetObject("SpellEpf", resourceCulture));

        internal static Bitmap walltexture =>
            ((Bitmap) ResourceManager.GetObject("walltexture", resourceCulture));
    }
}

