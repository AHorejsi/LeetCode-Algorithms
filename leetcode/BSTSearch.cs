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
    public TreeNode SearchBST(TreeNode root, int val) {
        TreeNode node = root;
        
        while (!(node is null)) {
            if (node.val < val) {
                node = node.right;
            }
            else if (node.val > val) {
                node = node.left;
            }
            else {
                return node;
            }
        }
        
        return null;
    }
}