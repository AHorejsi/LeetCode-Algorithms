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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root is null) {
            return false;
        }
        
        return this.CalcPaths(root, targetSum, 0);
    }
    
    private bool CalcPaths(TreeNode node, int targetSum, int currentSum) {
        currentSum += node.val;
        
        if (currentSum == targetSum && node.left is null && node.right is null) {
            return true;
        }
        if (!(node.left is null)) {
            if (this.CalcPaths(node.left, targetSum, currentSum)) {
                return true;
            }
        }
        if (!(node.right is null)) {
            if (this.CalcPaths(node.right, targetSum, currentSum)) {
                return true;
            }
        }
        
        return false;
    }
}