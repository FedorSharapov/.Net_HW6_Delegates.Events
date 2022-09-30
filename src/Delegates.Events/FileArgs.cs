namespace Delegates.Events
{
    internal class FileArgs
    {
        public string Name { get; private set; }

        public long Length { get; private set; }

        public FileArgs(string name, long length)
        {
            Name = name;
            Length = length;
        }
    }
}
