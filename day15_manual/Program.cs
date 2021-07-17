using System;

namespace weeks2.day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = "age = 28";
            System.IO.StringReader reader = new System.IO.StringReader(line);
            var laxer = new Laxer(reader);

            for (string token = null; (token = laxer.Read()) != null;)
            {
                Console.WriteLine(token);
            }
        }
    }
}
