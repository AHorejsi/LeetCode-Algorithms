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
    public int SumNumbers(TreeNode root) => this.Sum(root, 0, 0);

    private int Sum(TreeNode node, int pathNum, int totalSum) {
        // Append the value in the current node to our current path number
        pathNum = pathNum * 10 + node.val;

        switch (node.left is null, node.right is null) {
        case (true, true):
            // If both children of the current node are null, we have completed the path number.
            // So we add the current path number to the current sum
            totalSum += pathNum;

            break;
        case (false, true):
            // If only the right child is not null, then continue building the path number by moving
            // down the tree to the right child
            totalSum = this.Sum(node.left, pathNum, totalSum);

            break;
        case (true, false):
            // If only the left child is not null, then continue building the path number by moving
            // down the tree to the left child
            totalSum = this.Sum(node.right, pathNum, totalSum);

            break;
        case (false, false):
            // If neither child is null, then move down both subtrees and building the path numbers
            // of both subtrees
            totalSum = this.Sum(node.left, pathNum, totalSum);
            totalSum = this.Sum(node.right, pathNum, totalSum);

            break;
        }

        return totalSum;
    }
}
