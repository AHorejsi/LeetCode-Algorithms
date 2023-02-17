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
    // If the root is null, then the there are no path sums in the binary tree. If there are nodes in the tree,
    // then traverse the tree and compute its path sums
    public bool HasPathSum(TreeNode root, int targetSum) => !(root is null) && this.CalcPaths(root, targetSum, 0);
    
    private bool CalcPaths(TreeNode node, int targetSum, int currentSum) {
        // Add the value of the current node to the current sum
        currentSum += node.val;
        
        if (node.left is null && node.right is null) {
            // If the current node is a leaf node, then check if the current sum is equal to the target sum

            return currentSum == targetSum;
        }
        else if (!(node.left is null) && this.CalcPaths(node.left, targetSum, currentSum)) {
            // If the left child of the current node is not null, then move down to the left
            // subtree and if a path sum is found that is equal to the target sum, then return true

            return true;
        }
        else if (!(node.right is null) && this.CalcPaths(node.right, targetSum, currentSum)) {
            // If the right child of the current node is not null, then move down to the right
            // subtree and if a path sum is found that is equal to the target sum, then return true

            return true;
        }
        else {
            // If no path from this node has a sum equal to the target sum, then return false

            return false;
        }
    }
}
