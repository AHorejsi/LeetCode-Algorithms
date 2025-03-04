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
public sealed class BSTIterator {    
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root) {
        this.InsertLeftmostBranch(root);
    }
    
    public int Next() {
        TreeNode current = this.stack.Pop();
        
        this.InsertLeftmostBranch(current.right);
        
        return current.val;
    }
    
    private void InsertLeftmostBranch(TreeNode node) {
        while (!(node is null)) {
            this.stack.Push(node);
            node = node.left;
        }
    }
    
    public bool HasNext() => 0 != this.stack.Count;
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */