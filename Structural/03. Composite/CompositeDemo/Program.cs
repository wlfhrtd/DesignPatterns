using CompositeDemo.FileSystem;
using CompositeDemo.FileSystem.Models;
using CompositeDemo.InDotnet;
using CompositeDemo.Structural;
using System;
using System.Xml.Linq;

namespace CompositeDemo
{
    class Program
    {
        // client
        static void Main(string[] args)
        {
            Structural();
            FileSystemExample();
            FileSystemCompositeBuilder();
            DotnetExample();
        }

        private static void DotnetExample()
        {
            XElement xmlDoc = XElement.Load("InDotnet/file-system.xml");

            foreach (var leaf in xmlDoc.FindElements(e => !e.HasElements))
            {
                Console.WriteLine($"--> Leaf: {leaf.Attribute("name")}, {leaf.Attribute("fileBytes")}");
            }
        }

        private static void FileSystemCompositeBuilder()
        {
            FileSystemBuilder builder = new("development");
            builder.AddDirectory("project1");
            builder.AddFile("pr1f1.txt", 2048);
            builder.AddFile("pr1f2.txt", 3072);

            builder.AddDirectory("sub-dir");
            builder.AddFile("pr1f3.txt", 4096);
            builder.AddFile("pr1f4.txt", 5120);

            builder.SetCurrentDirectory("development");
            builder.AddDirectory("project2");
            builder.AddFile("pr2f1.txt", 6144);
            builder.AddFile("pr2f2.txt", 7168);

            builder.Print();
        }

        private static void FileSystemExample()
        {
            DirectoryItem root = new("development");
            DirectoryItem project1 = new("project1");
            DirectoryItem project2 = new("project2");
            root.Add(project1);
            root.Add(project2);

            project1.Add(new FileItem("pr1f1.txt", 2048));
            project1.Add(new FileItem("pr1f2.txt", 3072));

            DirectoryItem subDir1 = new("sub-dir1");
            subDir1.Add(new FileItem("pr1f3.txt", 4096));
            subDir1.Add(new FileItem("pr1f4.txt", 5120));

            project1.Add(subDir1);

            project2.Add(new FileItem("pr2f1.txt", 6144));
            project2.Add(new FileItem("pr2f2.txt", 7168));

            Console.WriteLine($"Total size (project2): {project2.GetSizeInKB()}");
            Console.WriteLine($"Total size (project1): {project1.GetSizeInKB()}");
            Console.WriteLine($"Total size (root): {root.GetSizeInKB()}");
        }

        private static void Structural()
        {
            // Composite in Composite pattern is element of tree structure
            Composite root = new("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite c1 = new("Composite C1");
            c1.Add(new Leaf("Leaf C1-A"));
            c1.Add(new Leaf("Leaf C1-B"));
            Composite c2 = new("Composite C2");
            c2.Add(new Leaf("Leaf C2-A"));

            c1.Add(c2);

            root.Add(c1);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // recursive print
            root.PrimaryOperation(1);
            System.Console.WriteLine();
            c2.PrimaryOperation(1);
        }
    }
}
