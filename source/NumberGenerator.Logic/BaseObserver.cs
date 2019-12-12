using System;
using System.ComponentModel;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher die Zahlen auf der Konsole ausgibt.
    /// Diese Klasse dient als Basisklasse für komplexere Beobachter.
    /// </summary>
    public class BaseObserver
    {
        private readonly IObservable _numberGenerator;

        public int CountOfNumbersReceived { get; private set; }
        public int CountOfNumbersToWaitFor { get; private set; }

        public BaseObserver(IObservable numberGenerator, int countOfNumbersToWaitFor)
        {
            if (numberGenerator == null)
                throw new ArgumentNullException(nameof(numberGenerator));
            if (countOfNumbersToWaitFor <= 0)
                throw new ArgumentException(nameof(countOfNumbersToWaitFor));

            try
            {
                numberGenerator.NumberHandler += OnNextNumber;
                _numberGenerator = numberGenerator;
                CountOfNumbersToWaitFor = countOfNumbersToWaitFor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void OnNextNumber(int number)
        {
            CountOfNumbersReceived++;

            // Sobald die Anzahl der max. Beobachtungen (_countOfNumbersToWaitFor) erreicht ist -> Detach()
            if (CountOfNumbersReceived >= CountOfNumbersToWaitFor)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   >> {this.GetType().Name}: Received '{CountOfNumbersReceived}' of '{CountOfNumbersToWaitFor}' => I am not interested in new numbers anymore => Detach().");
                Console.ResetColor();
                DetachFromNumberGenerator();
            }
        }
        protected void DetachFromNumberGenerator()
        {
            _numberGenerator.NumberHandler -= OnNextNumber;
        }
        public override string ToString()
        {
            return $"Observer: ";
        }
    }
}
