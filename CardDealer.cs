using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            foreach(CardType type in Enum.GetValues(typeof(CardType)))
            {
                // Add 4 cards of each type
                for(int i = 0; i < 4; ++i)
                {
                    cardsLeftInDeck.Add(new Card(type));
                }
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
