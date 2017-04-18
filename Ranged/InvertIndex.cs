using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{

    class Node
    {

       public  List<short> title;
        public List<short> author;
        public List<short> body;

        public Node()
        {
            this.author = new List<short>();
            this.title = new List<short>();
            this.body = new List<short>();

        }

    }



    class InvertIndex
    {


        public static Dictionary<string,Node> Invert(Doc[] dictionary)
        {

            Dictionary<string, Node> invertInd = new Dictionary<string, Node>();


            for(int i=0;i<dictionary.Length;i++)
            {

                /////////////////////  inverting author

                for(int a=0;a<dictionary[i].GetAuthor().Length;a++)
                {
                    if (invertInd.ContainsKey(dictionary[i].GetAuthor()[a]))
                    {
                        if(invertInd[dictionary[i].GetAuthor()[a]]!=null)
                        {
                            invertInd[dictionary[i].GetAuthor()[a]].author.Add((short)i);

                        }
                        else
                        {
                            invertInd[dictionary[i].GetAuthor()[a]] = new Node();
                            invertInd[dictionary[i].GetAuthor()[a]].author.Add((short)i);
                        }


                    }
                    else
                    {
                        invertInd.Add(dictionary[i].GetAuthor()[a],new Node());
                        invertInd[dictionary[i].GetAuthor()[a]].author.Add((short) i);

                    }


                }

                ///////////////////// inverting title

                for (int a = 0; a < dictionary[i].GetTitle().Length; a++)
                {
                    if (invertInd.ContainsKey(dictionary[i].GetTitle()[a]))
                    {
                        if (invertInd[dictionary[i].GetTitle()[a]] != null)
                        {
                            invertInd[dictionary[i].GetTitle()[a]].title.Add((short)i);

                        }
                        else
                        {
                            invertInd[dictionary[i].GetTitle()[a]] = new Node();
                            invertInd[dictionary[i].GetTitle()[a]].title.Add((short)i);
                        }


                    }
                    else
                    {
                        invertInd.Add(dictionary[i].GetTitle()[a], new Node());
                        invertInd[dictionary[i].GetTitle()[a]].title.Add((short)i);

                    }


                }


                ///////////////////// inverting body

                for (int a = 0; a < dictionary[i].GetBody().Length; a++)
                {
                    if (invertInd.ContainsKey(dictionary[i].GetBody()[a]))
                    {
                        if (invertInd[dictionary[i].GetBody()[a]] != null)
                        {
                            invertInd[dictionary[i].GetBody()[a]].body.Add((short)i);

                        }
                        else
                        {
                            invertInd[dictionary[i].GetBody()[a]] = new Node();
                            invertInd[dictionary[i].GetBody()[a]].body.Add((short)i);
                        }


                    }
                    else
                    {
                        invertInd.Add(dictionary[i].GetBody()[a], new Node());
                        invertInd[dictionary[i].GetBody()[a]].body.Add((short)i);

                    }


                }


            }

            return invertInd;
        }
    }
}
