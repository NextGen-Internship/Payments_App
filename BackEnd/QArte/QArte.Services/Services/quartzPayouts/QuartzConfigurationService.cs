using Microsoft.Extensions.Configuration;
using Quartz;

namespace QArte.Services.Services.quartzPayouts
{
	public static class QuartzConfigurationService
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
            {
                var jobName = typeof(T).Name;
                var configKey = $"Quartz:CronExpression_{jobName}";
                var cronSchedule = config[configKey];
                if (string.IsNullOrEmpty(cronSchedule))
                {
                    throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
                }

                var jobKey = new JobKey(jobName);
                quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));
                quartz.AddTrigger(opts => opts
                                          .ForJob(jobKey)
                                          .WithIdentity(jobName + "-trigger")
                                          .WithCronSchedule(cronSchedule));
                var exp = new CronExpression(cronSchedule);
                var nextFire = exp.GetNextValidTimeAfter(DateTime.Now);
            }
    }
}

