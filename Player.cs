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

    public class Player
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
                return hand.ToList().Select(card => card != null).Count();
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
                return collectedCardStack.Select(card => card.Number == CardNumber.CARD_10 || card.Number == CardNumber.CARD_A).Count();
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
            for(int i = 0; i < hand.Length; ++i)
            {
                if (hand[i] == null)
                {
                    hand[i] = card;
                    break;
                }
            }
        }

        public void Draw(Graphics g, int x, int y)
        {
            // Draw cards in hand
            for(int i = 0; i < hand.Length; ++i)
            {
                if(hand[i] != null)
                {
                    hand[i].Draw(g, x + 100 * i, y, Type == PlayerType.PLAYER_AI);
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
    }
}
