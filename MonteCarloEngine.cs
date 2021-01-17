using System;
using System.Collections.Generic;
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
            SepticaEngine septicaEngine = new SepticaEngine(currentGameState, () => { }, () => { }, () => { });
            int[] possibleMoves = septicaEngine.GetPossibleMoves(currentGameState.PlayerAI);
            int move = new Random().Next(possibleMoves.Length);
            return possibleMoves[move];
            //return new Random().Next(5) - 1;
        }

        /**
         * Plays current game 'till end with random moves
         * Performs a rollout simulation
         * <returns>the winner of the game (tie is considered lost)</returns>
         */
        public static Player PlayToEnd(GameState gameState)
        {
            return null;
        }

    }
}
