namespace Delegates.Events
{
    internal class FileDetector
    {
        public event EventHandler<FileArgs>? FileFound;

        private string _path;

        public string Path => _path;

        public FileDetector()
        {
            _path = Directory.GetCurrentDirectory();
        }

        public FileDetector(string pathDirectory)
        {
            _path = pathDirectory;
        }

        public void Detect()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles(); //Directory.EnumerateFiles(_path);

            foreach (var file in files)
            {
                FileFound?.Invoke(this, new FileArgs(file.Name));
            }
        }
    }
}
