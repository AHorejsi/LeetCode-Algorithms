/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode list1, ListNode list2) {
        Stack<ListNode> stack1 = this.BuildStack(list1);
        Stack<ListNode> stack2 = this.BuildStack(list2);

        ListNode node1 = null;
        ListNode node2 = null;

        ListNode result = null;

        while (0 != stack1.Count && 0 != stack2.Count) {
            node1 = stack1.Pop();
            node2 = stack2.Pop();

            if (object.ReferenceEquals(node1, node2)) {
                result = node1;
            }
            else {
                break;
            }
        }

        return result;
    }
    
    private Stack<ListNode> BuildStack(ListNode list) {
        Stack<ListNode> stack = new Stack<ListNode>();
        
        while (!(list is null)) {
            stack.Push(list);
            list = list.next;
        }
        
        return stack;
    }
}