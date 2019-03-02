namespace Matrix.Api.Configuration
{
    public class Settings
    {
        public static string Root { get { return "Matrix"; } }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public bool Stub { get; set; }

        public string Deployment { get; set; }

        public Endpoints Endpoints { get; set; }

        public Settings()
        {
            Endpoints = new Endpoints();
        }
    }
}