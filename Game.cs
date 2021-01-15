using System;
using System.Collections.Generic;
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
            private set;
        }

        public GameState State
        {
            get;
        }

        public Game()
        {
            Status = GameStatus.STATUS_NOT_STARTED;
            State = new GameState();
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
                    if(State.PlayerAI.CardsInHand >= State.PlayerHuman.CardsInHand)
                    {
                        if (!State.PlayerHuman.IsHandFull)
                        {
                            State.PlayerHuman.AddCardInHand(State.Dealer.GiveCard());
                        }
                    }
                    else
                    {
                        if (!State.PlayerAI.IsHandFull)
                        {
                            State.PlayerAI.AddCardInHand(State.Dealer.GiveCard());
                        }
                    }
                    if(State.PlayerHuman.IsHandFull && State.PlayerAI.IsHandFull)
                    {
                        Status = GameStatus.STATUS_YOUR_TURN;
                    }
                    break;
                }
                case GameStatus.STATUS_YOUR_TURN:
                {
                    break;
                }
                case GameStatus.STATUS_AI_TURN:
                {
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

        public void OnPlayerClick(int x, int y)
        {

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
        }
    }
}
