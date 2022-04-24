#DATA STRUCTURE

## Binary Search Tree 
A Binary Search Tree is a tree based data structure.
Each node in binary tree can have at most two children.
Binary Search tree is a Binary Tree which follows Bianry 
Search Tree Invariant(Property) i.e Inorder for a Binary Tree
to be Binary Search Tree, the left node must be smaller 
then the root node and right node must be greater then 
the root node.
Example :- 
            100
           /   \
         59     120
        /  \   /   \
       20  62 110   123




### Tree Traversals
Traversal is the process to visit all the nodes of a tree.
Unlike linear data structure which is traversed in linear fashion
Tree Data Structure can be traversed in different way and they
are :-
1:- PreOrder Traversal
2:- InOrder Traversal
3:- PostOrder Traversal


### PreOrder Traversal
 - Visit Root Node
 - Traverse Left Node
 - Traverse Right Node
 ![Pre Order Traversal](https://austingwalters.com/wp-content/uploads/2014/10/binary-tree-1-pre-order.gif)




### InOrder Traversal
 - Traverse Left sub tree
 - Visit the Root Node
 - Traverse Right Sub Tree
 
### PostOrder Traversal
  - Traverse Left Sub Tree
  - Traverse Right Subtree
  - Visit the Root Node

### Complexity of Binary Search Tree
                Average     Worst
INSERT          O(Log(n))   O(n)
DELETE          O(Log(n))   O(n)
SEARCH          O(Log(n)    O(n)