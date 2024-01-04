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
    public ListNode AddTwoNumbers(ListNode left, ListNode right) {
        int leftSize = this.Size(left);
        int rightSize = this.Size(right);
        
        if (leftSize < rightSize) {
            left = this.PrependZeroes(left, rightSize - leftSize);
        }
        else if (leftSize > rightSize) {
            right = this.PrependZeroes(right, leftSize - rightSize);
        }
            
        bool carryOne = false; 
        ListNode sum = this.Sum(left, right, ref carryOne);

        return this.CheckIfPrependOne(sum, carryOne);
    }
    
    private int Size(ListNode node) {
        int size = 0;
        
        while (!(node is null)) {
            node = node.next;
            ++size;
        }
        
        return size;
    }
    
    private ListNode PrependZeroes(ListNode list, int amount) {
        ListNode node = new ListNode();
        ListNode newHead = node;
        
        for (int count = 1; count < amount; ++count) {
            node.next = new ListNode();
            node = node.next;
        }
        
        node.next = list;
        
        return newHead;
    }
    
    private ListNode Sum(ListNode left, ListNode right, ref bool carryOne) {
        ListNode node = new ListNode();
        
        if (!(left.next is null)) {
            node.next = this.Sum(left.next, right.next, ref carryOne);
        }
        
        node.val = this.AddNodes(left, right, ref carryOne);
        
        return node;
    }
    
    private int AddNodes(ListNode left, ListNode right, ref bool carryOne) {
        int digit = left.val + right.val;
        
        if (carryOne) {
            ++digit;
        }
        
        if (digit >= 10) {
            digit -= 10;
            carryOne = true;
        }
        else {
            carryOne = false;
        }
        
        return digit;
    }
    
    private ListNode CheckIfPrependOne(ListNode head, bool carryOne) {
        if (carryOne) {
            ListNode newHead = new ListNode(1);
            newHead.next = head;

            return newHead;
        }
        else {
            return head;
        }
    }
}
