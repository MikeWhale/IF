using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class CoordinateInvertSearch
    {

        public static List<int>[] CoordsOfPhraseInDict(Dictionary<string, List<int>[]> wordData)
        {

            List<int>[] intersections = new List<int>[CoordinateInvertIndex.CAPACITY];

            Console.WriteLine("Input words separated by ' ' and number of neighborhood words such as 'school 3 education'");

            string[] patterns = Console.ReadLine().Split(' ');


            if(!checkExistance(wordData,patterns))
            {
                Console.WriteLine("one or some words aren't exist");
                CoordsOfPhraseInDict(wordData);
            }




            for(int i=0; i<intersections.Length;i++)
            {
                List<int> tempPos=null;

                for (int n = 0; n < patterns.Length-2; n+=2)
                {
                    List<int> posInDocOne = fillPositions(wordData[patterns[n]][i],Int32.Parse(patterns[n+1]));

                    List<int> posInDocTwo = fillPositions(wordData[patterns[n+2]][i], Int32.Parse(patterns[n + 1]));

                    if(tempPos==null)
                    {
                        tempPos = posInDocOne.Intersect(posInDocTwo).ToList();
                        continue;
                    }

                    tempPos = tempPos.Intersect(posInDocOne.Intersect(posInDocTwo)).ToList();

                }

                intersections[i] = tempPos;

            }

            return intersections;
        }





        private static List<int> fillPositions(List<int> defPos, int near)
        {

            if (defPos == null) return new List<int>();

            List<int> allPossiblePositions = new List<int>();


            for(int i=0;i<defPos.Count;i++)
            {

                for(int j=defPos[i]-near;j< defPos[i] + near;j++)
                {
                    if (j >= 0) allPossiblePositions.Add(j);
                }
            }

            return allPossiblePositions;
        }




        private static bool checkExistance(Dictionary<string, List<int>[]> wordData, string[] patterns)
        {

            for(int i=0;i<patterns.Length;i+=2)
            {

                if (!wordData.ContainsKey(patterns[i])) return false;
            }

            return true;
        }

    }
}
