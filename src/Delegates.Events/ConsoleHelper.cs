using System.Text.RegularExpressions;

namespace Delegates.Events
{
    internal static class ConsoleHelper
    {
        // usage: WriteLine("This is my [message] with inline [color] changes.", ConsoleColor.Yellow);
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.Yellow)
        {
            var pieces = Regex.Split(message, @"(\[[^\]]*\])");

            foreach (var piece in pieces)
            {
                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    Console.Write(piece.ToArray(), 1, piece.Length - 2);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.Write(piece);
            }

            Console.WriteLine();
        }
    }
}
