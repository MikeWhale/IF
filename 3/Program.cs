using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// size of collection ~20MB
// number of words of collection ~1.7 millions of words
// size of dictionary 3.1MB


namespace Practise1
{
    class Program
    {
        static void Main(string[] args)
        {


            FileReader fr = new FileReader();

            List<string>[] dict = fr.GetAllWordsDocs();




            string[] twoWords = TwoWordsIndex.TwoWordsInd(dict);

            Dictionary <string, List<int>[]> wordData = CoordinateInvertIndex.CoordInvertIndex(dict);




            //Console.WriteLine("Is this word combination exist: "+ TwoWordsSearch.IsPhraseExist(twoWords));


            List<int>[] coordInvertIndex = CoordinateInvertSearch.CoordsOfPhraseInDict(wordData);




            Console.WriteLine("Done!");
           

       
        }

    }




}
