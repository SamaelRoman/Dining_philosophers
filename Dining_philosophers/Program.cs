using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Fork F1 = new Fork(1);
            Fork F2 = new Fork(2);
            Fork F3 = new Fork(3);
            Fork F4 = new Fork(4);
            Fork F5 = new Fork(5);

            Waiter.Forks.Add(F1);
            Waiter.Forks.Add(F2);
            Waiter.Forks.Add(F3);
            Waiter.Forks.Add(F4);
            Waiter.Forks.Add(F5);

            Philosopher PH1 = new Philosopher(1, F1, F2);
            Philosopher PH2 = new Philosopher(2, F2, F3);
            Philosopher PH3 = new Philosopher(3, F3, F4);
            Philosopher PH4 = new Philosopher(4, F4, F5);
            Philosopher PH5 = new Philosopher(5, F5, F1);

            Thread T1 = new Thread(() => PH1.Start());
            Thread T2 = new Thread(() => PH2.Start());
            Thread T3 = new Thread(() => PH3.Start());
            Thread T4 = new Thread(() => PH4.Start());
            Thread T5 = new Thread(() => PH5.Start());

            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            T5.Start();

            Console.ReadKey();
        }
    }
}
