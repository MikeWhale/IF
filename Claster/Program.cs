using System;
using System.Collections.Generic;

namespace Practise1
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlParser xmlp = new XmlParser();

            Doc[] dic = xmlp.GetDictionary();

            Dictionary<string, Node> dicti = InvertIndex.Invert(dic);

            Claster[] clasters = new Clasterization(dic).GetClasters();

            Console.WriteLine("Done!");


            Console.ReadKey();
        }

    }


}
