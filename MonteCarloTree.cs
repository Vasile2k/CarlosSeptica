using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosSeptica
{

    public class TreeNode
    {
        int Victories;
        int Simulations;
        GameState State;
        // Used for backpropagation
        TreeNode Parent;
        List<TreeNode> Children;

        public TreeNode(GameState state)
        {
            Victories = 0;
            Simulations = 0;
            State = state;
            Parent = null;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
            child.Parent = this;
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
            tree.RootNode = new TreeNode(gameState);
            return tree;
        }
    }
}
