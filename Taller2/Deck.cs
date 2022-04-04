using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2
{
    class Deck
    {
        private List<Card> lcards = new List<Card>();
        private uint costPoints;

        public Deck(List<Card> lcards, uint costPoints)
        {
            this.Lcards = lcards;
            this.CostPoints = costPoints;
        }

        public uint CostPoints { get => costPoints; set => costPoints = value; }
        internal List<Card> Lcards { get => lcards; set => lcards = value; }


       
    }

   

}
