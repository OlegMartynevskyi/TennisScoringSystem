namespace TennisScoringSystem
{
    internal class Program
    {
        private static Player? _playerA;
        private static Player? _playerB;
        private static TennisScoringView? _tennisScoringView;

        static void Main(string[] args)
        {
            _playerA = new Player("A");
            _playerB = new Player("B");
            var tennisScoring = new TennisScoring(_playerA, _playerB);

            _tennisScoringView = new TennisScoringView();
            //binding win buttons to players
            _tennisScoringView.playerAWinBtn.Click += _playerA.AddPoint;
            _tennisScoringView.playerBWinBtn.Click += _playerB.AddPoint;
            tennisScoring.Update += OnTennisScoringUpdate;
        }

        /// <summary>
        /// Every time the game score is updated, the game score view is updated too
        /// </summary>
        /// <param name="tennisScoring"></param>
        private static void OnTennisScoringUpdate(TennisScoring tennisScoring)
        {
            var playerAScore = tennisScoring.GetPlayerPoints(_playerA);
            var playerBScore = tennisScoring.GetPlayerPoints(_playerB);
            _tennisScoringView.CurrentSet = $"Current Set: {playerAScore.Game} - {playerBScore.Game}";
            _tennisScoringView.CurrentGame = $"Current game: {playerAScore.Points.ToTennisPoints()} - {playerBScore.Points.ToTennisPoints()}";
            _tennisScoringView.MatchScores = ToView(tennisScoring.gameResults);
        }

        private static List<string> ToView(IList<GameResult> gameResults)
        {
            var result = new List<string>(gameResults.Count);

            foreach (var gameResult in gameResults)
            {
                result.Add(gameResult.ToString());
            }

            return result;
        }
    }
}