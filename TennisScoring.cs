namespace TennisScoringSystem
{
    internal class TennisScoring
    {
        private Dictionary<IPlayer, PlayerPoints> _players = new Dictionary<IPlayer, PlayerPoints>();
        private readonly PlayerPoints _server = new PlayerPoints();
        private readonly PlayerPoints _receiver = new PlayerPoints();
        public readonly List<GameResult> gameResults = new List<GameResult>();

        public event Action<TennisScoring>? Update;

        public TennisScoring(IPlayer serverPlayer, IPlayer receiverPlayer)
        {
            _players.Add(serverPlayer, _server);
            _players.Add(receiverPlayer, _receiver);
            serverPlayer.GetScorePoint += OnGetScorePoint;
            receiverPlayer.GetScorePoint += OnGetScorePoint;
        }

        public PlayerPoints GetPlayerPoints(IPlayer player)
        {
            return _players[player];
        }

        private void OnGetScorePoint(IPlayer player)
        {
            _players[player].Points += 1;
            UpdateGameScore();
            Update?.Invoke(this);
        }

        private void UpdateGameScore()
        {
            if (_server.Points >= 4 || _receiver.Points >= 4)
            {
                if (Math.Abs(_server.Points - _receiver.Points) >= 2)
                {
                    if (_server.Points > _receiver.Points)
                    {
                        _server.Game += 1;
                    }
                    else
                    {
                        _receiver.Game += 1;
                    }

                    _server.Points = _receiver.Points = 0;
                    UpdateSetScore();
                }
            }
        }

        private void UpdateSetScore()
        {
            if (_server.Game >= 6 || _receiver.Game >= 6)
            {
                if (Math.Abs(_server.Game - _receiver.Game) >= 2)
                {
                    if (_server.Game > _receiver.Game)
                    {
                        _server.Set += 1;
                    }
                    else
                    {
                        _receiver.Set += 1;
                    }
                }

                gameResults.Add(new GameResult(_server.Game, _receiver.Game));
                _server.Game = _receiver.Game = 0;
                UpdateMatchScore();
            }
        }

        private void UpdateMatchScore()
        {
            if (_server.Set + _receiver.Set == 3)
            {
                if (_server.Set > _receiver.Set)
                {
                    _server.Match += 1;
                }
                else
                {
                    _receiver.Match += 1;
                }

                _server.Set = _receiver.Set = 0;
            }
        }
    }
}
