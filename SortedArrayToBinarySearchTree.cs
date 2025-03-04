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
    // Converts the pre-sorted array into a height-balanced binary search tree
    public TreeNode SortedArrayToBST(int[] nums) => this.Traverse(nums, 0, nums.Length - 1);

    // Traverses the subarray specified by "lowIndex" and "highIndex" of "nums", inclusive.
    // Converts the given subarray into a binary search tree
    private TreeNode Traverse(int[] nums, int lowIndex, int highIndex) {
        // If the specified subarray is empty, there are no values to convert into a binary search tree
        if (lowIndex > highIndex) {
            return null;
        }
        
        // The element that is in the middle of our subarray will be the root
        // the corresponding binary search tree that is the subarray becomes
        var midIndex = (lowIndex + highIndex) / 2;

        // Root of the current subarray
        var root = new TreeNode();

        // Assign the middlemost value to the root
        root.val = nums[midIndex];

        // Recursively traverse the left-side subarray and convert it into
        // the left subtree of the root
        root.left = this.Traverse(nums, lowIndex, midIndex - 1);

        // Recursively traverse the right-side subarray and convert it into
        // the right subtree of the root
        root.right = this.Traverse(nums, midIndex + 1, highIndex);

        return root;
    }
}
