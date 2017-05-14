using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Practise1
{
    class FileCompresser
    {
       
        private const string PATH = "D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/files";
        private static int PATH_LENGTH = PATH.Length;


        Dictionary<string, List<int>> beforeCompressing;


        public ItemOfDict[] pastCompression;


             
        public FileCompresser()
        {

            beforeCompressing = FileWriter.deserializeDictionary();

            Console.WriteLine("Have just read collection");

            pastCompression = new ItemOfDict[beforeCompressing.Count];


            compressAll();

            FileWriter.serializeCompressedDictionary(pastCompression);
        }






        public void compressAll()
        {
            int iterOnCollection = 0;   // for position on pastCompression

            foreach(string s in beforeCompressing.Keys)
            {

                int indNum = 0;

                ItemOfDict.ALL_DICTIONARY.Append(s);

                StringBuilder tempS = new StringBuilder();

                indNum += beforeCompressing[s][0];

                tempS.Append(indNum+" ");

                for (int i=1;i< beforeCompressing[s].Count;i++)
                {
                    
                    tempS.Append((beforeCompressing[s][i]-indNum) +" ");
                    indNum = beforeCompressing[s][i];
                }

                ItemOfDict.ALL_INDEX.Append(tempS);

                pastCompression[iterOnCollection] = new ItemOfDict((ItemOfDict.ALL_DICTIONARY.Length-s.Length), (short)s.Length,(ItemOfDict.ALL_INDEX.Length-tempS.Length), (short)tempS.Length);

                iterOnCollection++;

            }



        }




    }
}

