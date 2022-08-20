using System.IO;

namespace Proxy._03._SmartProxy
{
    public class DefaultFile : IFile
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}
