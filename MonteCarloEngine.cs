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
        // TODO FOR A GUY WITH TOO MUCH FREE TIME: REUSE THE TREE COMPUTED 'TILL NOW
        // TODO FOR ANOTHER GUY WITH TOO MUCH FREE TIME: IF YOU HAVE ONLY ONE POSSIBLE MOVE
        //                                              THEN FUCKING DO IT AND STOP THINKING!
        // ONE MORE SHIT: YOU DON'T KNOW WHAT CARDS YOUR OPPONENT HAS SO...
        //                SIMULATE WITH RANDOM CARDS FROM OPPONENT HAND AND DEALER SINCE YOU
        //          DON'T KNOW WHICH ONE IS WHERE. YOU KNOW JUST YOUR CARDS OR THE CARDS YOU'VE SEEN
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
                TreeNode leaf = simulationTree.SelectUCB1();

                // Expand
                SepticaEngine expansionEngine = new SepticaEngine(leaf.State);
                int[] futureMoves = expansionEngine.GetPossibleMoves(leaf.State.CurrentTurn);
                foreach(int futureMove in futureMoves)
                {
                    // Simulate
                    GameState futureState = (GameState)leaf.State.Clone();
                    TreeNode child = new TreeNode(futureState, futureMove);
                    // If the move we decide to do is to end round we also have to redistribute cards from the dealer
                    // WE LOST 2 FUCKING HOURS WITH THIS ERROR
                    Action onDistributeCards = () =>
                    {
                        // Look at PlayToEnd() for details
                        while (!futureState.PlayerAI.IsHandFull && !futureState.PlayerHuman.IsHandFull && !futureState.Dealer.IsEmpty())
                        {
                            futureState.PlayerAI.AddCardInHand(futureState.Dealer.GiveCard());
                            futureState.PlayerHuman.AddCardInHand(futureState.Dealer.GiveCard());
                        }
                    };
                    SepticaEngine playoutEngine = new SepticaEngine(futureState, () => { }, onDistributeCards, () => { });
                    playoutEngine.PutCardDown(futureState.CurrentTurn, futureMove);
                    if (playoutEngine.IsGameDone())
                    {
                        if(futureState.PlayerAI.Score > futureState.PlayerHuman.Score)
                        {
                            // Won
                            // Biggest possible value and lowest for parent
                            child.Victories = int.MaxValue;

                            // Parent should not be chosen again since I have a victory from it
                            leaf.Victories = int.MinValue;

                            // Backpropagate
                            leaf.AddChild(child);
                            child.Backpropagate(true);
                            // Also, if I have a victory I don't care what other expansions lead to
                            break;
                        }
                        else
                        {
                            // Lost
                            // Lowest possible value so it won't be chosen again
                            child.Victories = int.MinValue;

                            // Backpropagate
                            leaf.AddChild(child);
                            child.Backpropagate(false);
                        }
                    }
                    else
                    {
                        // If game is not done, then simulate
                        GameState stateToPlayout = (GameState)futureState.Clone();
                        bool won = PlayToEnd(stateToPlayout);

                        // Backpropagate
                        leaf.AddChild(child);
                        child.Backpropagate(won);

                    }
                }
            }

            TreeNode bestBranch = simulationTree.RootNode.SelectMostVisitedChild();
            return bestBranch.MoveDone;
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
