namespace Matrix.Framework.Configuration
{
    public class DatabaseConfiguration
    {
        public string Type { get; set; }

        public string Connection { get; set; }

        public bool Logging { get; set; }

        public bool SensitiveDataLogging { get; set; }
    }
}