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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        // List of objects containing info on each elements column, depth and
        // the value itself
        LinkedList<dynamic> order = new LinkedList<dynamic>();
        
        // Traverse the tree and record its column and depth. The column
        // of the root node is considered to be 0. The column values are used
        // to group elements in the same columns together and are not used as indices
        this.TraverseTree(root, order, 0, 0);
        
        return order
            .OrderBy((dynamic elem) => elem.Column) // Sort elements based on their columns so that they are returned in vertical order
            .GroupBy((dynamic elem) => elem.Column) // Group elements together based on their previously assigned column so they can be placed into the same list later
            .Select(
                (IGrouping<dynamic, dynamic> column) => column
                    .OrderBy((dynamic elem) => elem.Depth) // Sort each group in terms of depth. Ensures that the elements are returned in vertical order
                    .Select((dynamic elem) => (int)elem.Value) // Extract the value from the node. This is what needs to be returned
                    .ToList()
                )
            .Cast<IList<int>>()
            .ToList();
    }
    
    private void TraverseTree(TreeNode node, LinkedList<dynamic> order, int column, int depth) {
        if (!(node is null)) {
            // Record the current element
            order.AddLast(new { Column = column, Depth = depth, Value = node.val });
            int nextDepth = depth + 1;
            
            // Move to the left subtree. The left subtree is considered to have
            // a column that is one less than "column." This can result in some
            // values having a negative column, but since the columns are not used
            // as indices this is not an issue
            this.TraverseTree(node.left, order, column - 1, nextDepth);
            
            // Move to the right subtree. The right subtree is considered to have
            // a column that is one greater than "column."
            this.TraverseTree(node.right, order, column + 1, nextDepth);
        }
    }
}
