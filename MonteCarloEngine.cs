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
            SepticaEngine septicaEngine = new SepticaEngine(currentGameState, () => { }, () => { }, () => { });
            int[] possibleMoves = septicaEngine.GetPossibleMoves(currentGameState.PlayerAI);
            int move = new Random().Next(possibleMoves.Length);
            return possibleMoves[move];
            //return new Random().Next(5) - 1;
        }

    }
}
