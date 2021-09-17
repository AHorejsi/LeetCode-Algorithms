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
    public int ClosestValue(TreeNode root, double target) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;
        TreeNode parent = null;
        
        int previousValue = -1;
        double previousDifference = double.MaxValue;
        
        while (!(node is null) || 0 != stack.Count) {
            if (!(node is null)) {
                stack.Push(node);
                
                parent = node;
                node = node.left;
            }
            else {
                node = stack.Pop();
                
                double currentDifference = node.val - target;
                
                if (currentDifference >= 0) {
                    return Math.Abs(previousDifference) < Math.Abs(currentDifference) ? previousValue : node.val;
                }
                else {
                    previousDifference = currentDifference;
                    previousValue = node.val;
                }
                
                parent = node;
                node = node.right;
            }
        }
        
        return parent.val;
    }
}