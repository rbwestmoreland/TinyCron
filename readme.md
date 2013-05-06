TinyCron
===  

**TinyCron** is cron for .NET 

    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var tinyCron = new TinyCronApplication();
            var cronJob = new AnonymousTinyCronJob("* * * * *", () => Console.WriteLine("I'll run every minute!"));
            tinyCron.Register(cronJob);
            tinyCron.Start();
        }
    }

[**more examples** :arrow_right:](/src/TinyCron.Example/Program.cs)

Dependencies
---  
* .NET 4.5

Installation
---  
* Copy [TinyCron.cs](/src/TinyCron/TinyCron.cs) into your project.


License
---  
**TinyCron** is licensed under the [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) license  
[**NCrontab**](https://code.google.com/p/ncrontab/) is licensed under the [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) license  
