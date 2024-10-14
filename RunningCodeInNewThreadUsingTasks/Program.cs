using Microsoft.VisualBasic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RunningCodeInNewThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //create and start an anonymous thread
            new Task(CountToTen).Start();

            var task1 = new Task(() => CountToTenNamed("My first thread"));    //create (but don't start) a new task
            var task2 = new Task(() => CountToTenNamed("My second thread"));    //create (but don't start) a new task
            var task3 = new Task(() => CountToTenNamed("My third thread"));     //create (but don't start) a new task

            task1.Start();     //start task1
            task2.Start();     //start task2
            task3.Start();     //start task3

            Task.WhenAll( task1, task2, task3).Wait();  //wait for all threads to finish

            Console.WriteLine("Done!");     
        }


        private static void CountToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        private static void CountToTenNamed(object threadName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Thread {threadName}: {i}");
                Thread.Sleep(100);
            }
        }
    }
}