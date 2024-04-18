namespace TennisScoringSystem
{
    internal class GameResult
    {
        public int ServerGame { get; private set; }
        public int ReceiverGame { get; private set; }

        public GameResult(int serverGame, int receiverGame)
        {
            ServerGame = serverGame;
            ReceiverGame = receiverGame;
        }

        public override string ToString()
        {
            return $"{ServerGame} - {ReceiverGame}";
        }
    }
}
