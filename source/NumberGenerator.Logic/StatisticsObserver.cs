using System;

namespace NumberGenerator.Logic
{
    public class StatisticsObserver : BaseObserver
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Sum { get; private set; }
        public int Avg => CountOfNumbersReceived > 0 ? Sum / CountOfNumbersReceived : throw new DivideByZeroException(nameof(CountOfNumbersReceived));

        public StatisticsObserver(IObservable numberGenerator, int countOfNumbersToWaitFor) : base(numberGenerator, countOfNumbersToWaitFor)
        {
            Min = int.MaxValue;
            Max = int.MinValue;
            Sum = 0;
        }

        public override string ToString()
        {
            return $"BaseObserver [CountOfNumbersReceived='{CountOfNumbersReceived}', CountOfNumbersToWaitFor='{CountOfNumbersToWaitFor}'] => StatisticsObserver [Min='{Min}', Max='{Max}', Sum='{Sum}', Avg='{Avg}']";
        }
        public override void OnNextNumber(int number)
        {
            base.OnNextNumber(number);
            Sum += number;

            if (number < Min)
                Min = number;
            if (number > Max)
                Max = number;
        }
    }
}
