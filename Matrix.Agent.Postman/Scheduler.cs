using Matrix.Agent.Postman.Business.Jobs;
using Matrix.Threading;
using Quartz;
using Quartz.Impl;

namespace Matrix.Agent.Postman
{
    public static class Scheduler
    {
        private static readonly IScheduler _scheduler;

        static Scheduler()
        {
            _scheduler = Async.Execute(() => StdSchedulerFactory.GetDefaultScheduler());
        }

        public static void Start()
        {
            Async.Execute(() => _scheduler.Start());

            var emailJob = JobBuilder.Create<EmailJob>().Build();

            var hourly = TriggerBuilder.Create().WithDailyTimeIntervalSchedule(i =>
            {
                i.WithIntervalInHours(1).OnEveryDay();

            }).Build();

            Async.Execute(() => _scheduler.ScheduleJob(emailJob, hourly));
        }

        public static void Stop()
        {
            Async.Execute(() => _scheduler.Shutdown());
        }
    }
}