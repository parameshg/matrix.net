using System;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix.Threading
{
    public class Async
    {
        private static readonly TaskFactory _ = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        public static TResult Execute<TResult>(Func<Task<TResult>> task)
        {
            return _
              .StartNew(task)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }

        public static void Execute(Func<Task> task)
        {
            _
              .StartNew(task)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }
    }
}