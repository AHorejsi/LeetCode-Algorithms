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
    public void Flatten(TreeNode root) {
        if (root is null) {
            return;
        }

        var leftChild = root.left;

        if (!(leftChild is null)) {
            var rightChild = root.right;
            var rightmostLeaf = this.RightmostLeaf(leftChild);

            // All of the following is necessary because the output needs to be a right-leaning, binary search tree
            root.left = null; // Remove left subtree
            root.right = leftChild; // Move left subtree over to right
            rightmostLeaf.right = rightChild; // Move right subtree of root to right subtree of rightmost leaf
        }

        this.Flatten(root.right);
    }

    private TreeNode RightmostLeaf(TreeNode node) {
        var leaf = node;

        while (!(leaf.right is null)) {
            leaf = leaf.right;
        }

        return leaf;
    }
}
