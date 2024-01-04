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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        List<IList<int>> order = new List<IList<int>>();
        
        // If the root is null then the tree is empty,
        // therefore our output list shall be empty
        if (!(root is null)) {
            // Use a queue for a breadth first traversal and
            // Insert the root of the tree to start
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (0 != queue.Count) {
                this.TraverseLevel(queue, order);
            }
        }
        
        return order;
    }
    
    // Traverses the current level lf the tree and puts it into a list.
    // Also, inserts the next level to be traversed into the queue
    private void TraverseLevel(Queue<TreeNode> queue, List<IList<int>> order) {
        // The number of nodes to pull out of the queue. Needed
        // so that only the current level of the tree is traversed
        // because the next level is inserted into the queue while
        // removing nodes from the queue for the current level
        int size = queue.Count;
        
        // Represents the row of the tree that is to be traversed next
        List<int> row = new List<int>();
        
        for (int amount = 0; amount < size; ++amount) {
            // Next node in the current level
            TreeNode node = queue.Dequeue();
            
            // Add "node" to list that represents the row
            row.Add(node.val);
            
            // Add child nodes now so that the children will
            // be seen in the same order that their parents
            // were seen
            if (!(node.left is null)) {
                queue.Enqueue(node.left);
            }
            if (!(node.right is null)) {
                queue.Enqueue(node.right);
            }
        }
        
        order.Add(row);
    }
}