using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{


    class CoordinateInvertIndex
    {

        public static int CAPACITY;


        public static Dictionary<string,List<int>[]> CoordInvertIndex(List<string>[] collections)
        {

           CAPACITY = collections.Length;

           Dictionary<string, List<int>[]> allWords = new Dictionary<string, List<int>[]>();

            for(int i=0;i<collections.Length;i++)
            {

                for(int j=0;j<collections[i].Count;j++)
                {

                   

                        if (allWords.ContainsKey(collections[i][j]))
                        {
                        if(allWords[collections[i][j]][i]==null)
                        allWords[collections[i][j]][i] = new List<int>();
                        allWords[collections[i][j]][i].Add(j);
      
                        }
                        else
                        {
                        // Console.WriteLine(collections[i][j] + " " + i + " " + j);
                        allWords[collections[i][j]] = new List<int>[CAPACITY];
                        allWords[collections[i][j]][i] = new List<int>();
                        allWords[collections[i][j]][i].Add(j);
                    }
                    
                }
            }

            return allWords;

        }


        

    }
}
