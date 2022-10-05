namespace Delegates.Events
{
    public static class EnumerableExtensions
    {
        public static T? GetMax<T>(this IEnumerable<T> source, Func<T, float> getParameter) where T : class
        {
            if (source is null || !source.Any())
                throw new InvalidOperationException("Cannot compute maximum for a null or empty set.");
            else if(getParameter is null)
                throw new InvalidOperationException("Cannot compute maximum because delegate converting input type to number is null.");

            T? max = default;
            var min = float.MinValue;
            foreach (T s in source)
            { 
                var num = getParameter(s);
                if (num > min)
                {
                    max = s;
                    min = num;
                }
            }

            return max;

            //return source.MaxBy(x => getParameter(x));  // при 10 000 000 итераций медленее на 100 мс, чем e.MaxBy из-за использования IComparer<>.
        }
    }
}
