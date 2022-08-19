using CompositeDemo.FileSystem.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDemo.FileSystem.Models
{
    public class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Items { get; }

        public DirectoryItem(string name) : base(name)
        {
            Items = new();
        }


        public void Add(FileSystemItem component)
            => Items.Add(component);

        public void Remove(FileSystemItem component)
            => Items.Remove(component);

        public override decimal GetSizeInKB()
            => Items.Sum(i => i.GetSizeInKB());
    }
}
