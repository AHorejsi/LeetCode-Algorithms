/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode searchNode) {
        if (!(searchNode.right is null)) {
            return this.MoveDownTree(searchNode);
        }
        else {
            Stack<TreeNode> predecessors = this.FindPredecessorsOfSearchNode(root, searchNode);

            while (0 != predecessors.Count) {
                TreeNode prev = predecessors.Pop();

                if (prev.val > searchNode.val) {
                    return prev;
                }
            }

            return null;
        }
    }
    
    private TreeNode MoveDownTree(TreeNode searchNode) {
        TreeNode node = searchNode.right;
        TreeNode parent = null;
        
        while (!(node is null)) {
            parent = node;
            node = node.left;
        }
        
        return parent;
    }
    
    private Stack<TreeNode> FindPredecessorsOfSearchNode(TreeNode root, TreeNode searchNode) {
        Stack<TreeNode> predecessors = new Stack<TreeNode>();
        TreeNode current = root;

        while (!(current is null)) {
            predecessors.Push(current);

            if (current.val > searchNode.val) {
                current = current.left;
            }
            else {
                current = current.right;
            }
        }
        
        return predecessors;
    }
}