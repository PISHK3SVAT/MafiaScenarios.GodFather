namespace Endpoint.MVC.Models.Game
{
    public class DayViewModel
    {
        public List<DayPlayerViewModel> Players { get; set; } = new();
        public byte SpeakTime { get; set; }
        public byte DayOf { get; set; }
    }
    public class DayPlayerViewModel
    {
        public string Name { get; set; } = string.Empty;
        public byte IncomeVoteCount { get; set; }
        public bool CanHaveChallenge { get; set; } = true;
        public byte WarningCount { get; set; }

    }
}
