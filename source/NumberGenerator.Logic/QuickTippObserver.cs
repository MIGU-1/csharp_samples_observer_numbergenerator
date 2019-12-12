using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher auf einen vollständigen Quick-Tipp wartet: 6 unterschiedliche Zahlen zw. 1 und 45.
    /// </summary>
    public class QuickTippObserver
    {
        private IObservable _numberGenerator;

        public List<int> QuickTippNumbers { get; private set; }
        public int CountOfNumbersReceived { get; private set; }

        public QuickTippObserver(IObservable numberGenerator)
        {
            if (numberGenerator == null)
                throw new ArgumentNullException(nameof(numberGenerator));

            CountOfNumbersReceived = 0;
            QuickTippNumbers = new List<int>();

            numberGenerator.NumberHandler += OnNextNumber;
            _numberGenerator = numberGenerator;
        }

        public void OnNextNumber(int number)
        {
            CountOfNumbersReceived++;

            if (QuickTippNumbers.Count < 6)
            {
                if (number >= 1 && number <= 45)
                    QuickTippNumbers.Add(number);

                if (QuickTippNumbers.Count == 6)
                    DetachFromNumberGenerator();
            }
        }
        private void DetachFromNumberGenerator()
        {
            _numberGenerator.NumberHandler -= OnNextNumber;
        }
        public override string ToString()
        {
            return $"{base.ToString()} = Quicktipp: | {QuickTippNumbers[0]} | {QuickTippNumbers[1]} | {QuickTippNumbers[2]} | {QuickTippNumbers[3]} | {QuickTippNumbers[4]} | {QuickTippNumbers[5]}";
        }
    }
}
