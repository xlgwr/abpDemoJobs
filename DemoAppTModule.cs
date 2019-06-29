using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace demo3 {
    [DependsOn (
        typeof (BackgroundJobsEntityFrameworkCoreModule),
        typeof (AbpAutofacModule),
        typeof (AbpEntityFrameworkCoreMySQLModule)
    )]
    public class DemoAppTModule : AbpModule {
        public override void ConfigureServices (ServiceConfigurationContext context) {
            Configure<AbpDbContextOptions> (options => {
                options.Configure (opts => {
                    opts.UseMySQL ();
                });
            });
            Configure<BackgroundJobWorkerOptions> (options => {
                options.JobPollPeriod = 1000;
                options.DefaultFirstWaitDuration = 1;
                options.DefaultWaitFactor = 1;
            });
        }
        public override void OnPostApplicationInitialization (Volo.Abp.ApplicationInitializationContext context) {
            context.ServiceProvider
                .GetRequiredService<SampleJobCreator> ()
                .CreateJobs ();
        }
        public override void OnApplicationInitialization (Volo.Abp.ApplicationInitializationContext context) {
            context
                .ServiceProvider
                .GetRequiredService<ILoggerFactory> ()
                .AddConsole (LogLevel.Debug);
        }
    }
}