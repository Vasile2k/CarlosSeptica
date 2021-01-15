using System;
using System.Collections.Generic;
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

        public void addCardToStack(Card card)
        {
            collectedCardStack.Add(card);
        }
    }
}
