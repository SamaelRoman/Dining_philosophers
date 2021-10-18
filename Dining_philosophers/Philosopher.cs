using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philosophers
{
    public class Philosopher
    {
        bool X = true;
        /// <summary>
        /// Идентификатор философа
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Вилка слева
        /// </summary>
        private Fork LeftFork { get;}
        /// <summary>
        /// Вилка справа
        /// </summary>
        private Fork RightFork { get; set; }
        /// <summary>
        /// Конструктор класса Philosopher
        /// </summary>
        /// <param name="ID">ID философа</param>
        /// <param name="LeftFork">Вилка слева</param>
        /// <param name="RightFork">Вилка справа</param>
        public Philosopher(int ID, Fork LeftFork, Fork RightFork)
        {
            this.ID = ID;
            this.LeftFork = LeftFork;
            this.RightFork = RightFork;
        }
        private void Think()
        {
            Console.WriteLine($"философ номер \"{ID}\" начал думать.");
            Thread.Sleep(1000);
            Console.WriteLine($"философ номер \"{ID}\" закончил думать.");

        }
        private void Eating()
        {
            LeftFork.Take();
            Console.WriteLine($"философ номер \"{ID}\" взял в левую руку вилку {LeftFork}");
            RightFork.Take();
            Console.WriteLine($"философ номер \"{ID}\" взял в правую руку вилку {RightFork}");
            Console.WriteLine($"философ номер \"{ID}\" кушает!");
            Thread.Sleep(1000);
            RightFork.Put();
            Console.WriteLine($"философ номер \"{ID}\" ложит правую вилку на место!");
            LeftFork.Put();
            Console.WriteLine($"философ номер \"{ID}\" ложит левую вилку на место!");
        }
        public void Start()
        {
            
            while (X)
            {
                Think();
            TryEat:
                if (Waiter.ICanEat() == true)
                {
                    Eating();
                }
                else
                {
                    goto TryEat;
                }
                
            }
        }
        public void Stop()
        {
            X = false;
        }
    }
}
