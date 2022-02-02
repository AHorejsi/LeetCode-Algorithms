/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/


public class Solution {
    public Node CloneTree(Node root) {
        if (root is null) {
            return null;
        }
        else {
            return this.DoClone(root);
        }
    }
    
    private Node DoClone(Node node) {
        Node newNode = new Node(node.val);
        
        foreach (Node childNode in node.children) {
            // Build out copies of child nodes before current node
            Node newChildNode = this.DoClone(childNode);
            
            // Add subtree to current node's children
            newNode.children.Add(newChildNode);
        }
        
        return newNode;
    }
}