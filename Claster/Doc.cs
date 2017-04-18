using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    class Doc
    {
        private string[] Author;
        private string[] Title;
        private string[] Body;


        public Doc(string[] Author, string[] Title, string[] Body)
        {
            this.Author = Author;
            this.Title = Title;
            this.Body=Body;
        }

        public string[] GetAuthor()
        {
            return Author;

        }

        public string[] GetTitle()
        {
            return Title;

        }

        public string[] GetBody()
        {
            return Body;

        }
    }
}
