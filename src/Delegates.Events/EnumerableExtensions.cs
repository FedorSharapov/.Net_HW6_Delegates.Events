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
            
            return source.MaxBy(x => getParameter(x));
        }
    }
}
