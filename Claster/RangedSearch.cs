using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{

    class Weight : IComparable<Weight>
    {
        public float weight;
        public int docId;

        public Weight(float weight,int docId)
        {
            this.weight = weight;
            this.docId = docId;

        }

        public int CompareTo(Weight other)
        {

            return this.weight.CompareTo(other.weight);

            throw new NotImplementedException();
        }

    }


    class RangedSearch
    {


        public const float TITLE = 0.3f;
        public const float AUTHOR = 0.2f;
        public const float BODY = 0.5f;



        public static List<Weight> RangedDocs (Dictionary<string, Node> dict)
        {
            List<Weight> TOP = new List<Weight>();

            Console.WriteLine("input search string: ");

            string searched = Console.ReadLine();

            string[] search = searched.Split(' ');


            List<Node> invert = new List<Node>();

            for(int i=0;i<search.Length;i++)
            {
                if(dict.ContainsKey(search[i]))
                invert.Add(dict[search[i]]);
            }



            List<short> authors = invert[0].author;
            List<short> titles = invert[0].title;
            List<short> bodys = invert[0].body;



            for (int i=1;i<invert.Count;i++)
            {
                authors = authors.Intersect(invert[i].author).ToList();
                titles = titles.Intersect(invert[i].title).ToList();
                bodys = bodys.Intersect(invert[i].body).ToList();
            }




            for (int i=0;i<authors.Count;i++)
            {
                float allGrade = 0.0f;

                bool IsContains = false;
                for (int c = 0; c < TOP.Count; c++)
                    if (TOP[c].docId == authors[i])
                        IsContains = true;

                if (!IsContains)
                {
                    allGrade += AUTHOR;
                    if (titles.Contains(authors[i]))
                    {
                        allGrade += TITLE;
                    }
                    if (bodys.Contains(authors[i]))
                    {
                        allGrade += BODY;
                    }
                    TOP.Add(new Weight(allGrade,authors[i]));
                }
            }




            for (int i = 0; i < titles.Count; i++)
            {
                float allGrade = 0.0f;

                bool IsContains = false;
                for (int c = 0; c < TOP.Count; c++)
                    if (TOP[c].docId == titles[i])
                        IsContains = true;

                if (!IsContains)
                {
                    allGrade += TITLE;
                    if (authors.Contains(titles[i]))
                    {
                        allGrade += AUTHOR;
                    }
                    if (bodys.Contains(titles[i]))
                    {
                        allGrade += BODY;
                    }
                    TOP.Add(new Weight(allGrade, titles[i]));
                }
            }




            for (int i = 0; i < bodys.Count; i++)
            {
                float allGrade = 0.0f;

                bool IsContains = false;
                for (int c = 0; c < TOP.Count; c++)
                    if (TOP[c].docId == bodys[i])
                        IsContains = true;

                if (!IsContains)
                {
                    allGrade += BODY;
                    if (titles.Contains(bodys[i]))
                    {
                        allGrade += TITLE;
                    }
                    if (authors.Contains(bodys[i]))
                    {
                        allGrade += BODY;
                    }
                    TOP.Add(new Weight(allGrade, bodys[i]));
                }
            }


            TOP.Sort();

            return TOP;
        }



    }
}
