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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (left == right || head.next is null) {
            return head;
        }
        if (head.next.next is null) {
            if (head.val != head.next.val) {
                head.val ^= head.next.val;
                head.next.val ^= head.val;
                head.val ^= head.next.val;
            }
            
            return head;
        }
        
        (ListNode reverseHead, ListNode reverseTail, ListNode tail) result1 = this.LeadingNodes(head, left);
        (ListNode newReverseTail, ListNode newTail) result2 = this.ReverseRange(result1.reverseTail, result1.tail, right - left);
        this.TrailingNodes(result2.newReverseTail, result2.newTail);

        return result1.reverseHead.next;
    }
    
    private (ListNode, ListNode, ListNode) LeadingNodes(ListNode head, int left) {
        ListNode reverseHead = new ListNode();
        ListNode reverseNode = reverseHead;
        ListNode node = head;
        
        for (int amount = 1; amount < left; ++amount) {
            reverseNode.next = new ListNode(node.val);
            
            reverseNode = reverseNode.next;
            node = node.next;
        }
        
        return (reverseHead, reverseNode, node);
    }
    
    private (ListNode, ListNode) ReverseRange(ListNode currentTail, ListNode tail, int size) {        
        ListNode reverseList = new ListNode(tail.val);
        ListNode reverseTail = reverseList;
        ListNode node = tail.next;
                 
        for (int count = 0; count < size; ++count) {
            ListNode newNode = new ListNode(node.val);

            newNode.next = reverseList;
            reverseList = newNode;

            node = node.next;
        }
        
        currentTail.next = reverseList;
        
        return (reverseTail, node);
    }
    
    private void TrailingNodes(ListNode reverseTail, ListNode tail) {
        if (tail is null) {
            return;
        }
        
        ListNode node = tail;
        ListNode reverseNode = reverseTail;
        
        while (!(node is null)) {
            reverseNode.next = new ListNode(node.val);
            
            node = node.next;
            reverseNode = reverseNode.next;
        }
    }
}