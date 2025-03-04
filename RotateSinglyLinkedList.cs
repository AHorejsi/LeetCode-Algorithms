/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RotateRight(ListNode head, int rotationCount) {
        if (head is null) {
            return head;
        }
        else {
            // The number of nodes in the linked list
            int nodeCount = this.CountNodes(head);
            
            // If the linked list is 5 nodes long, then the output will be the same
            // if "rotationCount" is equal to 0, 5, 10, 15, etc. Same with 1, 6, 11, 16, etc.
            // if x is equal to the number of nodes, then x, (x + 5), (x + 10), (x + 15), etc. 
            // If c is equal to the "rotationCount" then, x, (x + c), (x + 2c), (x + 3c), etc.
            // Therefore, for any given "rotationCount", there is
            // a minimum value 'x' that will produce the same output as the actual "rotationCount".
            // This computes the minimum number of rotations needed to produce the correct output
            int minRotationCount = rotationCount % nodeCount;

            if (0 == minRotationCount) {
                return head;
            }
            else {
                // Pointers to the current tail and what will become the new tail
                (ListNode newTail, ListNode currentTail) = this.FindNeededNodes(head, minRotationCount, nodeCount);
                
                // What will become the new head
                ListNode newHead = newTail.next;
                
                // Since this is the new tail, its "next" pointer should be null
                newTail.next = null;
                
                // Because the list was rotated a nonzero amount of times, the current tail
                // must point to the current head
                currentTail.next = head;

                return newHead;
            }
        }
    }
    
    private int CountNodes(ListNode head) {
        int nodeCount = 0;
        
        for (ListNode node = head; !(node is null); node = node.next) {
            ++nodeCount;
        }
        
        return nodeCount;
    }
    
    private (ListNode, ListNode) FindNeededNodes(ListNode head, int minRotationCount, int nodeCount) {
        // Corresponds to the index of the node that will become the new tail
        int searchIndex = nodeCount - minRotationCount - 1;
        
        // Will point to the node that will be the new tail by the end of the loop below
        ListNode newTail = null;
        
        // By the end of the loop below, will point to the current tail of the linked list
        ListNode currentTail = null;
        
        // Node to use for traversal
        ListNode node = head;
        
        for (int index = 0; index < nodeCount; ++index) {
            // Assign the current node to the tail variable before moving to the next node
            // to ensure that the actual tail of the linked list is what is pointed to by
            // the end
            currentTail = node;
            
            // Once the index of the node that will become the new tail is reached,
            // save the new tail into the newTail variable
            if (searchIndex == index) {
                newTail = node;
            }
            
            // Move traversal node to the next node
            node = node.next;
        }
        
        return (newTail, currentTail);
    }
}