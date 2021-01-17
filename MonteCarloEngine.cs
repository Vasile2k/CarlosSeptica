using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{
    public class MonteCarloEngine
    {
        /**
         * Computes next movement to be done by Carlos A.I.
         * <returns>0-3 for putting down a card in hand or -1 to skip round</returns>
         */
        public static int GetAiNextMove(GameState currentGameState)
        {
            GameState clonedGameState = (GameState)currentGameState.Clone();
            MonteCarloTree simulationTree = MonteCarloTree.Create(clonedGameState);

            int simulations = Game.GetSimulationsNumber();

            for(int simulation = 0; simulation < simulations; ++simulation)
            {
                // Select
                // Expand
                // Simulate
                // Backpropagate
                // Da' o mu#e nu vrei tu?
            }

            //bool result = PlayToEnd(clonedGameState);

            SepticaEngine septicaEngine = new SepticaEngine(currentGameState, () => { }, () => { }, () => { });
            int[] possibleMoves = septicaEngine.GetPossibleMoves(currentGameState.PlayerAI);
            int move = new Random().Next(possibleMoves.Length);
            return possibleMoves[move];
            //return new Random().Next(5) - 1;
        }

        /**
         * Plays current game 'till end with random moves
         * Performs a rollout simulation
         * <returns>true if the game is won (tie is considered lost)</returns>
         */
        public static bool PlayToEnd(GameState gameState)
        {
            // TODO: SHIT FUCK DICK REMOVE SEED
            Random movinRandom = new Random(420);

            bool gameFinished = false;
            Action onFinishGame = () =>
            {
                gameFinished = true;
            };
            Action onDistributeCards = () =>
            {
                // The order doesn't mater since it's random
                // In main game is made just4fun
                // The important thing is to give them one to a player, one to the other player
                // Because they should have equal amount of cards
                // And the starting number of cards is even
                while (!gameState.PlayerAI.IsHandFull && !gameState.PlayerHuman.IsHandFull && !gameState.Dealer.IsEmpty())
                {
                    gameState.PlayerAI.AddCardInHand(gameState.Dealer.GiveCard());
                    gameState.PlayerHuman.AddCardInHand(gameState.Dealer.GiveCard());
                }
            };
            Action onTurnChanged = () =>
            {
                // Well, I don't think I have to do somethin' here
            };
            SepticaEngine septicaEngine = new SepticaEngine(gameState, onFinishGame, onDistributeCards, onTurnChanged);

            while (!gameFinished)
            {
                Player currentTurn = gameState.CurrentTurn;
                int[] possibleMoves = septicaEngine.GetPossibleMoves(currentTurn);
                int nextMove = possibleMoves[movinRandom.Next(possibleMoves.Length)];
                septicaEngine.PutCardDown(currentTurn, nextMove);
            }

            return gameState.PlayerAI.Score > gameState.PlayerHuman.Score;
        }

    }
}
