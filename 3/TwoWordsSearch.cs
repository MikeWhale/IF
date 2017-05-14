using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class TwoWordsSearch
    {



      public  static bool IsPhraseExist(string[] twoWords)
        {

            Array.Sort(twoWords);

            Console.WriteLine("Input 2-word phrase to check existence it in dictionary");

            return twoWords.Contains(Console.ReadLine());
        }

    }
}
