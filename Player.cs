using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{

    public enum PlayerType
    {
        PLAYER_HUMAN,
        PLAYER_AI
    }

    public class Player : Clonable
    {
        public PlayerType Type
        {
            get;
            set;
        }

        private Card[] hand;

        public int CardsInHand
        {
            get
            {
                int cards = 0;
                for(int i = 0; i < hand.Length; ++i)
                {
                    if(hand[i] != null)
                    {
                        ++cards;
                    }
                }
                // hand.ToList().Select(card => card != null).Count() seems to be fucked up so manually counting...
                return cards;
            }
        }

        public bool IsHandFull
        {
            get
            {
                return CardsInHand == hand.Length;
            }
        }

        private List<Card> collectedCardStack;

        public int Score
        {
            get
            {
                return collectedCardStack.Where(card => card.Number == CardNumber.CARD_10 || card.Number == CardNumber.CARD_A).Count();
            }
        }

        public Player(PlayerType type)
        {
            Type = type;
            hand = new Card[4];
            collectedCardStack = new List<Card>();
        }

        public Card[] GetCardsInHand()
        {
            return hand;
        }

        public void AddCardToStack(Card card)
        {
            collectedCardStack.Add(card);
        }

        public void AddCardInHand(Card card)
        {
            // Fill cards from left to right for player and right to left for A.I.
            // Or maybe the other way around
            //int start = Type == PlayerType.PLAYER_HUMAN ? 3 : 0;
            //int end = 3 - start;
            //int increment = start < end ? 1 : -1;
            //for(int i = start; i != (end + increment); i += increment)
            //{
            //    if (hand[i] == null)
            //    {
            //        hand[i] = card;
            //        break;
            //    }
            //}
            //
            // ^^^ I like this shit better, but the teammates doesn't seem to agree... fuck my life :|
            //

            for (int i = 0; i < hand.Length; ++i)
            {
                if (hand[i] == null)
                {
                    hand[i] = card;
                    break;
                }
            }
        }

        public int GetCardHandIndexAtCoords(int x, int y)
        {
            if(y >= 0 && y <= 133)
            {
                for(int i = 0; i < hand.Length; ++i)
                {
                    if(x >= 100*i && x <= 100*i + 98)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void Draw(Graphics g, int x, int y)
        {
            // Draw cards in hand
            for(int i = 0; i < hand.Length; ++i)
            {
                if(hand[i] != null)
                {
                    // TODO: REPLACE FALSE WITH Type == PlayerType.PLAYER_AI
                    // TO HIDE AI CARDS AFTER DEBUGGING
                    hand[i].Draw(g, x + 100 * i, y, false);
                }
            }

            // Draw cards in stack
            for (int i = 0; i < collectedCardStack.Count; ++i)
            {
                collectedCardStack[i].Draw(g, 450 + x + i, y, true);
            }

            // Draw name
            Font drawFont = new Font("Arial", 32);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            bool h = Type == PlayerType.PLAYER_HUMAN;
            g.DrawString(h ? "HOOMAN" : "CARLOS A.I.", drawFont, drawBrush, h ? x + 100 : x + 70, h ? y + 150 : y - 50);

            // Draw score
            drawFont = new Font("Arial", 16);
            g.DrawString("Score: " + Score, drawFont, drawBrush, x + 450, h ? y + 16 + 133 : y - 20 - 16);
        }

        public Clonable Clone()
        {
            Player clone = new Player(Type);

            for(int i = 0; i < hand.Length; ++i)
            {
                if(hand[i] != null)
                {
                    clone.hand[i] = (Card)hand[i].Clone();
                }
            }

            foreach(Card c in collectedCardStack)
            {
                clone.AddCardToStack((Card)c.Clone());
            }

            return clone;
        }
    }
}
