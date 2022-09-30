namespace Delegates.Events
{
    internal class FileDetector
    {
        public event EventHandler<FileArgs>? FileFound;
        public event Action StoppedDetection;

        private string _path;
        private volatile bool _stopDetection;

        public string Path => _path;

        public FileDetector()
        {
            _path = Directory.GetCurrentDirectory();
            _stopDetection = false;
        }

        public FileDetector(string pathDirectory)
        {
            _path = pathDirectory;
            _stopDetection = false;
        }

        public void Detect()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();

            foreach (var file in files)
            {
                if (_stopDetection)
                {
                    StoppedDetection?.Invoke();
                    break;
                }

                FileFound?.Invoke(this, new FileArgs(file.Name, file.Length));
            }

            _stopDetection = false;
        }

        public void Stop()
        {
            _stopDetection = true;
        }

        public FileInfo? GetMaxLenthFile()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();
            return files.GetMax(x => x.Length);
        }

        public FileInfo? GetMaxLenthFileName()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();
            return files.GetMax(x => x.Name.Length);
        }
    }
}
