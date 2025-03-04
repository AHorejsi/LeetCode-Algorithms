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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> order = new List<int>();
        
        if (root is null) {
            return order;
        }
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;
        
        while (!(node is null) || 0 != stack.Count) {
            if (!(node is null)) {
                stack.Push(node);
                node = node.left;
            }
            else {
                node = stack.Pop();
                order.Add(node.val);
                node = node.right;
            }
        }
        
        return order;
    }
}