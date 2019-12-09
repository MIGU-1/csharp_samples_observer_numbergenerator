using System;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher einfache Statistiken bereit stellt (Min, Max, Sum, Avg).
    /// </summary>
    public class StatisticsObserver : BaseObserver
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Enthält das Minimum der generierten Zahlen.
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Enthält das Maximum der generierten Zahlen.
        /// </summary>
        public int Max { get; private set; }

        /// <summary>
        /// Enthält die Summe der generierten Zahlen.
        /// </summary>
        public int Sum { get; private set; }
        public int Count { get; set; }

        /// <summary>
        /// Enthält den Durchschnitt der generierten Zahlen.
        /// </summary>
        public int Avg => Count > 0 ? Sum / Count : throw new DivideByZeroException(nameof(Count));

        #endregion

        #region Constructors

        public StatisticsObserver(IObservable numberGenerator, int countOfNumbersToWaitFor) : base(numberGenerator, countOfNumbersToWaitFor)
        {
            Min = int.MaxValue;
            Max = int.MinValue;
            Sum = 0;
            Count = 0;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public override void OnNextNumber(int number)
        {
            Count++;
            Sum += number;

            if (number < Min)
                Min = number;
            if (number > Max)
                Max = number;

            if (Count == CountOfNumbersToWaitFor)
                base.DetachFromNumberGenerator();
        }

        #endregion
    }
}
