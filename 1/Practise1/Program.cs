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

            string[] dict = fr.GetDictionary();

            FileWriter.WriteArray(dict);

        }

    }















}
