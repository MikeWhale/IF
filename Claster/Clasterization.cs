using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{


    class Leader
    {
        
        private Doc invertLeader;

        private Leader() { }

        public Leader(Doc invertLeader)
        {
            
            this.invertLeader = invertLeader;

        }

        public Leader GetLeader()
        {
            return this;
        }

        public Doc GetLeaderInvert()
        {
            return invertLeader;
        }

       
    }


    class Claster
    {

        private List<Doc> followers;

        public Leader leader;



        private Claster() { }


        public Claster(Doc invertLeader)
        {
            this.leader = new Leader( invertLeader);
          
            followers = new List<Doc>();
        }


        public void AddFollower(Doc invertFollower)
        {
            followers.Add(invertFollower);

        }

        public Leader GetLeader()
        {
            return leader.GetLeader();

        }

        public List<Doc> GetFollowers()
        {
            return followers;
            
        }


    }




    class BestFollower:IComparable<BestFollower>
    {

        private BestFollower() { }


        public Doc data;
        public int rank;

        public BestFollower(int rank,Doc data)
        {
            this.rank = rank;
            this.data = data;
        }

        public int CompareTo(BestFollower other)
        {

            return this.rank.CompareTo(other.rank);

            throw new NotImplementedException();
        }

       
    }



    class Clasterization
    {

        private Clasterization() { }

        public const int MAX_Followers_TOP=15;

        Claster[] clasters;

        
        public Clasterization(Doc[] allInverted)
        {


            Random  random = new Random();
            clasters = new Claster[(int)Math.Sqrt(allInverted.Length)];


            List<int> tempDocs = new List<int>();

            for (int i=0;i<clasters.Length;i++)
            {

                int posDoc;

                while (true)
                {
                    posDoc = random.Next(0,allInverted.Length-1);

                    if(!tempDocs.Contains(posDoc))
                    {
                        tempDocs.Add(posDoc);
                        clasters[i] = new Claster(allInverted[posDoc]);
                        break;
                    }


                }
            }
            AddFollowers(allInverted, tempDocs);
        }



        public Claster[] GetClasters()
        {
            return clasters;
        }

        private void AddFollowers(Doc[] invertedAll, List<int> usedDocs)
        {

          
            for(int i=0;i<clasters.Length;i++)
            {

                List<BestFollower> topFollowers = new List<BestFollower>();
                
                int howIsSimilar = 0;

                for(int c=0;c<invertedAll.Length;c++)
                {

                    if(!usedDocs.Contains(c))
                    {

                        howIsSimilar= findSimilarity(clasters[i].GetLeader().GetLeaderInvert().GetBody(),invertedAll[c].GetBody());


                        topFollowers.Add(new BestFollower (howIsSimilar, invertedAll[c]));

                       

                    }
                }

                topFollowers.Sort();

                if (topFollowers.Count > MAX_Followers_TOP)
                    topFollowers.RemoveRange(0, topFollowers.Count-MAX_Followers_TOP);

                for (int p=0;p<topFollowers.Count;p++)
                {

                    clasters[i].AddFollower(topFollowers[p].data);
                }


            }
        }

        private int findSimilarity(string[] leader,string[] potentialFollower)
        {

            List<string> inter = leader.Intersect(potentialFollower).ToList();

            return ((inter.Count )/ (leader.Length))*1000;

        }
      








    }
}
