namespace ARPG.Shared
{
    static class StatePriorityExtensions
    {
        public static bool HasHigherPriorityThan(this StatePriority a, StatePriority b)
        {
            return a > b;
        }

        public static bool HasLowerPriorityThan(this StatePriority a, StatePriority b)
        {
            return a < b;
        }
    }

    public enum StatePriority
    {
        HIGHEST = 20,
        REGULAR = 0,
        LOWEST = -20,
    }
}
