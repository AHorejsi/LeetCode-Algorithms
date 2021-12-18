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
        int lesserValue = this.FindLesser(root, target);
        int greaterValue = this.FindGreater(root, target);
        
        double differenceFromLesser = Math.Abs(target - lesserValue);
        double differenceFromGreater = Math.Abs(target - greaterValue);
        
        return differenceFromLesser < differenceFromGreater ? lesserValue : greaterValue;
    }
    
    private int FindLesser(TreeNode root, double target) {
        TreeNode node = root;
        
        int currentValue = int.MaxValue;
        double currentDifference = double.MaxValue;
        
        while (!(node is null)) {
            double difference = target - node.val;
            
            if (difference < 0) {
                node = node.left;
            }
            else if (difference > 0) {
                currentValue = node.val;
                currentDifference = difference;
                
                node = node.right;
            }
            else {
                return node.val;
            }
        }
        
        return currentValue;
    }
    
    private int FindGreater(TreeNode root, double target) {
        TreeNode node = root;
        
        int currentValue = int.MaxValue;
        double currentDifference = double.MaxValue;
        
        while (!(node is null)) {
            double difference = target - node.val;
            
            if (difference < 0) {
                currentValue = node.val;
                currentDifference = difference;
                
                node = node.left;
            }
            else if (difference > 0) {
                node = node.right;
            }
            else {
                return node.val;
            }
        }
        
        return currentValue;
    }
}