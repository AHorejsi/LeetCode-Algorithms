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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 is null && l2 is null) {
            return null;
        }
        else if (l1 is null && !(l2 is null)) {
            return l2;
        }
        else if (!(l1 is null) && l2 is null) {
            return l1;
        }
        
        ListNode head;
        
        if (l1.val <= l2.val) {
            head = new ListNode(l1.val);
            l1 = l1.next;
        }
        else {
            head = new ListNode(l2.val);
            l2 = l2.next;
        }
        
        ListNode current = head;
        
        while (!(l1 is null) && !(l2 is null)) {
            if (l1.val <= l2.val) {
                current.next = new ListNode(l1.val);
                l1 = l1.next;
            }
            else {
                current.next = new ListNode(l2.val);
                l2 = l2.next;
            }
            
            current = current.next;
        }
        
        while (!(l1 is null)) {
            current.next = new ListNode(l1.val);
            
            l1 = l1.next;
            current = current.next;
        }
        
        while (!(l2 is null)) {
            current.next = new ListNode(l2.val);
            
            l2 = l2.next;
            current = current.next;
        }
        
        return head;
    }
}