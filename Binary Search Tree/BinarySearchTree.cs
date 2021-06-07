using System;

namespace Binary_Search_Tree
{
    public class BinarySearchTree : ITree
    {
        public TreeNode head;
        public BinarySearchTree() { }
        public TreeNode GetRoot() => head;

        public void AddItem(int value)
        {
            TreeNode tmp = null;
            if (head == null)
            {
                head = new TreeNode(value);
                return;
            }

            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = new TreeNode(value);
                        return;
                    }
                }
                else if (value < tmp.Value)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = new TreeNode(value);
                        return;
                    }
                }
                else
                {
                    throw new Exception("Узел уже существует");
                }
            }
            return;
        }

        public void RemoveItem(int value)
        {
            TreeNode current = head;
            TreeNode parent = head;
            bool isLeftChild = false;
            if (current == null)
            {
                return;
            }
            while (current != null && current.Value != value)
            {
                parent = current;
                if (value < current.Value)
                {
                    current = current.LeftChild;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightChild;
                    isLeftChild = false;
                }
            }
            if (current == null)
            {
                return;
            }
            if (current.RightChild == null && current.LeftChild == null)
            {
                if (current == head)
                {
                    head = null;
                }
                else
                {
                    if (isLeftChild)
                    {

                        parent.LeftChild = null;
                    }
                    else
                    {
                        parent.RightChild = null;
                    }
                }
            }
            else if (current.RightChild == null)
            {
                if (current == head)
                {
                    head = current.LeftChild;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = current.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = current.LeftChild;
                    }
                }
            }
            else if (current.LeftChild == null)
            {
                if (current == head)
                {
                    head = current.RightChild;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = current.RightChild;
                    }
                    else
                    {
                        parent.RightChild = current.RightChild;
                    }
                }
            }
            else
            {
                TreeNode successor = Successor(current);
                if (current == head)
                {
                    head = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }
                else
                {
                    parent.RightChild = successor;
                }
            }
        }

        private TreeNode Successor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightChild;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftChild;
            }
            if (successor != node.RightChild)
            {
                parentOfSuccessor.LeftChild = successor.RightChild;
                successor.RightChild = node.RightChild;
            }
            successor.LeftChild = node.LeftChild;

            return successor;
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

        public void PrintTree()
        {
            head.Print();
        }
    }
}
