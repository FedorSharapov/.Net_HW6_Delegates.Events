using System.Diagnostics;

namespace Delegates.Events
{
    internal class Program
    {
        private static int count = 0;

        static void Main(string[] args)
        {
            // Поиск максимального значения
            var numbers = new string[] { "1,7", "1,2", "1,9", "1,3", "1,4", "1,0", "1,5", "1,1", "1,6", "1,8" };
            var max = numbers.GetMax(x => (float)Convert.ToDouble(x));
            ConsoleHelper.WriteLine($"Коллекция чисел: [{string.Join("; ", numbers)}]");
            ConsoleHelper.WriteLine($"Максимальное значение: [{max}]\r\n");

            // Поиск максимального значения
            var num = new string[10000000];
            long sum = 0;
            var rnd = new Random();
            var stopwatch = new Stopwatch();

            ConsoleHelper.WriteLine($"Поиск максимального значения в коллекции размером {num.Length}");

            for (int i = 0; i < num.Length; i++)
                num[i] = rnd.Next(1,1000).ToString();

            for (int i = 0; i < 10; i++)
            {
                stopwatch.Restart();
                max = num.GetMax(x => Convert.ToInt32(x));
                stopwatch.Stop();

                sum += stopwatch.ElapsedMilliseconds;
                ConsoleHelper.WriteLine($"Максимальное значение: [{max}]. Время выполнения: [{stopwatch.ElapsedMilliseconds}] мс");
            }
            ConsoleHelper.WriteLine($"Среднее время выполнения: [{sum/10}] мс\r\n");

            // Обнаружение файлов в каталоге
            string path = Directory.GetCurrentDirectory();
            var fileDetector = new FileDetector(path);
            fileDetector.FileFound += FileDetector_FileFound;
            fileDetector.StoppedDetection += FileDetector_StoppedDetection;

            Console.WriteLine($"Директория: {path}");
            fileDetector.Detect();

            // Поиск максимальных значений
            var file = fileDetector.GetMaxLenthFile();
            ConsoleHelper.WriteLine($"Самый большой файл: [{file.Name}]  {file.Length / 1024} КБ");

            file = fileDetector.GetMaxLenthFileName();
            ConsoleHelper.WriteLine($"Самое длинное имя файла: [{file.Name}]  {file.Name.Length} симв.");

            fileDetector.FileFound -= FileDetector_FileFound;
            fileDetector.StoppedDetection -= FileDetector_StoppedDetection;
            Console.ReadKey();
        }

        private static void FileDetector_FileFound(object? sender, FileArgs e)
        {
            ConsoleHelper.WriteLine($"{++count}. [{e.Name}]  {e.Length / 1024} КБ");

            if (count == 4)
            {
                var fileDetector = sender as FileDetector;
                fileDetector?.Stop();
            }
        }
        
        private static void FileDetector_StoppedDetection()
        {
            Console.WriteLine("Обнаружение файлов остановлено.\r\n");
        }
    }
}