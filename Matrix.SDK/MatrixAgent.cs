namespace Matrix.SDK
{
    public class MatrixAgent
    {
        public RemoteRegistry Registry { get; private set; }

        public RemoteConfigurator Configuration { get; private set; }

        public RemoteDirectory Directory { get; private set; }

        public RemoteLogger Logger { get; private set; }

        public RemoteGateway Gateway { get; private set; }

        public MatrixAgent()
        {
            Registry = new RemoteRegistry();

            Configuration = new RemoteConfigurator();

            Directory = new RemoteDirectory();

            Logger = new RemoteLogger();

            Gateway = new RemoteGateway();
        }
    }
}