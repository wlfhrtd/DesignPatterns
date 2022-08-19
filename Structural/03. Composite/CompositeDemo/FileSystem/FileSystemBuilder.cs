using CompositeDemo.FileSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDemo.FileSystem
{
    public class FileSystemBuilder
    {
        private DirectoryItem currentDirectory;
        public DirectoryItem Root { get; }

        public FileSystemBuilder(string rootDir)
        {
            Root = new DirectoryItem(rootDir);
            currentDirectory = Root;
        }


        public DirectoryItem AddDirectory(string name)
        {
            DirectoryItem dir = new(name);
            currentDirectory.Add(dir);
            currentDirectory = dir;

            return dir;
        }

        public FileItem AddFile(string name, long fileBytes)
        {
            FileItem file = new(name, fileBytes);
            currentDirectory.Add(file);

            return file;
        }

        public DirectoryItem SetCurrentDirectory(string dirName)
        {
            Stack<DirectoryItem> dirStack = new();
            dirStack.Push(Root);
            while (dirStack.Any())
            {
                DirectoryItem current = dirStack.Pop();

                if (current.Name == dirName)
                {
                    currentDirectory = current;
                    return current;
                }

                foreach (var item in current.Items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }

            throw new InvalidOperationException($"Directory '{dirName}' not found.");
        }

        public void Print()
        {
            Console.WriteLine($"Total size (root): {Root.GetSizeInKB()}");
            Console.WriteLine(JsonConvert.SerializeObject(Root, Formatting.Indented));
        }
    }
}
