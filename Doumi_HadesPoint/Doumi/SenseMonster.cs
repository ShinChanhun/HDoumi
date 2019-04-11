namespace Doumi
{
    using System;
    using System.Text.RegularExpressions;

    public class SenseMonster
    {
        private Match match;
        private static readonly Regex regex = new Regex(@"       \*\*\*\*\*  Sense Monster  \*\*\*\*\* \n\n   Name:[ ]*(?<Name>[\S]+)[ ]*EXP:[ ]*(?<EXP>[\d]+)\n   HP:[ ]*(?<HP>[\d]+)\n   Lev:[ ]*(?<Lev>[\d]+)\n   ATTACK NATURE:[ ]*(?<Offense>[\S]+)\n   DEFENSE NATURE:[ ]*(?<Defense>[\S]+)\n");

        public SenseMonster(string text)
        {
            this.match = regex.Match(text);
        }

        public string Defense =>
            this.match.Groups["Defense"].Value;

        public string EXP =>
            this.match.Groups["EXP"].Value;

        public string HP =>
            this.match.Groups["HP"].Value;

        public bool IsValid =>
            this.match.Success;

        public string Lev =>
            this.match.Groups["Lev"].Value;

        public string Name =>
            this.match.Groups["Name"].Value;

        public string Offense =>
            this.match.Groups["Offense"].Value;
    }
}

