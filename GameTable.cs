using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public class GameTable : Clonable
    {
        public List<Card> Cards
        {
            get;
        }

        public Player HandOwner
        {
            get;
            set;
        }

        public GameTable()
        {
            Cards = new List<Card>();
        }

        public void Draw(Graphics g, int x, int y)
        {
            // Draw cards on the table
            for (int i = 0; i < Cards.Count; ++i)
            {
                Cards[i].Draw(g, x + i*35, y, false);
            }
        }

        /**
         * Clones current object
         * Remember to set hand owner after you clone this
         */
        public Clonable Clone()
        {
            GameTable clone = new GameTable();

            foreach(Card c in Cards)
            {
                clone.Cards.Add((Card)c.Clone());
            }

            return clone;
        }
    }
}
