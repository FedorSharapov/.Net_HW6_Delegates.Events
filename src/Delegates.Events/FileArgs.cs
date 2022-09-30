namespace Delegates.Events
{
    internal class FileArgs
    {
        public string Name { get; private set; }

        public FileArgs(string name)
        {
            Name = name;
        }
    }
}
