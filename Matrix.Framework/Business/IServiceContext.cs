namespace Matrix.Framework.Business
{
    public interface IServiceContext
    {
        string Registry { get; set; }

        string Directory { get; set; }

        string Configurator { get; set; }

        string Journal { get; set; }

        string Postman { get; set; }
    }
}