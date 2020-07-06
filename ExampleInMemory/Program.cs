using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PubSubLib.Interfaces;
using PubSubLib.Memory;

namespace ExampleInMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            var memoryHub = new MemoryHub();

            var intPublisher = new MemoryPublisher<int>(memoryHub);

            var subs = GenerateSubscribers<int>(10, memoryHub);

            
            // I used labels and goto here just because making a loop would look dirty
            begin:
            Console.Write("Please enter a number: ");
            
            var value = Console.ReadLine();

            if (int.TryParse(value, out var intValue))
            {
                intPublisher.Publish(intValue);
            }
            else
            {
                Console.WriteLine("Invalid number entered!");
                goto begin;
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static List<ISubscriber<T>> GenerateSubscribers<T>(int num, IMessageHub hub)
        {
            var list = new List<ISubscriber<T>>();

            for (var i = 0; i < num; i++)
            {
                var sub = new MemorySubscriber<T>(hub);
                var local = i;
                sub.OnChange += x => Console.WriteLine($"Message '{x}' received on subscriber: {local}");
                list.Add(sub);
            }

            return list;
        }
    }
}
