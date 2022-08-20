using System;
using System.Collections.Generic;

namespace Proxy._04._ProtectiveProxy
{
    public class Document
    {
        protected Document(string name, string content)
        {
            Name = name;
            Content = content;
            DateCreated = DateTime.UtcNow;
        }


        public static Document CreateDocument(string name, string content)
        {
            // Factory Method - protected constructor and this method - 
            // enforces usage of Protective Proxy containing rules and logic
            return new ProtectedDocument(name, content);
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<string> Tags { get; private set; }

        public string Content { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime? DateReviewed { get; private set; }

        internal virtual void CompleteReview(User editor)
        {
            DateReviewed = DateTime.UtcNow;
        }

        internal virtual void UpdateName(string newName, User user)
        {
            Name = newName;
        }
    }
}
