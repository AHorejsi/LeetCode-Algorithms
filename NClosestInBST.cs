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
    public IList<int> ClosestKValues(TreeNode root, double target, int amount) {
        // List of the "amount" closest values to "target"
        List<int> closest = new List<int>(amount);
        
        // Find the value less than or equal to "target"
        double? lesser = this.FindLesser(root, target);
        
        // Find the value strictly greater than "target".
        // The "+ 0.1" exists to ensure the returned value
        // is strictly greater than "target" and a value
        // equal to "target" is not returned. This ensures
        // that "lesser" points to a distinct value than greater
        double? greater = this.FindGreater(root, target + 0.1);
        
        // Terminates when either "lesser" or "greater"
        // is null. Nullness occurs when there is not another
        // value less than "lesser's" current value or a value
        // greater than "greater's" current value
        while (!(lesser is null) && !(greater is null)) {
            if (closest.Count + 1 == amount) {
                // If there is only one more value that needs to be added
                // and neither "lesser" nor "greater" is null, then the closer
                // of the two must be added
                
                this.Choose(closest, lesser, greater, target);
            }
            else {
                // If two or more values need to be added,
                // add both "lesser" and "greater"
                closest.Add((int)lesser);
                closest.Add((int)greater);
            }
            
            // If the needed amount of values has been added,
            // break out of the loop. This is here, instead of
            // in the while condition to ensure that "FindLesser"
            // and "FindGreater" are not called more times than necessary
            if (closest.Count == amount) {
                break;
            }
            
            // Find the next strictly less value than "lesser."
            lesser = this.FindLesser(root, (double)lesser - 0.1);
            greater = this.FindGreater(root, (double)greater + 0.1);
        }
        
        // Only enter if the first loop did not insert the necessary
        // "amount" of values and if the first loop terminated because
        // "greater" was null. Only progresses "lesser" to smaller values
        // until the necessary "amount" of values is reached
        while (closest.Count != amount && !(lesser is null)) {
            closest.Add((int)lesser);
            lesser = this.FindLesser(root, (double)lesser - 0.1);
        }
        
        // Only enter if the first loop did not insert the necessary
        // "amount" of values and if the first loop terminated because
        // "lesser" was null. Only progresses "greater" to larger values
        // until the necessary "amount" of values is reached
        while (closest.Count != amount && !(greater is null)) {
            closest.Add((int)greater);
            greater = this.FindGreater(root, (double)greater + 0.1);
        }
        
        return closest;
    }
    
    private double? FindLesser(TreeNode root, double target) {
        // Points to the current node of the tree traversal
        TreeNode node = root;
        
        // Points to the closest found value to "target" that
        // is less than or equal to "target"
        TreeNode current = null;
        
        // Difference from "target" to "current.val"
        double currentDifference = double.MaxValue;
        
        while (!(node is null)) {
            // Difference from "target" to "node.val" 
            double difference = target - node.val;
            
            if (difference < 0) {
                // If "difference" is negative, then "node.val" is strictly greater
                // than "target." Do not update "current" and "currentDifference" ever
                // because we are searching for a value less than or equal to "target"
                
                // Since "node.val" is greater than "target," we want a smaller value
                // than "node.val." Therefore, move to the left child
                node = node.left;
            }
            else if (difference > 0) {
                // If "difference" is positive, then "node.val" is less than
                // "target." Therefore "node.val" is strictly less than "target."
                
                if (Math.Abs(currentDifference) > Math.Abs(difference)) {
                    // Only update "current" and "currentDifference" if the distance
                    // from "node.val" to "target" is less than the distance from "current.val"
                    // to "target"
                    current = node;
                    currentDifference = difference;
                }
                
                // Since "node.val" is less than "target," we want a value that
                // is strictly less than "target" and closer to "target" than "current.val".
                // Therefore, we move to the right child because that is in the direction of
                // "target" relative to "node.val" and therefore may be a value smaller than
                // "target," but closer than "node.val"
                node = node.right;
            }
            else {
                // "current.val" is equal to "target." Therefore the value with
                // the minimum possible distance from "target" has been found.
                // No need to continue looping
                
                current = node;
                break;
            }
        }
        
        // If "current" is null, then a value that is less than or equal to "target" was not found.
        // Therefore return null
        return current is null ? null : current.val;
    }
    
    private double? FindGreater(TreeNode root, double target) {
        // Points to the current node of the tree traversal
        TreeNode node = root;
        
        // Points to the closest found value to "target" that
        // is greater than or equal to "target"
        TreeNode current = null;
        
        // Difference from "target" to "current.val"
        double currentDifference = double.MaxValue;
        
        while (!(node is null)) {
            // Difference from "target" to "node.val" 
            double difference = target - node.val;            
            
            if (difference < 0) {
                // If "difference" is negative, then "node.val" is strictly greater
                // than "target"
                
                if (Math.Abs(currentDifference) > Math.Abs(difference)) {
                    // Only update "current" and "currentDifference" if the distance
                    // from "node.val" to "target" is less than the distance from "current.val"
                    // to "target"
                    current = node;
                    currentDifference = difference;
                }
                
                // Since "node.val" is greater than "target," we want a value that
                // is strictly greater than "target" and closer to "target" than "current.val".
                // Therefore, we move to the left child because that is in the direction of
                // "target" relative to "node.val" and therefore may be a value smaller than
                // "target," but closer than "node.val"
                node = node.left;
            }
            else if (difference > 0) {
                // If "difference" is positive, then "node.val" is strictly less
                // than "target." Do not update "current" and "currentDifference" ever
                // because we are searching for a value less than or equal to "target"
                
                // Since "node.val" is less than "target," we want a larger value
                // than "node.val." Therefore, move to the right child
                node = node.right;
            }
            else {
                // "current.val" is equal to "target." Therefore the value with
                // the minimum possible distance from "target" has been found.
                // No need to continue looping
                
                current = node;
                break;
            }
        }
        
        // If "current" is null, then a value that is greater than or equal to "target" was not found.
        // Therefore return null
        return current is null ? null : current.val;
    }
    
    private void Choose(List<int> closest, double? lesser, double? greater, double target) {
        // Distance from "target" to "lesser"
        double lesserDifference = target - (double)lesser;
        
        // Distance from "target" to "greater"
        double greaterDifference = (double)greater - target;
        
        // Select based on which has the shorter distance
        closest.Add((int)(lesserDifference < greaterDifference ? lesser : greater));
    }
}
