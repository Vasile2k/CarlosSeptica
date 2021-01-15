using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public class CardDealer
    {
        private Random random;

        private List<Card> cardsLeftInDeck;

        public int CardsLeft
        {
            get
            {
                return cardsLeftInDeck.Count();
            }
        }

        public CardDealer()
        {
            // TODO: REMEMBER TO REMOVE SEED
            // FOR DEBUGGING PURPOSES ONLY
            random = new Random(69);
            cardsLeftInDeck = new List<Card>();
            Refill();
        }

        public void Refill()
        {
            cardsLeftInDeck.Clear();
            foreach(CardNumber number in Enum.GetValues(typeof(CardNumber)))
            {
                foreach(CardType type in Enum.GetValues(typeof(CardType)))
                {
                    cardsLeftInDeck.Add(new Card(number, type));
                }
            }
        }

        public void Draw(Graphics g, int x, int y)
        {
            // Draw cards left in deck
            for(int i = 0; i < CardsLeft; ++i)
            {
                cardsLeftInDeck[i].Draw(g, x + i, y + 20 + 16, true);
            }

            // Write how many cards are left
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            
            if (CardsLeft > 0)
            {
                g.DrawString(CardsLeft + " cards", drawFont, drawBrush, x, y);
            }
            else
            {
                g.DrawString("Enpty", drawFont, drawBrush, x, y);
            }
        }

        public Card GiveCard()
        {
            if(cardsLeftInDeck.Count() > 0)
            {
                int cardToRemove = random.Next(0, cardsLeftInDeck.Count());
                Card card = cardsLeftInDeck[cardToRemove];
                cardsLeftInDeck.RemoveAt(cardToRemove);
                return card;
            }
            else
            {
                Debug.WriteLine("Requested card from empty deck!");
                return null;
            }
        }
    }
}
