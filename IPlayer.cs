namespace TennisScoringSystem
{
    internal interface IPlayer
    {
        event Action<IPlayer> GetScorePoint;
    }
}
