/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head is null) {
            return false;
        }
        
        ListNode slow = head;
        ListNode fast = head.next;
        
        while (!object.ReferenceEquals(slow, fast)) {
            if (fast is null || fast.next is null) {
                return false;
            }
            
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return true;
    }
}