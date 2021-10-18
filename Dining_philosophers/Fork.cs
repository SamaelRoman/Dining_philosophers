using System.Threading;

namespace Dining_philosophers
{
    public class Fork
    {
        public Mutex M;
        /// <summary>
        /// Залочен ли обект
        /// </summary>
        public bool IsLocked { get; private set; }
        /// <summary>
        /// Конструктор класса Fork
        /// </summary>
        /// <param name="ID">Fork ID</param>
        public Fork(int ID)
        {
            this.ID = ID;
            M = new Mutex(false, $"MutextFork{ID}");
            IsLocked = false;
        }
        /// <summary>
        /// Идентификатор вилки.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Lock
        /// </summary>
        public void Take()
        {
            M.WaitOne();
            IsLocked = true;
        }
        /// <summary>
        /// Unlock
        /// </summary>
        public void Put()
        {
            M.ReleaseMutex();
            IsLocked = false;
        }
        public override string ToString()
        {
            return $"Номер {ID}";
        }
    }
}