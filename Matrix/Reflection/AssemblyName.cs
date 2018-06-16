namespace Matrix.Reflection
{
    public class AssemblyName
    {
        public string Name { get; private set; }

        public AssemblyVersion Version { get; private set; }

        public string Culture { get; private set; }

        public string PublicKeyToken { get; private set; }

        public AssemblyName(string name)
        {
            string[] args = name.Split(',');

            if (args.Length >= 1)
            {
                Name = args[0].Trim();

                if (args.Length.Equals(4))
                {
                    Version = new AssemblyVersion(args[1].Trim());
                    Culture = args[2].Trim();
                    PublicKeyToken = args[3].Trim();
                }
            }
        }

        public AssemblyName(string name, int majorVersion, int minorVersion, int revision, int build,
            string culture, string publicKeyToken)
        {
            Name = name;
            Version = new AssemblyVersion(majorVersion, minorVersion, revision, build);
            Culture = culture;
            PublicKeyToken = publicKeyToken;
        }

        public override string ToString()
        {
            string result = string.Empty;

            result = string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}",
                Name, Version.ToString(), Culture, PublicKeyToken);

            return result;
        }
    }
}