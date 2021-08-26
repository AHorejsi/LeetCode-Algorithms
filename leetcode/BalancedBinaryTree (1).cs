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
    public bool IsBalanced(TreeNode root) => root is null || -1 != this.TreeHeight(root, 0);
    
    private int TreeHeight(TreeNode node, int height) {
        int leftHeight = height;
        int rightHeight = height;
        
        if (!(node.left is null)) {
            leftHeight = this.TreeHeight(node.left, height);
            
            if (-1 == leftHeight) {
                return leftHeight;
            }
            else {
                ++leftHeight;
            }
        }
        if (!(node.right is null)) {
            rightHeight = this.TreeHeight(node.right, height);
            
            if (-1 == rightHeight) {
                return rightHeight;
            }
            else {
                ++rightHeight;
            }
        }
        
        int heightDifference = Math.Abs(leftHeight - rightHeight);

        if (heightDifference <= 1) {
            return Math.Max(leftHeight, rightHeight);
        }
        else {
            return -1;
        }
    }
}