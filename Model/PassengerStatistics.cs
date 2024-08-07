namespace Model
{
    public class PassengerStatistics
    {
        public int SurvivedCount { get; set; }
        public int DiedCount { get; set; }
        public Dictionary<int, int> ClassCount { get; set; }
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
        public double? AverageAge { get; set; }
    }
}
