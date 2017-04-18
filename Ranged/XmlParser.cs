using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace Practise1
{
    class XmlParser
    {

        
        private NotPreparedDoc[] allWords;
        private Doc[] dict;


        public XmlParser()
        {

            allWords = ReadAllFiles();
            dict = Dictionary(allWords);
        }



        public Doc[] GetDictionary()
        {

            return dict;
        } 


        private NotPreparedDoc[] ReadAllFiles()
        {

            string[] Files = System.IO.Directory.GetFiles("D:/Users/USER/Documents/Visual Studio 2015/Projects/Practise1/Practise1/files");

            NotPreparedDoc[] notPrepDocs = new NotPreparedDoc[Files.Length];
           

            for(int i=0;i<Files.Length;i++)
            {
                

                string auth = "";
                string titl = "";
                string body = "";

                XmlDocument doc = new XmlDocument();
                doc.Load(Files[i]);

               
                XmlNodeList elemList = doc.GetElementsByTagName("book-title");
                for (int j = 0; j < elemList.Count; j++)
                {
                   titl+= elemList[j].InnerXml;
                }

                XmlNodeList elemLis = doc.GetElementsByTagName("first-name");
                for (int j = 0; j < elemLis.Count; j++)
                {
                    auth += elemLis[j].InnerXml;
                    auth += " ";
                }

                XmlNodeList elemLi = doc.GetElementsByTagName("last-name");
                for (int j = 0; j < elemLi.Count; j++)
                {
                    auth += elemLi[j].InnerXml;
                    auth += " ";
                }

                XmlNodeList elemL = doc.GetElementsByTagName("body");
                for (int j = 0; j < elemL.Count; j++)
                {
                    body += elemL[j].InnerText;
                    body += " ";
           
                }

                notPrepDocs[i] = new NotPreparedDoc(auth,titl,body);


            }




            return notPrepDocs;
        }





        private Doc[] Dictionary(NotPreparedDoc[] collectionFromFiles)
        {

            for(int i=0;i<collectionFromFiles.Length;i++)
            {
                collectionFromFiles[i].Author = collectionFromFiles[i].Author.ToLower();
                collectionFromFiles[i].Title = collectionFromFiles[i].Title.ToLower();
                collectionFromFiles[i].Body = collectionFromFiles[i].Body.ToLower();

            }


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

            Doc[] collectionsFromFiles = new Doc[collectionFromFiles.Length];

            for (short i = 0; i < collectionsFromFiles.Length; i++)
            {
                string[] author = collectionFromFiles[i].Author.Split(separator, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                string[] title = collectionFromFiles[i].Title.Split(separator, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                string[] body = collectionFromFiles[i].Body.Split(separator, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();

                collectionsFromFiles[i] = new Doc(author,title,body);
            }


            return collectionsFromFiles;
        }

    }
}
