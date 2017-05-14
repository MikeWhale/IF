using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise1
{
    [Serializable]
    class ItemOfDict
    {

        public static StringBuilder ALL_DICTIONARY = new StringBuilder();

        public static StringBuilder ALL_INDEX = new StringBuilder();

        private int IdOfWord;
        private short LengthOfWord;
        private int IdOfIndex;
        private short LengthOfIndex;

        public ItemOfDict(int IdOfWord,short LengthOfWord, int IdOfIndex,short LengthOfIndex)
        {
            this.IdOfWord = IdOfWord;
            this.LengthOfWord = LengthOfWord;
            this.IdOfIndex = IdOfIndex;
            this.LengthOfIndex = LengthOfIndex;
        }


        public int GetIdOfWord()
        {
            return IdOfWord;
        }

        public short GetLengthOfWord()
        {
            return LengthOfWord;
        }

        public int GetIdOfIndex()
        {
            return IdOfIndex;
        }

        public short GetLengthOfIndex()
        {
            return LengthOfIndex;
        }

    }
}
