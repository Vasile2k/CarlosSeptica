using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{

    public class TreeNode
    {
        public int Victories;
        public int Simulations;
        public GameState State;
        // Used for backpropagation
        public TreeNode Parent;
        public List<TreeNode> Children;
        public int MoveDone;

        public TreeNode(GameState state, int moveDone)
        {
            Victories = 0;
            Simulations = 0;
            State = state;
            Parent = null;
            Children = new List<TreeNode>();
            MoveDone = moveDone;
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public TreeNode SelectUCB1()
        {
            if(Children.Count == 0)
            {
                return this;
            }
            else
            {
                double[] ucb1s = new double[Children.Count];
                for(int i = 0; i < Children.Count; ++i)
                {
                    ucb1s[i] = (double)Children[i].Victories / (double)Children[i].Simulations + Math.Sqrt(2.0 * Math.Log((double)Simulations) / (double)Children[i].Simulations);
                }

                // Ugly as fuck, but more efficient than Linq bullshit
                int maxIndex = 0;
                double maxUcb = ucb1s[0];

                for(int i = 1; i < ucb1s.Length; ++i)
                {
                    if(ucb1s[i] > maxUcb)
                    {
                        maxUcb = ucb1s[i];
                        maxIndex = i;
                    }
                }

                // Recurse down the tree
                return Children[maxIndex].SelectUCB1();
            }
        }

        public void Backpropagate(bool victory)
        {
            if (victory)
            {
                if (Victories != int.MinValue && Victories != int.MaxValue)
                {
                    ++Victories;
                }
            }
            ++Simulations;

            if (Parent != null)
            {
                Parent.Backpropagate(victory);
            }
        }

        public TreeNode SelectMostVisitedChild()
        {
            // Because fuck Linq
            if(Children.Count == 0)
            {
                return null;
            }
            
            TreeNode biggestChild = Children[0];
            
            for(int i = 1; i < Children.Count; ++i)
            {
                if(Children[i].Simulations > biggestChild.Simulations)
                {
                    biggestChild = Children[i];
                }
            }

            return biggestChild;
        }
    }

    public class MonteCarloTree
    {

        public TreeNode RootNode
        {
            get;
            set;
        }

        private MonteCarloTree()
        {

        }

        public static MonteCarloTree Create(GameState gameState)
        {
            MonteCarloTree tree = new MonteCarloTree();
            tree.RootNode = new TreeNode(gameState, -2);
            return tree;
        }

        public TreeNode SelectUCB1()
        {
            return RootNode.SelectUCB1();
        }
    }
}
