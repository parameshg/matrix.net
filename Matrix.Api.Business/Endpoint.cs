namespace Matrix.Api.Business
{
    public static class Endpoint
    {
        public static string Registry { get { return "http://matrix_registry/api"; } }

        public static string Directory { get { return "http://matrix_directory/api"; } }

        public static string Configuration { get { return "http://matrix_configurator/api"; } }

        public static string Journal { get { return "http://matrix_journal/api"; } }

        public static string Postman { get { return "http://matrix_postman/api"; } }
    }
}