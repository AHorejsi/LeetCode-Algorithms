/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        if (0 == lists.length) {
            return null;
        }
        else {
            PriorityQueue<ListNode> sorter = this.initializeSorter(lists);
        
            if (sorter.isEmpty()) {
                return null;
            }
            else {
                ListNode head = new ListNode();
                ListNode node = head;

                while (!sorter.isEmpty()) {
                    ListNode list = sorter.poll();

                    node.next = new ListNode(list.val);
                    node = node.next;

                    if (null != list.next) {
                        sorter.offer(list.next);
                    }
                }
                
                return head.next;
            }
        }
    }
    
    private PriorityQueue<ListNode> initializeSorter(ListNode[] lists) {
        PriorityQueue<ListNode> sorter = new PriorityQueue<>((left, right) -> { return left.val - right.val; });
        
        for (ListNode list : lists) {
            if (null != list) {
                sorter.offer(list);
            }
        }
        
        return sorter;
    }
}