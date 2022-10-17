using Hangfire;
using JDNowTop.Logic.Operations;

namespace JDNowTop.API.RecurringJobs
{
    public static class JobsManager
    {
        public static void EnqueueDatabaseSeeding()
        {
            RecurringJob.AddOrUpdate<DatabaseSeeder>("SeedSongs", s => s.SeedSongs(), Cron.Weekly);
            RecurringJob.AddOrUpdate<DatabaseSeeder>("SeedPositions", s => s.SeedPositions(), Cron.Weekly);
        }
    }
}
