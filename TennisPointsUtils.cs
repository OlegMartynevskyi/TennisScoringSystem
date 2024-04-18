namespace TennisScoringSystem
{
    internal static class TennisPointsUtils
    {
        private static Dictionary<int, string> _points = new()
        {
            { 0, "0" },
            { 1, "15" },
            { 2, "30" },
            { 3, "40" },
        };

        /// <summary>
        /// Converts to tennis points
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTennisPoints(this int value)
        {
            var result = Math.Clamp(value, 0, 3);
            return _points[result];
        }
    }
}
