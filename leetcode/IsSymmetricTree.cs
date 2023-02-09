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
    public bool IsSymmetric(TreeNode root) => this.IsSymmetricHelper(root.left, root.right);

    private bool IsSymmetricHelper(TreeNode mirrorLeft, TreeNode mirrorRight) =>
        (mirrorLeft is null, mirrorRight is null) switch {
            // If both are null, then the tree mirrors itself structurally at this point
            (true, true) => true,
            // If only one is null, then the tree does not mirror itself structurally at this point
            (true, false) => false,
            // If only one is null, then the tree does not mirror itself structurally at this point
            (false, true) => false,
            // If neither are null, then check if both nodes have the same value, continue traversing the tree
            (false, false) => mirrorLeft.val == mirrorRight.val &&
                this.IsSymmetricHelper(mirrorLeft.left, mirrorRight.right) &&
                this.IsSymmetricHelper(mirrorLeft.right, mirrorRight.left)
        };
}
