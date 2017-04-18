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

            List<Weight> w = RangedSearch.RangedDocs(dicti);


            for(int i=0;i<w.Count;i++)
            {
                Console.WriteLine(" doc ID: "+w[i].docId+", weight: "+w[i].weight);

            }

            Console.WriteLine("Done!");


            Console.ReadKey();
        }

    }


}
