using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGenerator.Logic
{
    public class RangeObserver : BaseObserver
    {
        public int LowerRange { get; private set; }
        public int UpperRange { get; private set; }
        public int NumbersInRange { get; private set; }
        public int NumbersOfHitsToWaitFor { get; private set; }

        public RangeObserver(IObservable numberGenerator, int numberOfHitsToWaitFor, int lowerRange, int upperRange) : base(numberGenerator, int.MaxValue)
        {
            if (lowerRange > upperRange)
                throw new ArgumentException("Untergrenze > Obergrenze");

            NumbersInRange = 0;
            NumbersOfHitsToWaitFor = numberOfHitsToWaitFor;
            LowerRange = lowerRange;
            UpperRange = upperRange;
        }

        public override void OnNextNumber(object sender, int number)
        {
            base.OnNextNumber(sender, number);

            if (number >= LowerRange && number <= UpperRange)
                NumbersInRange++;

            Console.WriteLine(ToString());

            if (NumbersInRange >= NumbersOfHitsToWaitFor)
                base.DetachFromNumberGenerator();
        }
        public override string ToString()
        {
            return $"{base.ToString()} = {NumbersInRange}";
        }
    }
}
