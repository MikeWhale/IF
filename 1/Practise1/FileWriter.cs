using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class FileWriter
    {
        public static void WriteArray(string[] Dictionary)
        {
            StreamWriter sw = new StreamWriter("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/Output dictionary/dict.txt");
            foreach(string s in Dictionary)
            {
                sw.Write(s + " ");
            }
            sw.Close();

        }
    }

}
