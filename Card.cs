using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public enum CardNumber
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

    public enum CardType
    {
        CARD_SPADE,  // Frunza
        CARD_CLUB,   // Trefla
        CARD_HEART,  // Inima
        CARD_DIAMOND // Romb
    }

    public class Card
    {
        public CardNumber Number
        {
            get;
        }

        public CardType Type
        {
            get;
        }

        public Card(CardNumber number, CardType type)
        {
            Number = number;
            Type = type;
        }
    }
}
