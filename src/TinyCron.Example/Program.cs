using System;
using System.Threading;
using System.Threading.Tasks;

namespace TinyCron.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instance
            var tinyCronApplication = new TinyCronApplication();

            //listen for tiny cron events (optional)
            tinyCronApplication.Events.OnStarted = () => Console.WriteLine("TinyCron started");
            tinyCronApplication.Events.OnStopped = () => Console.WriteLine("TinyCron stopped");
            tinyCronApplication.Events.OnJobRunInitiated = job => Console.WriteLine("job initiated");
            tinyCronApplication.Events.OnJobRunCompleted = job => Console.WriteLine("job completed");
            tinyCronApplication.Events.OnJobRunFailed = job => Console.WriteLine("job failed");

            //create cron jobs
            var anonymousCronJob = new AnonymousTinyCronJob("* * * * *", () => Console.WriteLine("I'm a scheduled anonymous method!"));
            var customCronJob = new CustomCronJob(cronExpression: "* * * * *");

            //register cron jobs
            tinyCronApplication.Register(anonymousCronJob);
            tinyCronApplication.Register(customCronJob);

            //start async
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            var cancellationToken = new CancellationToken();
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            tinyCronApplication.StartAsync(cancellationToken, scheduler);

            //or

            //start sync (an infinite loop)
            //tinyCronApplication.Start();

            //keep console open
            Console.ReadKey();
        }
    }

    public class CustomCronJob : TinyCronJob
    {
        public CustomCronJob(string cronExpression)
            : base(cronExpression)
        {
        }

        public CustomCronJob(string cronExpression, string description)
            : base(cronExpression, description)
        {
        }

        public override void Run()
        {
            Console.WriteLine("I'm a custom TinyCronJob!");
        }
    }
}
