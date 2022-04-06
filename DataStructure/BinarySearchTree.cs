using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{

    /// <summary>
    /// ### Binary Search Tree 
    /// A Binary Search Tree is a tree based data structure.
    /// Each node in binary tree can have at most two children.
    /// Binary Search tree is a Binary Tree which follows Bianry 
    /// Search Tree Invariant(Property) i.e Inorder for a Binary Tree
    /// to be Binary Search Tree, the left node must be smaller 
    /// then the root node and right node must be greater then 
    /// the root node.
    /// Example :- 
    ///             100
    ///            /   \
    ///          59     120
    ///         /  \`  /   \
    ///        20  62 110   123
    ///        
    /// #### Complexity of Binary Search Tree
    ///                 Average     Worst
    /// INSERT          O(Log(n))   O(n)
    /// DELETE          O(Log(n))   O(n)
    /// SEARCH          O(Log(n)    O(n)
    /// 
    /// 
    /// ### Tree Traversals
    /// Traversal is the process to visit all the nodes of a tree.
    /// Unlike linear data structure which is traversed in fashion
    /// Tree Data Structure can be traversed in various way and they
    /// are :-
    /// 1:- PreOrder Traversal
    /// 2:- InOrder Traversal
    /// 3:- PostOrder Traversal
    /// 
    /// 
    /// ## PreOrder Traversal
    ///  - Visit Root Node
    ///  - Traverse Left Node
    ///  - Traverse Right Node
    ///  
    /// ## InOrder Traversal
    ///  - Traverse Left sub tree
    ///  - Visit the Root Node
    ///  - Traverse Right Sub Tree
    ///  
    /// ## PostOrder Traversal
    ///   - Traverse Left Sub Tree
    ///   - Traverse Right Subtree
    ///   - Visit the Root Node
    /// </summary>
    class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        public T Root { get { return this.RootNode.Data; }  }
        private Node RootNode { get; set; }

        public int HeightOfTree()
        {
            throw new NotImplementedException();
        }

        public T[] InOrderTraversal()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Insert Data into Binary Search Tree
        /// </summary>
        /// <param name="item">Object to be inserted</param>
        public void Insert(T item)
        {
            if (this.RootNode == null)
            {
                this.RootNode = new Node(item);
            }
            else
            {
                this.Insert(this.RootNode,item);
            }
        }
        private void Insert(Node node,T item)
        {
            if(item.CompareTo(node.Data) > 0)
            {
                if(node.RightNode == null)
                {
                    node.RightNode = new Node(item);
                    return;
                }
                else
                {
                    Insert(node.RightNode, item);
                }
            }
            else
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node(item);
                    return;
                }
                else
                {
                    Insert(node.LeftNode, item);
                }
            }
        }

        public T[] PostOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public T[] PreOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public T Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Search(T item)
        {
            throw new NotImplementedException();
        }

        private class Node : IComparable<T>
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public T Data { get; set; }

            public Node(T Data,Node LeftNode = null,Node RightNode = null)
            {
                this.Data = Data;
                this.LeftNode = LeftNode;
                this.RightNode = RightNode;
            }
            public int CompareTo(T obj)
            {
                return this.Data.CompareTo(obj);
            }
        }
    }

    public interface IBinarySearchTree<T>
    {
        bool Search(T item);
        void Insert(T item);
        T Remove(T item);

        int HeightOfTree();
        T[] PreOrderTraversal();

        T[] InOrderTraversal();

        T[] PostOrderTraversal();
    }
}
