using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public class GameTable
    {
        public List<Card> Cards
        {
            get;
        }

        public GameTable()
        {
            Cards = new List<Card>();
        }
    }
}
