using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NumberGenerator.Logic.IObservable;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Implementiert einen Nummern-Generator, welcher Zufallszahlen generiert.
    /// Es können sich Beobachter registrieren, welche über eine neu generierte Zufallszahl benachrichtigt werden.
    /// Zwischen der Generierung der einzelnen Zufallsnzahlen erfolgt jeweils eine Pause.
    /// Die Generierung erfolgt so lange, solange Beobachter registriert sind.
    /// </summary>
    public class RandomNumberGenerator : IObservable
    {
        private static readonly int DEFAULT_SEED = DateTime.Now.Millisecond;
        private const int DEFAULT_DELAY = 500;

        private const int RANDOM_MIN_VALUE = 1;
        private const int RANDOM_MAX_VALUE = 1000;

        public int DelayTime { get; set; }
        public int Seed { get; set; }

        public event EventHandler<int> NumberHandler;

        public RandomNumberGenerator() : this(DEFAULT_DELAY, DEFAULT_SEED)
        {
        }
        public RandomNumberGenerator(int delay) : this(delay, DEFAULT_SEED)
        {
        }
        public RandomNumberGenerator(int delay, int seed)
        {
            DelayTime = delay;
            Seed = seed;
        }

        public void NotifyObservers(int number)
        {
            Console.WriteLine($"New Number: {number}");
            NumberHandler?.Invoke(this, number);
        }
        public void StartNumberGeneration()
        {
            Random random = new Random(Seed);

            while (NumberHandler != null)
            {
                NotifyObservers(random.Next(RANDOM_MIN_VALUE, RANDOM_MAX_VALUE));
                Task.Delay(DelayTime).Wait();
            }
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

}
