using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

    public class Card : Clonable
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

        public void Draw(Graphics g, int x, int y, bool hidden)
        {
            int cardWidth = 98;
            int cardHeight = 133;
            if (hidden)
            {
                g.DrawImage(CardImageRegistry.Instance.GetCardBack(), x, y, cardWidth, cardHeight);
            }
            else
            {
                g.DrawImage(CardImageRegistry.Instance.GetImageForCard(this.Number, this.Type), x, y, cardWidth, cardHeight);
            }
        }

        public Clonable Clone()
        {
            return new Card(Number, Type);
        }

        private class CardImageRegistry
        {
            public static CardImageRegistry _instance = null;
            public static CardImageRegistry Instance
            {
                get
                {
                    if(_instance == null)
                    {
                        _instance = new CardImageRegistry();
                    }
                    return _instance;
                }
            }

            private Dictionary<string, Image> cardImages;

            public CardImageRegistry()
            {
                cardImages = new Dictionary<string, Image>();
                foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                {
                    foreach (CardType type in Enum.GetValues(typeof(CardType)))
                    {
                        string typeName = type.ToString().Replace("CARD_", "");
                        string key = number.ToString().Replace("CARD_", "") + typeName.Substring(0, 1);
                        string cardType = typeName.ToString().ToUpper()[0] + typeName.ToString().ToLower().Substring(1);
                        string fileName = "cards/card" + cardType + "s" + number.ToString().Replace("CARD_", "") + ".png";
                        cardImages.Add(key, Image.FromFile(fileName));
                        Debug.WriteLine("Loaded " + fileName + " => " + key);
                    }
                }
                cardImages.Add("back", Image.FromFile("cards/cardBack.png"));
                Debug.WriteLine("Loaded card back");
            }

            public Image GetImageForCard(CardNumber number, CardType type)
            {
                string key = number.ToString().Replace("CARD_", "") + type.ToString().Replace("CARD_", "").Substring(0, 1);
                return cardImages[key];
            }

            public Image GetCardBack()
            {
                return cardImages["back"];
            }
        }
    }
}
