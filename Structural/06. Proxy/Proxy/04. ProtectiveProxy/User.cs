using System.Collections.Generic;

namespace Proxy._04._ProtectiveProxy
{
    public class User
    {
        public string Name { get; set; }

        public Roles Role { get; set; }

        public List<Document> AuthoredDocuments { get; } = new();

        public void AddDocument(string documentName, string documentContent)
        {
            var document = Document.CreateDocument(documentName, documentContent);
            AuthoredDocuments.Add(document);
        }
    }
}
