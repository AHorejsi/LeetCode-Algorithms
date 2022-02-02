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
    public ListNode RemoveElements(ListNode head, int val) {
        if (head is null || (val == head.val && head.next is null)) {
            // If "head" is null, the list is empty and there are no elements to remove
            // If "head.next" is null, then the list contains a single element. If the list contains
            // a single element and that single element is equal to "val", then the result will be
            // an empty list
            
            return null;
        }
        else {
            // If this block is entered, then the list either contains more than one element or
            // the list contains a single element that is not equal to "val"
            
            this.DoRemoval(head, val);
            
            // Since "DoRemoval" does not remove the "head" from the list, we must check if the
            // value in "head" is equal to "val" and, if so, return "head.next". Otherwise, return
            // "head"
            if (val == head.val) {
                return head.next;
            }
            else {
                return head;
            }
        }
    }
    
    // Removes all elements equal to "val" that come after "head". This is done because no node
    // is linked to "head" so it cannot be removed relative to the other nodes
    private void DoRemoval(ListNode head, int val) {
        ListNode node = head;
        
        while (!(node.next is null)) {
            if (val == node.next.val) {
                node.next = node.next.next;
            }
            else {
                node = node.next;
            }
        }
    }
}