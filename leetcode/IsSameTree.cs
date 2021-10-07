/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsSameTree(TreeNode node1, TreeNode node2) => 
        (node1 is null, node2 is null) switch {
            (true, true) => true,
            (true, false) => false,
            (false, true) => false,
            (false, false) => node1.val == node2.val && this.IsSameTree(node1.left, node2.left) && this.IsSameTree(node1.right, node2.right)
        };
}