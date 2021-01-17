using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public class SepticaEngine
    {
        public GameState State
        {
            get;
            set;
        }

        private readonly Game game;

        public SepticaEngine(GameState gameState, Game game)
        {
            State = gameState;
            this.game = game;
        }

        public void EndRound(Player player)
        {
            Player winner = State.Table.HandOwner;
            foreach (Card c in State.Table.Cards)
            {
                winner.AddCardToStack(c);
            }
            State.Table.Cards.Clear();
            
            //if() TODO END GAYM IF NO CARDS LEFT

            SetTurn(winner);

            game.Status = GameStatus.STATUS_DISTRIBUTING_CARDS;
        }

        public void PutCardDown(Player player, int index)
        {
            if(player == State.CurrentTurn)
            {
                if (index == -1)
                {
                    if (CanEndRound(player))
                    {
                        EndRound(player);
                        // EndRound changes the turn to winner automatically
                    }
                    else
                    {
                        DebugMessage(player, "tried to end round prematurely!");
                    }
                }
                else
                {
                    if (GetPossibleMoves(player).ToList().Contains(index))
                    {
                        Card card = player.GetCardsInHand()[index];
                        State.Table.Cards.Add(card);
                        player.GetCardsInHand()[index] = null;
                        if (card.Number == CardNumber.CARD_7 || card.Number == State.Table.Cards.First().Number)
                        {
                            State.Table.HandOwner = player;
                        }
                        FlipTurn();

                        // SHIT FUCK DICK THIS CHECK IS DONE IN UI AND YOU CAN ONLY END
                        // BECAUSE YOU CAN ONLY END, YOU LITTLE DICK
                        /*int[] opponentPossibleMoves = GetPossibleMoves(State.CurrentTurn);
                        if (opponentPossibleMoves.Length == 1 && opponentPossibleMoves[0] == -1)
                        {
                            EndRound(State.CurrentTurn);
                        }*/
                    }
                    else
                    {
                        DebugMessage(player, "tried to put down inexistent card or to do illegal move!");
                    }
                }
            }
            else
            {
                DebugMessage(player, "tried to move when it's not his turn!");
            }
        }

        public bool EvenCardsDown()
        {
            return State.Table.Cards.Count() % 2 == 0;
        }

        public bool CanEndRound(Player player)
        {
            if(State.CurrentTurn != player)
            {
                DebugMessage(player, "asked to end opponent's round!");
            }
            return State.Table.Cards.Count > 0 && EvenCardsDown();
        }

        public CardNumber[] GetPossibleCardsDown()
        {
            List<Card> cardsDown = State.Table.Cards;
            if(cardsDown.Count == 0 || !EvenCardsDown())
            {
                return new CardNumber[] {
                    CardNumber.CARD_7,
                    CardNumber.CARD_8,
                    CardNumber.CARD_9,
                    CardNumber.CARD_10,
                    CardNumber.CARD_J,
                    CardNumber.CARD_Q,
                    CardNumber.CARD_K,
                    CardNumber.CARD_A,
                };
            }
            else
            {
                // Even number of cards down
                if (cardsDown.Last().Number == CardNumber.CARD_7 || cardsDown.Last().Number == cardsDown.First().Number)
                {
                    if(cardsDown.First().Number != CardNumber.CARD_7)
                    {
                        // Something and 7 down
                        return new CardNumber[]
                        {
                            CardNumber.CARD_7,
                            cardsDown.First().Number
                        };
                    }
                    else
                    {
                        // Only 7s down
                        return new CardNumber[]
                        {
                            CardNumber.CARD_7,
                        };
                    }

                }
                else
                {
                    return new CardNumber[] { };
                }
            }
        }

        public int[] GetPossibleMoves(Player player)
        {
            CardNumber[] possibleCardsDown = GetPossibleCardsDown();
            List<int> possibleMoves = new List<int>();

            foreach(CardNumber card in possibleCardsDown)
            {
                for(int i = 0; i < player.GetCardsInHand().Length; ++i)
                {
                    // If player has a card in hand in this position and the card can be put down
                    if(player.GetCardsInHand()[i] != null && player.GetCardsInHand()[i].Number == card)
                    {
                        possibleMoves.Add(i);
                    }
                }
            }

            if (CanEndRound(player))
            {
                possibleMoves.Add(-1);
            }

            return possibleMoves.ToArray();
        }

        public void FlipTurn()
        {
            bool ai = State.CurrentTurn.Type == PlayerType.PLAYER_AI;
            State.CurrentTurn = ai ? State.PlayerHuman : State.PlayerAI;
            game.Status = ai ? GameStatus.STATUS_YOUR_TURN : GameStatus.STATUS_AI_TURN;
        }

        /**
         * Sets next turn to player
         * The player will be the next who puts down card
         */
        public void SetTurn(Player player)
        {
            bool ai = player.Type == PlayerType.PLAYER_AI;
            State.CurrentTurn = player;
            game.Status = ai ? GameStatus.STATUS_AI_TURN : GameStatus.STATUS_YOUR_TURN;
        }

        public bool AnyCardsLeft()
        {
            // TODO
            return true;
        }

        private static void DebugMessage(Player player, string message)
        {
            Debug.WriteLine(((player.Type == PlayerType.PLAYER_AI) ? "AI" : "Human") + " " + message);
        }

        private static void DebugMessage(string message)
        {
            Debug.WriteLine(message);
        }

    }
}
