using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public enum GameStatus
    {
        STATUS_NOT_STARTED,
        STATUS_DISTRIBUTING_CARDS,
        STATUS_YOUR_TURN,
        STATUS_AI_TURN,
        STATUS_WON,
        STATUS_LOST
    }

    public class GameStatusHelper
    {
        public static string GetStatusMessage(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.STATUS_NOT_STARTED:
                    return "Game not started yet!";
                case GameStatus.STATUS_DISTRIBUTING_CARDS:
                    return "Distributing cards...";
                case GameStatus.STATUS_YOUR_TURN:
                    return "Your turn";
                case GameStatus.STATUS_AI_TURN:
                    return "Carlos is tinking...";
                case GameStatus.STATUS_WON:
                    return "You won!";
                case GameStatus.STATUS_LOST:
                    return "Carlos won!";
            }
            // Should never reach this
            return "Something unknown happened to the game!";
        }
    }

    public class Game
    {
        public GameStatus Status
        {
            get;
            set;
        }

        public GameState State
        {
            get;
        }

        private SepticaEngine septicaEngine;

        public Game()
        {
            Status = GameStatus.STATUS_NOT_STARTED;
            State = new GameState();
            septicaEngine = new SepticaEngine(State, this);
        }

        public void Start()
        {
            if(Status == GameStatus.STATUS_NOT_STARTED)
            {
                Status = GameStatus.STATUS_DISTRIBUTING_CARDS;
            }
        }

        public void Update()
        {
            switch (Status)
            {
                case GameStatus.STATUS_NOT_STARTED:
                {
                    break;
                }
                case GameStatus.STATUS_DISTRIBUTING_CARDS:
                {
                    if (State.Dealer.IsEmpty())
                    {
                        Status = State.CurrentTurn.Type == PlayerType.PLAYER_AI ? GameStatus.STATUS_AI_TURN : GameStatus.STATUS_YOUR_TURN;
                    }
                    else
                    {
                        DistributeOneCard();
                        if (AreBothPlayersFullOfCards())
                        {
                            // First time after distributing cards select the first player
                            // Otherwise, the player is already selected by EndRound meth (also remember to do some meth)
                            if (State.CurrentTurn == null)
                            {
                                State.CurrentTurn = State.PlayerHuman;
                            }
                            Status = State.CurrentTurn.Type == PlayerType.PLAYER_AI ? GameStatus.STATUS_AI_TURN : GameStatus.STATUS_YOUR_TURN;
                        }
                    }
                    break;
                }
                case GameStatus.STATUS_YOUR_TURN:
                {
                    break;
                }
                case GameStatus.STATUS_AI_TURN:
                {
                    /*int aiTurn = MonteCarloEngine.GetAiNextMove(State);
                    if (aiTurn == -1)
                    {
                        Debug.WriteLine("Carlos selected to end round");
                    }
                    else
                    {
                        Debug.WriteLine("Carlos selected card " + aiTurn);
                    }
                    septicaEngine.PutCardDown(State.PlayerAI, aiTurn);
                    */
                    break;
                }
                case GameStatus.STATUS_WON:
                {
                    break;
                }
                case GameStatus.STATUS_LOST:
                {
                    break;
                }
            }
        }

        public void DistributeOneCard()
        {
            // Distribute cards to the round winner
            // Or to human, in first round
            bool firstRound = State.CurrentTurn == null;
            Player first = firstRound ? State.PlayerHuman : State.CurrentTurn;
            Player second = first.Type == PlayerType.PLAYER_AI ? State.PlayerHuman : State.PlayerAI;
            if (second.CardsInHand >= first.CardsInHand)
            {
                if (!first.IsHandFull)
                {
                    first.AddCardInHand(State.Dealer.GiveCard());
                }
            }
            else
            {
                if (!second.IsHandFull)
                {
                    second.AddCardInHand(State.Dealer.GiveCard());
                }
            }
        }

        public bool AreBothPlayersFullOfCards()
        {
            return State.PlayerHuman.IsHandFull && State.PlayerAI.IsHandFull;
        }

        public void OnPlayerClick(int x, int y)
        {
            if (Status == GameStatus.STATUS_YOUR_TURN)
            {
                int[] possibleMoves = septicaEngine.GetPossibleMoves(State.PlayerHuman);
                if (possibleMoves.Length == 1 && possibleMoves[0] == -1) // If player chooses to finish the round without putting a card down
                {
                    septicaEngine.PutCardDown(State.PlayerHuman, -1);

                    Debug.WriteLine("Player selected to end round");
                }
                else
                {
                    int cardId = State.PlayerHuman.GetCardHandIndexAtCoords(x - 250, y - 450);
                    if(cardId != -1 && State.PlayerHuman.GetCardsInHand()[cardId] != null)
                    {
                        septicaEngine.PutCardDown(State.PlayerHuman, cardId);

                        Debug.WriteLine("Player selected card " + cardId);
                    }
                    else
                    {
                        if (possibleMoves.Contains(-1))
                        {
                            septicaEngine.PutCardDown(State.PlayerHuman, -1);
                        }
                        Debug.WriteLine("Player clicked on air!");
                    }
                }
            }
            else if(Status == GameStatus.STATUS_AI_TURN)
            {
                // TODO: FOR TESTING ONLY, REMOVE FOR FUCK'S SAKE
                int[] possibleMoves = septicaEngine.GetPossibleMoves(State.PlayerAI);
                int cardId = State.PlayerAI.GetCardHandIndexAtCoords(x - 250, y - 50);
                if (possibleMoves.Contains(cardId))
                {
                    septicaEngine.PutCardDown(State.PlayerAI, cardId);

                    Debug.WriteLine("AI selected card " + cardId);
                }
                else
                {
                    Debug.WriteLine("AI tried illegal move!");
                }
            }
        }

        public void Draw(Graphics g)
        {
            State.PlayerHuman.Draw(g, 250, 450);
            State.PlayerAI.Draw(g, 250, 50);
            State.Dealer.Draw(g, 50, 220);
            State.Table.Draw(g, 300, 250);

            // Draw status string
            Font drawFont = new Font("Arial", 12, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(GameStatusHelper.GetStatusMessage(Status), drawFont, drawBrush, 10, 630);

            // Draw end round
            if(Status == GameStatus.STATUS_YOUR_TURN)
            {
                int[] possibleMoves = septicaEngine.GetPossibleMoves(State.PlayerHuman);
                Font statusFont = new Font("Arial", 18, FontStyle.Bold);
                if (possibleMoves.Contains(-1))
                {
                    if(possibleMoves.Length > 1)
                    {
                        g.DrawString("Click anywhere if", statusFont, drawBrush, 10, 490);
                        g.DrawString(" ya wanna end!", statusFont, drawBrush, 10, 520);
                    }
                    else
                    {
                        g.DrawString("  No moves left!", statusFont, drawBrush, 10, 490);
                        g.DrawString("Click to end round!", statusFont, drawBrush, 10, 520);
                    }
                }
            }
        }
    }
}
