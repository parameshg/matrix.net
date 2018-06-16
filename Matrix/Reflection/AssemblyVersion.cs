namespace Matrix.Reflection
{
    public class AssemblyVersion
    {
        public int Major { get; private set; }

        public int Minor { get; private set; }

        public int Revision { get; private set; }

        public int Build { get; private set; }

        public AssemblyVersion(string version)
        {
            string[] args = version.Split('.');

            if (args.Length.Equals(4))
            {
                Major = int.Parse(args[0].Trim());
                Minor = int.Parse(args[1].Trim());
                Revision = int.Parse(args[2].Trim());
                Build = int.Parse(args[3].Trim());
            }
        }

        public AssemblyVersion(int majorVersion, int minorVersion, int revision, int build)
        {
            Major = majorVersion;
            Minor = minorVersion;
            Revision = revision;
            Build = build;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}", Major, Minor, Revision, Build);
        }
    }
}