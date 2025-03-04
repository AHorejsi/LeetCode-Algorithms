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
    public ListNode Partition(ListNode head, int pivot) {        
        ListNode partitionPoint = new ListNode(0, head);
        ListNode node = partitionPoint;
        ListNode beforeNewHead = partitionPoint;

        while (!(node.next is null)) {
            if (node.next.val < pivot) {
                if (object.ReferenceEquals(partitionPoint.next.next, node.next.next)) {
                    node = node.next;
                    partitionPoint = partitionPoint.next;
                }
                else {
                    ListNode temp = node.next.next;

                    node.next.next = partitionPoint.next;
                    partitionPoint.next = node.next;
                    node.next = temp;
                    partitionPoint = partitionPoint.next;
                }
            }
            else {
                node = node.next;
            }
        }

        return beforeNewHead.next;
    }
}