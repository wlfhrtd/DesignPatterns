using System;
using System.Collections.Generic;

namespace TemplateMethod.Components
{
    public class LoggerAdapter
    {
        private List<string> messages = new();

        public void Log(string message)
        {
            messages.Add(message);
        }

        public string Dump()
        {
            return string.Join(Environment.NewLine, messages);
        }

        public void Clear()
        {
            messages.Clear();
        }
    }
}
