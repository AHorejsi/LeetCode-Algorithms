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
    public void ReorderList(ListNode head) {
        // Put the nodes into an arraylist
        var list = this.MakeList(head);

        // Reorder the nodes with the arraylist
        this.DoReorder(list);
    }

    private List<ListNode> MakeList(ListNode head) {
        var list = new List<ListNode>();

        for (var node = head; !(node is null); node = node.next) {
            list.Add(node);
        }

        return list;
    }

    private void DoReorder(List<ListNode> list) {
        var lowIndex = 0;
        var highIndex = list.Count - 1;

        while (lowIndex < highIndex) {
            var lowNode = list[lowIndex];
            var highNode = list[highIndex];

            // Point the high node to the remaining part of the linked list
            highNode.next = lowNode.next;

            // Point the low node to the high node, which is connected to the rest of the list
            lowNode.next = highNode;

            ++lowIndex;
            --highIndex;
        }

        // The middlemost node in the arraylist corresponds to the last node in the linked list.
        // Set the last node in the linked list to null, else the last node will be connected to itself
        list[0 == list.Count % 2 ? lowIndex : highIndex].next = null;
    }
}