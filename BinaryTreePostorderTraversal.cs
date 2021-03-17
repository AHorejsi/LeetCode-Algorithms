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
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> order = new List<int>();
        
        if (root is null) {
            return order;
        }
        
        Stack<TreeNode> stack1 = new Stack<TreeNode>();
        Stack<TreeNode> stack2 = new Stack<TreeNode>();
        
        stack1.Push(root);
        
        while (stack1.Count != 0) {
            TreeNode temp = stack1.Pop();
            stack2.Push(temp);
            
            if (!(temp.left is null)) {
                stack1.Push(temp.left);
            }
            if (!(temp.right is null)) {
                stack1.Push(temp.right);
            }
        }
        
        while (stack2.Count != 0) {
            order.Add(stack2.Pop().val);
        }
        
        return order;
    }
}