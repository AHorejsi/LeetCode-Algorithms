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
    public ListNode OddEvenList(ListNode head) {
        // If the list is empty, then there are no elements to reorder
        if (head is null) {
            return head;
        }

        // Initialize to the first "odd" node
        var oddNode = head;
        // Initialize to the first "even" node
        var evenNode = head.next;
        
        // The head of the "odd" side of the list
        var oddHead = oddNode;
        // The head of the "even" side of the list
        var evenHead = evenNode;

        // The "even" node is further to the right of the list than the
        // "odd" node so check the current "even" node for nullness
        while (!(evenNode is null || evenNode.next is null)) {
            // Make the current "odd" node link to the next "odd" node
            oddNode.next = oddNode.next.next;
            // Make current "even" node link to the next "even" node
            evenNode.next = evenNode.next.next;

            // Set the "odd" node to the newly found "odd" node
            oddNode = oddNode.next;
            // Set the "even" node to the node next to the current "odd" node
            evenNode = oddNode.next;
        }

        // Link the "odd" list and the "even" list together
        oddNode.next = evenHead;

        return oddHead;
    }
}
