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
    // This value will be used  to indicate that a given subtree is imbalanced
    private const int ImbalancedHeight = -1;
    
    public bool IsBalanced(TreeNode root) => root is null || Solution.ImbalancedHeight != this.TreeHeight(root, 0);
    
    private int TreeHeight(TreeNode node, int height) {
        if (node is null) {
            // If the "node" is null, then the current subtree cannot be
            // traversed further. The max height of this subtree has been found
            return height;
        }
        
        // The height of the left subtree
        int leftHeight = this.TreeHeight(node.left, height);
        
        if (Solution.ImbalancedHeight == leftHeight) {
            // If a previous subtree was found to be imbalanced,
            // then return the value that indicates the whole tree
            // is imbalanced
            return Solution.ImbalancedHeight;
        }
        else {
            // Otherwise, increment "leftHeight" because the height returned
            // by the above, recursive call is the height of the left subtree
            // of "node". So the height of the current subtree is one greater
            ++leftHeight;
        }
        
        // The height of the right subtree
        int rightHeight = this.TreeHeight(node.right, height);
        
        if (Solution.ImbalancedHeight == rightHeight) {
            // If a previous subtree was found to be imbalanced,
            // then return the value that indicates the whole tree
            // is imbalanced
            
            return Solution.ImbalancedHeight;
        }
        else {
            // Otherwise, increment "rightHeight" because the height returned
            // by the above, recursive call is the height of the right subtree
            // of "node". So the height of the current subtree is one greater
            
            ++rightHeight;
        }
        
        // The difference in heights between the two subtrees of "node"
        int heightDifference = Math.Abs(leftHeight - rightHeight);
        if (heightDifference <= 1) {
            // If the height of the two subtrees differ by 0 or 1,
            // then this subtree is balanced. The height of this
            // subtree is considered to be the greater of the two heights
            
            return Math.Max(leftHeight, rightHeight);
        }
        else {
            // If the subtrees have a height difference greater than one,
            // then the whole tree is imbalanced
            
            return Solution.ImbalancedHeight;
        }
    }
}
