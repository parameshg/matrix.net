namespace Matrix.Framework.Configuration
{
    public class GlobalConfiguration
    {
        public static string Root { get { return "Matrix"; } }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public AgentConfiguration Agent { get; set; }

        public string Deployment { get; set; }
    }
}