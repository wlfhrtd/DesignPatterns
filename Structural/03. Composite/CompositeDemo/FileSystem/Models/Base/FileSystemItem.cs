namespace CompositeDemo.FileSystem.Models.Base
{
    public abstract class FileSystemItem
    {
        public string Name { get; }

        protected FileSystemItem(string name)
        {
            Name = name;
        }


        public abstract decimal GetSizeInKB();
    }
}
