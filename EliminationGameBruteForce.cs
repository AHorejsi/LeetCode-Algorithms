public class Solution {
    public int LastRemaining(int max) {
        // Create a linked list of elements from 1 to "max"
        (var head, var tail) = this.MakeLinkedList(max);
        
        // Remove every other element while traversing left to right then
        // right to left, repeatedly until there is only one elements left
        var final = this.DoElimination(head, tail);
        
        return final.Value;
    }
    
    private (ListNode, ListNode) MakeLinkedList(int max) {
        var node = new ListNode(1);
        var head = node;
        
        for (var val = 2; val <= max; ++val) {
            var newNode = new ListNode(val);
            
            node.Next = newNode;
            newNode.Prev = node;
            
            node = newNode;
        }
        
        // "node" will point to the tail of the list by this point
        return (head, node);
    }
    
    private ListNode DoElimination(ListNode head, ListNode tail) {
        // If "head" and "tail" point to the same node, then the list
        // contains only one element. Therefore, we are done removing values
        while (!(object.ReferenceEquals(head, tail))) {
            // Remove values while traversing from left to right
            (head, tail) = this.LeftRemoval(head, tail);
            
            if (object.ReferenceEquals(head, tail)) {
                // If "head" and "tail" point to the same node, then the list
                // contains only one element. Therefore, we are done removing values
                
                break;
            }
            
            // Right values while traversing right to left
            (head, tail) = this.RightRemoval(head, tail);
        }
        
        return head;
    }
    
    private (ListNode, ListNode) LeftRemoval(ListNode head, ListNode tail) {
        // Start from the node to the right of "head"
        var node = head.Next;
        
        // These will point to the new head and tail by the end of the below loop
        var newHead = head.Next;
        var newTail = tail;
        
        while (true) {
            // After starting from the node to the right of "head", remove the node
            // prior to "node" and move right two nodes until the end of
            // the list is reached
            this.Remove(node.Prev);
            
            if (object.ReferenceEquals(node, tail)) {
                // If "node" is the tail, there are no later nodes to remove
                
                break;
            }
            else if (object.ReferenceEquals(node.Next, tail)) {
                // If "node.Next" is the tail, then the tail must be removed.
                // Remove it and set "newTail" to the node prior to "tail"
                
                newTail = tail.Prev;
                this.Remove(tail);
                
                break;
            }
            else {
                // There is more linked list to traverse
                
                node = node.Next.Next;
            }
        }
        
        return (newHead, newTail);
    }
    
    private (ListNode, ListNode) RightRemoval(ListNode head, ListNode tail) {
        // Start from the node to the left of "tail"
        var node = tail.Prev;
        
        // These will point to the new head and tail by the end of the below loop
        var newHead = head;
        var newTail = tail.Prev;
        
        while (true) {
            // After starting from the node to the left of "tail", remove the node
            // after "node" and move left two nodes until the end of the list is reached
            this.Remove(node.Next);
            
            if (object.ReferenceEquals(node, head)) {
                // If "node" is the head, there are no more nodes to traverse
                
                break;
            }
            else if (object.ReferenceEquals(node.Prev, head)) {
                // If "node.Prev" is the head, then the head must be removed.
                // Remove it and set "newHead" to the node after to "head"
                
                newHead = head.Next;
                this.Remove(head);
                
                break;
            }
            else {
                // There is more linked list to traverse
                
                node = node.Prev.Prev;
            }
        }
        
        return (newHead, newTail);
    }
    
    private void Remove(ListNode node) {
        if (node.Prev is null) {
            // If "node" is at the front of the list,
            // only update the node to the right of "node"
            
            node.Next.Prev = null;
        }
        else if (node.Next is null) {
            // If "node" is at the end of the list,
            // only update the node to the left of "node"
            
            node.Prev.Next = null;
        }
        else {
            // If "node" is in the middle of the list,
            // update nodes to the left and right
            
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
    }
    
    private sealed class ListNode {
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode Prev { get; set; }
        
        public ListNode(int val) {
            this.Value = val;
            this.Next = null;
            this.Prev = null;
        }
    }
}
