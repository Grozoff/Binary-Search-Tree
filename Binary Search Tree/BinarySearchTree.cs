using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Search_Tree
{
    public class BinarySearchTree : ITree
    {
        public TreeNode head;

        public TreeNode GetRoot() => head;

        public IEnumerable<int> GetDfsWay()
        {
            if (head == null)
                yield break;

            var stack = new Stack<TreeNode>();
            stack.Push(head);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.RightChild != null)
                    stack.Push(node.RightChild);
                if (node.LeftChild != null)
                    stack.Push(node.LeftChild);
            }
        }

        public IEnumerable<int> GetBfsWay()
        {
            if (head == null)
                yield break;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(head);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild);
                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }
        }

        public void PrintTree()
        {
            Console.Clear();
            head.Print();
        }

        public void GrowRandomTree(int maxCount, int minValue, int maxValue)
        {
            var rand = new Random();

            foreach (var value in Enumerable.Range(minValue, maxValue).OrderBy(i => rand.Next()).Take(maxCount))
            {
                this.AddItem(value);
            }
        }

        public void AddItem(int value)
        {
            if (head == null)
            {
                head = new TreeNode(value);
                return;
            }

            TreeNode current = head;
            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = new TreeNode(value);
                        return;
                    }
                    current = current.LeftChild;
                }
                else if (value > current.Value)
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = new TreeNode(value);
                        return;
                    }
                    current = current.RightChild;
                }
                else
                {
                    throw new Exception("The node is already exist.");
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode currentNode = head;
            while (currentNode != null)
            {
                if (value == currentNode.Value)
                {
                    return currentNode;
                }
                else if (value > currentNode.Value)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    currentNode = currentNode.LeftChild;
                }
            }
            return null;
        }

        public void RemoveItem(int value)
        {
            if (head == null) return;
            if (head.Value == value) head = RemoveNode(head);
            else RemoveNode(head, value);
        }

        private TreeNode RemoveNode(TreeNode node, int value = -1)
        {
            if (node == null) return null;
            if (value == -1) value = node.Value;

            if (value < node.Value)
            {
                node.LeftChild = RemoveNode(node.LeftChild, value);
            }
            else if (value > node.Value)
            {
                node.RightChild = RemoveNode(node.RightChild, value);
            }
            else
            {
                if (node.LeftChild == null)
                {
                    return node.RightChild;
                }
                else if (node.RightChild == null)
                {
                    return node.LeftChild;
                }

                TreeNode successor = GetSuccessor(node.RightChild);
                node.Value = successor.Value;
                node.RightChild = RemoveNode(node.RightChild, successor.Value);
            }

            return node;
        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            if (node.LeftChild == null) return node;
            return GetSuccessor(node.LeftChild);
        }
    }
}
