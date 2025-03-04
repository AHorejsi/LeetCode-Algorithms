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
    public int KthSmallest(TreeNode root, int targetIndex) {
        // Used to traverse the binary search tree
        var stack = new Stack<TreeNode>();

        // Current node of the traversal
        var node = root;

        // The index of the current node
        var currentIndex = 1;

        while (!(node is null) || stack.Any()) {
            if (!(node is null)) {
                stack.Push(node);
                node = node.left;
            }
            else {
                node = stack.Pop();
                
                // If the the index of the target has been reached, return the current node's value
                if (currentIndex == targetIndex) {
                    return node.val;
                }
                // Otherwise, continue traversal
                else {
                    ++currentIndex;
                }

                node = node.right;
            }
        }

        throw new ArgumentOutOfRangeException($"Index out of bounds: {currentIndex} {targetIndex}");
    }
}
