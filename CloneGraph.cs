/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node is null) {
            return null;
        }
        else {
            return this.DoClone(node, new Dictionary<Node, Node>());
        }
    }
    
    private Node DoClone(Node node, Dictionary<Node, Node> visited) {
            Node newNode = new Node(node.val);
            visited.Add(node, newNode);
        
            foreach (Node childNode in node.neighbors) {
                Node newChildNode = 
                    // Checks if the child node has already been seen during traversal
                    visited.ContainsKey(childNode) ?
                    // If the node has already been seen, retrieve it and add it to the children
                    visited[childNode] :
                    // If the node has not been seen, move one depth down and add all of the child node's children to it before adding it to the current node's children
                    this.DoClone(childNode, visited);
					
				// Add subgraph to current node's children
                newNode.neighbors.Add(newChildNode);
            }

            return newNode;
    }
}