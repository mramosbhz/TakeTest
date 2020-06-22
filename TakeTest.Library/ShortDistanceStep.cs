namespace TakeTest.Library
{
    public class ShortDistanceStep
    {
        public int Distance { get; set; }
        public string Previous { get; set; }

        public ShortDistanceStep() { }

        public ShortDistanceStep(int distance, string previous)
        {
            this.Distance = distance;
            this.Previous = previous;
        }
    }
}