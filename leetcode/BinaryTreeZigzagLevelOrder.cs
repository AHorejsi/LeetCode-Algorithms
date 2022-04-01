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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        // The ordering of each level in zigzag order
        IList<IList<int>> order = new List<IList<int>>();
        
        if (root is null) {
            // If the tree is empty, then the output shall be
            // empty as well
            return order;
        }
        
        // The elements of the current depth of the tree being traversed
        IList<int> depth = new List<int>();
        
        // Tracks whether or not we are traversing the current depth leftward or rightward
        bool moveLeft = true;
        
        // A deque of the elements of the current depth being traversed
        LinkedList<TreeNode> currentDepth = new LinkedList<TreeNode>();
        
        // A deque of the elements of the following depth
        LinkedList<TreeNode> nextDepth = new LinkedList<TreeNode>();
        
        // Add the root element of the tree
        currentDepth.AddLast(root);
        
        while (0 != currentDepth.Count) {
            // Current element
            TreeNode node;
            
            if (moveLeft) {
                // If we are moving leftward, then get the leftmost element of "currentDepth"
                // and insert on the right end of "nextDepth"
                
                node = currentDepth.First.Value;
                currentDepth.RemoveFirst();
                
                this.AppendIfNonnull(nextDepth, node.left);
                this.AppendIfNonnull(nextDepth, node.right);
            }
            else {
                // If we are moving rightward, then get the rightmost element of "currentDepth"
                // and insert on the left end of "nextDepth"
                
                node = currentDepth.Last.Value;
                currentDepth.RemoveLast();
                
                this.PrependIfNonnull(nextDepth, node.right);
                this.PrependIfNonnull(nextDepth, node.left);
            }
            
            depth.Add(node.val);
            
            if (0 == currentDepth.Count) {
                // If the current depth of elements has been exhausted,
                // move all elements of "nextDepth" to "currentDepth."
                // This ensures that the elements of "nextDepth" will
                // be traversed in the next iteration
                
                this.MoveAll(currentDepth, nextDepth);
                nextDepth.Clear();
                
                // Add the current depth of nodes to the output list
                // and create a new list to represent to next depth of elements
                order.Add(depth);
                depth = new List<int>(currentDepth.Count);
                
                // Reverse the direction of traversal
                moveLeft = !moveLeft;
            }
        }
        
        return order;
    }
    
    private void AppendIfNonnull(LinkedList<TreeNode> nextDepth, TreeNode node) {
        if (!(node is null)) {
            nextDepth.AddLast(node);
        }
    }
    
    private void PrependIfNonnull(LinkedList<TreeNode> nextDepth, TreeNode node) {
        if (!(node is null)) {
            nextDepth.AddFirst(node);
        }
    }
    
    private void MoveAll(LinkedList<TreeNode> current, LinkedList<TreeNode> next) {
        foreach (TreeNode node in next) {
            current.AddLast(node);
        }
    }
}
