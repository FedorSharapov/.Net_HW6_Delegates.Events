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
            ConsoleHelper.WriteLine($"Максимальное значение: [{max}]\r\n");

            // Обнаружение файлов в каталоге
            var fileDetector = new FileDetector();
            fileDetector.FileFound += FileDetector_FileFound;
            fileDetector.StoppedDetection += FileDetector_StoppedDetection;

            Console.WriteLine($"Директория: {fileDetector.Path}");
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