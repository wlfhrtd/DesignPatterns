using System.IO;
using System.Text;
using Xunit;

namespace Proxy._03._SmartProxy.Tests
{
    public class FileConcurrentWrites
    {
        private readonly string testFile = "output.txt";

        [Fact]
        public void RaisesExceptionWithDirectFileAccess()
        {
            var fs = new DefaultFile();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. example\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. another_example\n");

            using var file = fs.OpenWrite(testFile);

            Assert.Throws<IOException>(() =>
                //var file2 = fs.OpenWrite(testFile)); can't run this code
                fs.OpenWrite(testFile));

            file.Write(outputBytes1);
            //file2.Write(outputBytes2); // we never get here

            file.Close();
            //file2.Close(); // we never get here
        }

        [Fact]
        public void ManageReferences()
        {
            var fs = new FileSmartProxy();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. example\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. another_example\n");
            // proxy returns same stream instance on each call so it works
            using var file = fs.OpenWrite(testFile);
            using var file2 = fs.OpenWrite(testFile);

            file.Write(outputBytes1);
            file2.Write(outputBytes2);

            file.Close();
            file2.Close();
        }
    }
}
