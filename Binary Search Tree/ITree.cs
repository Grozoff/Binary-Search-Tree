using System.Collections.Generic;

namespace Binary_Search_Tree
{
    public interface ITree
    {
        /// <summary>
        /// Get DFS way.
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetDfsWay();

        /// <summary>
        /// Get BFS way.
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetBfsWay();

        /// <summary>
        /// Get tree root node.
        /// </summary>
        /// <returns></returns>
        TreeNode GetRoot();

        /// <summary>
        /// Add new node to tree.
        /// </summary>
        /// <param name="value"></param>
        void AddItem(int value);

        /// <summary>
        /// Delete node from tree.
        /// </summary>
        /// <param name="value"></param>
        void RemoveItem(int value);

        /// <summary>
        /// Get node from tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        TreeNode GetNodeByValue(int value);

        /// <summary>
        /// Print tree on console.
        /// </summary>
        void PrintTree(); 
    }
}
