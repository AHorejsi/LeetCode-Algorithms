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
    public ListNode DeleteDuplicates(ListNode head) {
        // If the head of the linked list is null, we have no values to remove
        if (!(head is null)) {
            // Represents the head of the current sublist of duplicate values
            var prev = head;

            // Represents the current node to be checked against the head of
            // the current sublist of duplicate values
            var node = head.next;

            while (!(node is null)) {

                // If the value in the sublist's head is not
                // equal to the value in the current node, then
                // the head of a new sublist has been reached
                if (prev.val != node.val) {
                    // Attach the head of the previous sublist
                    // to the head of the new sublist
                    prev.next = node;

                    // Move on to the head of the new sublist
                    prev = node;
                }

                // Move on to the next node
                node = node.next;
            }

            // If the end of the linked list has been reached, there is no
            // new node to attach to, but all of the final sublist's duplicates
            // must be removed
            prev.next = null;
        }

        return head;
    }
}
