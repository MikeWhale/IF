using System;
using System.Linq;
using System.Text;


namespace Practise1
{
    class FileReader
    {

        private  string[] dictionary;

        public FileReader()
        {

             string allWords = ReadAllFiles();

             dictionary = Dictionary(allWords);

        }


        public string[] GetDictionary()
        {

            return dictionary;
        }



       private string ReadAllFiles()
        {
            string[] Files = System.IO.Directory.GetFiles("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/files");

            StringBuilder AllBooksInString = new StringBuilder();

            foreach (string s in Files)
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        AllBooksInString.Append(sr.ReadToEnd());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found");
                }
            }

            return AllBooksInString.ToString();
        }



        private string[] Dictionary(string AllWords)
        {
            char[] separator = new char[28];


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
            separator[12] = '1';
            separator[13] = '2';
            separator[14] = '3';
            separator[15] = '4';
            separator[16] = '5';
            separator[17] = '6';
            separator[18] = '7';
            separator[19] = '8';
            separator[20] = '9';
            separator[21] = '0';
            separator[22] = '*';
            separator[23] = '…';
            separator[24] = '«';
            separator[25] = '»';
            separator[26] = '„';
            separator[27] = '“';

            string[] result= AllWords.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return result.Distinct().ToArray();
        }


    }
}

