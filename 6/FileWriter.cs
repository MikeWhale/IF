using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class FileWriter
    {

        public static int idfile = 0;

        public static void writeDictionary(Dictionary<string, List<int>> dict)
        {
            

            idfile++;
            Console.WriteLine("writing dictionary in file: " + idfile + ".txt ");
            StreamWriter sw = new StreamWriter("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/"+ idfile + ".txt");
            

            foreach (KeyValuePair<string, List<int>> entry in dict)
            {
                sw.WriteLine(entry.Key+" "+string.Join(" ",entry.Value));
            }

            sw.Close();

            GC.Collect();

        }


        public static void serializeDictionary(Dictionary<string, List<int>> dict)
        {


            Console.WriteLine("writing dictionary in file: " + 1 + ".s ");
            FileStream sw = new FileStream("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/" + 1 + ".s",FileMode.Create,FileAccess.Write,FileShare.ReadWrite);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(sw,dict);

            sw.Close();

            GC.Collect();

        }

        public static void serializeCompressedDictionary(ItemOfDict[] coll)
        {


            Console.WriteLine("writing dictionary in file: " + 1 + ".s ");
            FileStream sw = new FileStream("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/" + 1 + ".s", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(sw, coll);

            sw.Close();

            GC.Collect();

            Console.WriteLine("writing dictionary in file: words.s ");
            sw = new FileStream("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/words.s", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            bf = new BinaryFormatter();
            bf.Serialize(sw, ItemOfDict.ALL_DICTIONARY);

            sw.Close();

            GC.Collect();

            Console.WriteLine("writing dictionary in file: index.s ");
            sw = new FileStream("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/index.s", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            bf = new BinaryFormatter();
            bf.Serialize(sw, ItemOfDict.ALL_INDEX);

            sw.Close();

            GC.Collect();

        }



        public static Dictionary<string, List<int>> deserializeDictionary()
        {

            Dictionary<string, List<int>> dict;

            FileStream fs = new FileStream("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/temp/" + 1 + ".s",FileMode.Open,FileAccess.Read,FileShare.Read);

            BinaryFormatter bf = new BinaryFormatter();


            dict = (Dictionary<string, List<int>>)bf.Deserialize(fs);

            fs.Close();

            return dict;
        }



    }
}
