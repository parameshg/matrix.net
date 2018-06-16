using System;
using System.Threading.Tasks;
using Matrix.Threading;

namespace Matrix.Extension
{
    public static class ThreadingExtension
    {
        public static void Execute(this Func<Task> task) => Async.Execute(task);

        public static TResult Execute<TResult>(this Func<Task<TResult>> task) => Async.Execute(task);
    }
}