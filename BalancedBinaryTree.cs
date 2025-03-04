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
    // Used  to indicate that a given subtree is imbalanced
    private const int ImbalancedHeight = -1;
    
    // Entry point
    public bool IsBalanced(TreeNode root) => Solution.ImbalancedHeight != this.TreeHeight(root, 0);
    
    // Computes the height of a given node of a binary tree
    private int TreeHeight(TreeNode node, int height) {
        if (node is null) {
            // If the "node" is null, then the current subtree cannot be
            // traversed further. The max height of this subtree has been found
            return height;
        }

        // Height of the left subtree
        var leftHeight = this.TreeHeightHelper(node.left, height);

        // Height of the right subtree
        var rightHeight = this.TreeHeightHelper(node.right, height);
        
        // The difference in heights between the two subtrees of "node"
        var heightDifference = Math.Abs(leftHeight - rightHeight);

        // If the height difference is greater than 1, then the tree is, by the definition provided by the problem, imbalanced.
        // Otherwise, we use the taller of the two subtrees
        return heightDifference > 1 ? Solution.ImbalancedHeight : Math.Max(leftHeight, rightHeight);
    }

    private int TreeHeightHelper(TreeNode childNode, int height) {
        // Height of the current subtree represented by the child node
        var childHeight = this.TreeHeight(childNode, height);

        // If the subtree represented by the child node is balanced, then return the height of the child node's parent
        return Solution.ImbalancedHeight == childHeight ? Solution.ImbalancedHeight : childHeight + 1;
    }
}
