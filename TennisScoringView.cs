namespace TennisScoringSystem
{
    internal class Button
    {
        public event Action Click;
    }

    internal class TennisScoringView
    {
        public Button playerAWinBtn;
        public Button playerBWinBtn;
        public string CurrentSet { get; set; }
        public string CurrentGame { get; set; }
        public List<string> MatchScores { get; set; }
    }
}
