/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> order = new List<int>();
        
        if (root is null) {
            return order;
        }
        
        Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        nodeStack.Push(root);
        
        while (!(nodeStack.Count == 0)) {
            TreeNode node = nodeStack.Pop();
            
            order.Add(node.val);

            if (node.right != null) {
                nodeStack.Push(node.right);
            }
            if (node.left != null) {
                nodeStack.Push(node.left);
            }
        }
        
        return order;
    }
}