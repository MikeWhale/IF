using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Practise1
{
    class FileReader
    {

        private HashSet<string>[] dictionary;
        private List<string>[] twoWordsDictionary;
        private string[] allWords;



        public FileReader()
        {

             allWords = ReadAllFiles();

            for(short i=0;i<allWords.Length;i++)
             allWords[i]=allWords[i].ToLower();

        }


        public HashSet<string>[] GetDictionary()
        {
            dictionary = Dictionary(allWords);

            return dictionary;
        }


        public List<string>[] GetAllWordsDocs()
        {
            twoWordsDictionary = AllWords(allWords);

            return twoWordsDictionary;
        }





        private string[] ReadAllFiles()
        {

            string[] Files = System.IO.Directory.GetFiles("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/files");


            string[] AllBooksInStrings = new string[Files.Length];

            short fileID = 0;
            foreach (string s in Files)
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        AllBooksInStrings[fileID]=sr.ReadToEnd();
                        fileID++;
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found");
                }
            }


            return AllBooksInStrings;
        }





        private HashSet<string>[] Dictionary(string[] collectionFromFiles)
        {

            char[] separator = new char[31];

            separator[0] = ';';
            separator[1] = ' ';
            separator[2] = '.';
            separator[3] = ',';
            separator[4] = ':';
            separator[5] = '(';
            separator[6] = ')';
            separator[7] = '—';
            separator[8] = '-';
            separator[9] = '!';
            separator[10] = '?';
            separator[11] = '"';
            separator[12] = '*';
            separator[13] = '…';
            separator[14] = '«';
            separator[15] = '»';
            separator[16] = '„';
            separator[17] = '“';
            separator[18] = '–';
            separator[19] = '\r';
            separator[20] = '\n';
            separator[21] = '$';
            separator[22] = '%';
            separator[23] = '=';
            separator[24] = '[';
            separator[25] = ']';
            separator[26] = '+';
            separator[27] = '/';
            separator[28] = '~';
            separator[29] = '>';
            separator[30] = '<';
            
            HashSet<string>[] collectionsFromFiles = new HashSet<string>[collectionFromFiles.Length]; 

            for(short i=0;i<collectionFromFiles.Length;i++)
            {
                var result = collectionFromFiles[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                
                for (int j=0;j<result.Length;j++)
                {
                   result[j]= result[j].Trim();
                }

                
                collectionsFromFiles[i] = new HashSet<string>(result);

            }



            return  collectionsFromFiles;
        }



        private List<string>[] AllWords(string[] collectionFromFiles)
        {

            char[] separator = new char[31];

            separator[0] = ';';
            separator[1] = ' ';
            separator[2] = '.';
            separator[3] = ',';
            separator[4] = ':';
            separator[5] = '(';
            separator[6] = ')';
            separator[7] = '—';
            separator[8] = '-';
            separator[9] = '!';
            separator[10] = '?';
            separator[11] = '"';
            separator[12] = '*';
            separator[13] = '…';
            separator[14] = '«';
            separator[15] = '»';
            separator[16] = '„';
            separator[17] = '“';
            separator[18] = '–';
            separator[19] = '\r';
            separator[20] = '\n';
            separator[21] = '$';
            separator[22] = '%';
            separator[23] = '=';
            separator[24] = '[';
            separator[25] = ']';
            separator[26] = '+';
            separator[27] = '/';
            separator[28] = '~';
            separator[29] = '>';
            separator[30] = '<';

            List<string>[] collectionsFromFiles = new List<string>[collectionFromFiles.Length];

            for (short i = 0; i < collectionFromFiles.Length; i++)
            {
                var result = collectionFromFiles[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < result.Length; j++)
                {
                    result[j] = result[j].Trim();
                }


                collectionsFromFiles[i] = new List<string>(result);

            }



            return collectionsFromFiles;

        }






        }
}

