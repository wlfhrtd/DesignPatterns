using CompositeDemo.FileSystem.Models.Base;

namespace CompositeDemo.FileSystem.Models
{
    public class FileItem : FileSystemItem
    {
        public long FileBytes { get; }

        public FileItem(string name, long fileBytes) : base(name)
        {
            FileBytes = fileBytes;
        }


        public override decimal GetSizeInKB()
            => decimal.Divide(FileBytes, 1024);
    }
}
