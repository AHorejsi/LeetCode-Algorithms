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
    public bool IsValidBST(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        int? prev = null;
        
        while (0 != stack.Count || !(root is null)) {
            while (!(root is null)) {
                stack.Push(root);
                root = root.left;
            }
            
            root = stack.Pop();
            
            if (!(prev is null) && root.val <= prev) {
                return false;
            }
            
            prev = root.val;
            root = root.right;
        }

        return true;
    }
}