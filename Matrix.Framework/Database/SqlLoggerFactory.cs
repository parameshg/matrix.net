using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Matrix.Framework.Database
{
    public class SqlLoggerFactory : LoggerFactory
    {
        public SqlLoggerFactory()
            : base(new[] { new ConsoleLoggerProvider((category, level) => level >= LogLevel.Trace, false) })
        {
        }
    }
}