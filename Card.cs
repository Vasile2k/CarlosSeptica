using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public enum CardType
    {
        CARD_7,
        CARD_8,
        CARD_9,
        CARD_10,
        CARD_J,
        CARD_Q,
        CARD_K,
        CARD_A,
    }

    public class Card
    {
        public CardType Type
        {
            get;
            set;
        }

        public Card(CardType type)
        {
            Type = type;
        }
    }
}
