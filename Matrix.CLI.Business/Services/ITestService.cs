using System.Threading.Tasks;

namespace Matrix.CLI.Business.Services
{
    public interface ITestService
    {
        Task TestRegistry(bool admin);

        Task TestConfigurator(bool admin);

        Task TestDirectory(bool admin);

        Task TestJournal(bool admin);

        Task TestPostman(bool admin);
    }
}