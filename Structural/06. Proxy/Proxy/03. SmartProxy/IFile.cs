using System.IO;

namespace Proxy._03._SmartProxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
