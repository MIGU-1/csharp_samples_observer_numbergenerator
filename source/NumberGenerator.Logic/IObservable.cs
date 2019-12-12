namespace NumberGenerator.Logic
{
    public interface IObservable
    {
        public delegate void NextNumberHandler(int number);

        public NextNumberHandler NumberHandler { get; set; }
    }
}