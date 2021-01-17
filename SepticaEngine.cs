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
            // TODO
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
                        // TODO: maybe change turn
                    }
                    else
                    {
                        DebugMessage(player, "tried to end round prematurely!");
                    }
                }
                else
                {
                    Card card = player.GetCardsInHand()[index];
                    if(card != null)
                    {
                        State.Table.Cards.Add(card);
                        player.GetCardsInHand()[index] = null;
                        if (card.Number == CardNumber.CARD_7 || card.Number == State.Table.Cards.First().Number)
                        {
                            State.Table.HandOwner = player;
                        }
                        FlipTurn();
                    }
                    else
                    {
                        DebugMessage(player, "tried to put down inexistent card!");
                    }
                    
                }
            }
            else
            {
                DebugMessage(player, "tried to move when it's not his turn!");
            }
        }

        public bool AfterTurnCheck()
        {
            // TODO
            if (EvenCardsDown())
            {
                if(State.Table.Cards.Last().Number != State.Table.Cards.First().Number && State.Table.Cards.Last().Number != CardNumber.CARD_7)
                {
                    Player winner = State.Table.HandOwner;
                    foreach(Card c in State.Table.Cards)
                    {
                        winner.AddCardToStack(c);
                    }
                    State.Table.Cards.Clear();
                }
                else
                {
                    // Can continue only if you have a card that can cut or is the same as the first in the stack
                    Player nextPlayer = (game.Status == GameStatus.STATUS_YOUR_TURN) ? State.PlayerHuman : State.PlayerAI;
                    if(nextPlayer.GetCardsInHand().ToList().Where(card => card != null && (card.Number == CardNumber.CARD_7 || card.Number == State.Table.Cards.First().Number)).Count() == 0)
                    {
                        Player winner = State.Table.HandOwner;
                        foreach (Card c in State.Table.Cards)
                        {
                            winner.AddCardToStack(c);
                        }
                        State.Table.Cards.Clear();
                    }
                }
            }
            return false;
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
            // TODO
            return null;
        }

        public void FlipTurn()
        {
            bool ai = State.CurrentTurn.Type == PlayerType.PLAYER_AI;
            State.CurrentTurn = ai ? State.PlayerHuman : State.PlayerAI;
            game.Status = ai ? GameStatus.STATUS_YOUR_TURN : GameStatus.STATUS_AI_TURN;
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
