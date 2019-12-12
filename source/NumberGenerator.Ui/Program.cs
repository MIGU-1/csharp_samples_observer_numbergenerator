
using NumberGenerator.Logic;
using System;

namespace NumberGenerator.Ui
{
    class Program
    {
        static void Main()
        {
            // Zufallszahlengenerator erstelltn
            RandomNumberGenerator numberGenerator = new RandomNumberGenerator(10);

            // Beobachter erstellen
            BaseObserver baseObserver = new BaseObserver(numberGenerator, 10);
            StatisticsObserver statisticsObserver = new StatisticsObserver(numberGenerator, 20);
            RangeObserver rangeObserver = new RangeObserver(numberGenerator, 5, 200, 300);
            QuickTippObserver quickTippObserver = new QuickTippObserver(numberGenerator);


            // Nummerngenerierung starten
            // Resultat ausgeben

            numberGenerator.StartNumberGeneration();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(statisticsObserver.ToString());
            Console.WriteLine(quickTippObserver.ToString());
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
