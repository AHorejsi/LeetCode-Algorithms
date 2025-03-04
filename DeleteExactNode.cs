/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Delete the node passed in as an argument from the list. This node is not a tail node
    public void DeleteNode(ListNode node) {
        node.val = node.next.val; // Assign the right-adjacent node to the node to be deleted
        node.next = node.next.next; // Delete the node whose value was previously copied
    }
}