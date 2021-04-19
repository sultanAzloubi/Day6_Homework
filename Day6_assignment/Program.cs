using System;
using System.Collections.Generic;

namespace Day6_assignment
{
    class HTMLLikeBuilder
    {
        private string html;
        public HTMLLikeBuilder()
        {
            this.html = "";
        }

        public HTMLLikeBuilder beginTag(string value, int spacing = 0)
        {
            string space = "";
            for (int i = 0; i < spacing; i++)
            {
                space += " ";
            }
            this.html +=  space + "<" + value + ">\n";

            return this;
        }

        public HTMLLikeBuilder setContent(string value)
        {
            this.html += value;

            return this;
        }

        public HTMLLikeBuilder endTag(string value, int spacing = 0)
        {
            string space = "";
            for(int i = 0; i < spacing; i++)
            {
                space += " ";
            }
            this.html += "\n" + space + "</" + value + ">";

            return this;
        }

        public string getHTML()
        {
            return this.html;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HTMLLikeBuilder htmlB = new HTMLLikeBuilder();
            htmlB.beginTag("Heading")
                    .beginTag("Division",3)
                        .setContent("      This is a Division.")
                    .endTag("Division",3)
                    .setContent("\n")
                    .beginTag("Division", 3)
                        .setContent("      This is another Division.")
                    .endTag("Division", 3)
                 .endTag("Heading");

            Console.WriteLine(htmlB.getHTML());


        }

        static bool CheckOrder(string source)
        {
            var array = source.Split(" ");
            Stack<char> st = new Stack<char>();
            bool isOrdered = false;

            if(source.Length == 0 || source == null)
            {
                return isOrdered;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if(st.Count == 0 || source[i] != st.Peek())
                {
                    st.Push(source[i]);
                }
                else
                {
                    st.Pop();
                }
            }

            if(st.Count == 0)
            {
                isOrdered = true;
            }

            return isOrdered;
        }
    }
}
