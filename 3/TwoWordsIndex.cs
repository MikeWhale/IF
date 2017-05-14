using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class TwoWordsIndex
    {


        public static string[] TwoWordsInd(List<string>[] collections)
        {

            List<string> index = new List<string>();

            for(int i=0;i<collections.Length;i++)
            {


                for (int j = 0; j < collections[i].Count - 1; j++)
                {

                    index.Add(collections[i][j]+" "+ collections[i][j+1]);

                }
            }
            
            
            return index.Distinct().ToArray();
      }





        }






    }

