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
    public int[] FindMode(TreeNode root) {
        // Used to count the number of occurrences of each element. The keys are the elements of the binary search tree and the values are the corresponding counts
        var counts = new Dictionary<int, int>();

        // Count the elements of the binary search tree
        this.FindMode(root, counts);

        // Get the maximum count present
        var maxCount = counts.Values.Max();

        // Filter by elements that have the maximum count
        var result = counts.Where((kvp) => kvp.Value == maxCount);

        // Convert to intended return type
        return result.Select((kvp) => kvp.Key).ToArray();
    }

    private void FindMode(TreeNode node, Dictionary<int, int> counts) {
        if (!(node is null)) {
            // If node is not null, then there is a valid value to process

            if (counts.ContainsKey(node.val)) {
                // If the value has already been encountered, increment the count

                ++(counts[node.val]);
            }
            else {
                // If the value has not been encountered, initialize its count to 1

                counts.Add(node.val, 1);
            }

            // Traverse left subtree
            this.FindMode(node.left, counts);

            // Traverse right subtree
            this.FindMode(node.right, counts);
        }
    }
}
