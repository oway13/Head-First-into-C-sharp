using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishCh8
{
    class CardComparer_byValue : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.value > y.value)
                return 1;
            else if (x.value < y.value)
                return -1;
            else
                return 0;
        }
    }
}
