namespace TennisScoringSystem
{
    internal class Player : IPlayer
    {
        public string Name { get; private set; }
        public event Action<IPlayer>? GetScorePoint;

        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Each time the button is pressed, an event is raised to update the game score.
        /// </summary>
        public void AddPoint()
        {
            GetScorePoint?.Invoke(this);
        }
    }
}
