namespace Matrix.Web.Business
{
    public static class Endpoint
    {
        public static string Registry { get { return "http://matrix.registry/api"; } }

        public static string Directory { get { return "http://matrix.directory/api"; } }

        public static string Configuration { get { return "http://matrix.configurator/api"; } }

        public static string Journal { get { return "http://matrix.journal/api"; } }

        public static string Postman { get { return "http://matrix.postman/api"; } }
    }
}