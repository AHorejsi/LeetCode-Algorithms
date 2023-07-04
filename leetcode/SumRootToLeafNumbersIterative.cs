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
    public int SumNumbers(TreeNode root) {
        // Used to emulate recursion
        var stack = new Stack<Path>();

        // Represents the sum of all path numbers
        var totalSum = 0;

        // Initialize recursion
        stack.Push(new Path(root.val, root));

        while (0 != stack.Count) {
            var path = stack.Pop();
            var node = path.Node;

            // Represents the path number of the left child if there is one
            int leftNum;

            // Represents the path number of the right child if there is one
            int rightNum;

            switch (node.left is null, node.right is null) {
            case (true, true):
                // If both children of the current node are null, we have completed the path number.
                // So we add the current path number to the current sum

                totalSum += path.Num;

                break;
            case (false, true):
                // If only the right child is not null, then continue building the path number by moving
                // down the tree to the right child

                leftNum = path.Num * 10 + node.left.val;

                stack.Push(new Path(leftNum, node.left));

                break;
            case (true, false):
                // If only the left child is not null, then continue building the path number by moving
                // down the tree to the left child

                rightNum = path.Num * 10 + node.right.val;

                stack.Push(new Path(rightNum, node.right));

                break;
            case (false, false):
                // If neither child is null, then move down both subtrees and build the path numbers
                // of both subtrees

                leftNum = path.Num * 10 + node.left.val;
                rightNum = path.Num * 10 + node.right.val;

                stack.Push(new Path(leftNum, node.left));
                stack.Push(new Path(rightNum, node.right));

                break;
            }
        }

        return totalSum;
    }

    // Represents the path number from the root of the tree to the contained node
    private struct Path {
        // The path number from the root to the given node
        public int Num { get; }

        // The node whose path was drawn from the root
        public TreeNode Node { get; }

        public Path(int num, TreeNode node) {
            this.Num = num;
            this.Node = node;
        }
    }
}
