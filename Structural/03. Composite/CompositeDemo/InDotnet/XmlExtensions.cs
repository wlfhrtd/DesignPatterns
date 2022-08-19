using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CompositeDemo.InDotnet
{
    public static class XmlExtensions
    {
        public static IEnumerable<XElement> FindElements(this XElement root, Predicate<XElement> predicate)
        {
            Stack<XElement> stack = new();
            stack.Push(root);

            while (stack.Any())
            {
                XElement current = stack.Pop();

                foreach (var element in current.Elements())
                {
                    stack.Push(element);
                }

                if (predicate(current))
                {
                    yield return current;
                }
            }
        }
    }
}
