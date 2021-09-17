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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        IList<IList<int>> pathSums = new List<IList<int>>();
        
        if (!(root is null)) {
            this.FindPathSums(root, targetSum, new List<int>(), pathSums);
        }
        
        return pathSums;
    }
    
    private void FindPathSums(TreeNode node, int currentSum, IList<int> currentPath, IList<IList<int>> pathSums) {
        currentSum -= node.val;
        currentPath.Add(node.val);
        
        if (node.left is null && node.right is null) {
            if (0 == currentSum) {
                pathSums.Add(new List<int>(currentPath));
            }
        }
        else {
            if (!(node.left is null)) {
                this.FindPathSums(node.left, currentSum, currentPath, pathSums);
            }
            if (!(node.right is null)) {
                this.FindPathSums(node.right, currentSum, currentPath, pathSums);
            }
        }
        
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}