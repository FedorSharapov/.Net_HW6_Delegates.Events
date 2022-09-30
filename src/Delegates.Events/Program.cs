using System.Diagnostics;

namespace Delegates.Events
{
    internal class Program
    {
        static float GenericToFloat<T>(T element) where T : class
        {
            return element.GetHashCode();
        }

        static void Main(string[] args)
        {
            // Поиск максимального значения
            var numbers = new string[] { "1,7", "1,2", "1,9", "1,3", "1,4", "1,0", "1,5", "1,1", "1,6", "1,8" };
            var max = numbers.GetMax(x => (float)Convert.ToDouble(x));
            Console.WriteLine($"Максимальное значение: {max}");



        }
    }
}