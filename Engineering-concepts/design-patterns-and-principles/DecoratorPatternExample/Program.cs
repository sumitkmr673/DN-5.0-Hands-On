using System;

namespace DecoratorPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Testing Decorator Pattern------\n");

            string alertMessage = "Server downtime scheduled at midnight.";

            Console.WriteLine("Client: Sending basic email notification...");
            INotifier basicNotifier = new EmailNotifier();
            basicNotifier.Send(alertMessage);

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Client: Sending email + SMS notification...");
            INotifier smsNotifier = new SMSNotifierDecorator(basicNotifier);
            smsNotifier.Send(alertMessage);

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Client: Sending email + SMS + Slack notification...");
            INotifier fullNotifier = new SlackNotifierDecorator(smsNotifier);
            fullNotifier.Send(alertMessage);
        }
    }
}