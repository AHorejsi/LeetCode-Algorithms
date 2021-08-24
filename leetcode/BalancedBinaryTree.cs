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
    private sealed class BalanceResult {
        public int Height { get; set; }
        public bool Balanced { get; }
        
        public BalanceResult(int height, bool balanced) {
            this.Height = height;
            this.Balanced = balanced;
        }
        
        public BalanceResult(BalanceResult other) : this(other.Height, other.Balanced) {}
    }
    
    public bool IsBalanced(TreeNode root) {
        if (root is null) {
            return true;
        }
        else {            
            BalanceResult result = this.IsBalancedSubtree(root, new BalanceResult(0, true));

            return result.Balanced;
        }
    }
    
    private BalanceResult IsBalancedSubtree(TreeNode node, BalanceResult result) {
        BalanceResult leftResult = new BalanceResult(result);
        BalanceResult rightResult = new BalanceResult(result);
        
        if (!(node.left is null)) {
            leftResult = this.IsBalancedSubtree(node.left, result);
            ++(leftResult.Height);
        }
        if (!(node.right is null)) {
            rightResult = this.IsBalancedSubtree(node.right, result);
            ++(rightResult.Height);
        }
        
        if (!(leftResult.Balanced && rightResult.Balanced)) {
            return new BalanceResult(-1, false);
        }
        else {
            int heightDifference = Math.Abs(leftResult.Height - rightResult.Height);
        
            if (heightDifference <= 1) {
                int newHeight = Math.Max(leftResult.Height, rightResult.Height);
                return new BalanceResult(newHeight, true);
            }
            else {
                return new BalanceResult(-1, false);
            }
        }
    }
}