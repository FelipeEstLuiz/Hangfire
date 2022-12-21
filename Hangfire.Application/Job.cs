namespace Hangfire.Application
{
    public static class Job
    {
        public static void ExecutarJobs()
        {
            RecurringJob.AddOrUpdate<IServiceManagement>(x => x.Run(), "*/5 * * * * *");
        }
    }
}
