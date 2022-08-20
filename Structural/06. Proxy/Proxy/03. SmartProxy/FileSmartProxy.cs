using System.Collections.Generic;
using System.IO;

namespace Proxy._03._SmartProxy
{
    public class FileSmartProxy : IFile
    {
        Dictionary<string, FileStream> openStreams = new();

        public FileStream OpenWrite(string path)
        {
            try
            {
                var stream = File.OpenWrite(path);
                openStreams.Add(path, stream);

                return stream;
            }
            catch (IOException)
            {
                if (openStreams.ContainsKey(path))
                {
                    var stream = openStreams[path];

                    if (stream != null && stream.CanWrite)
                    {
                        return stream;
                    }

                }
                throw;
            }
        }
    }
}
