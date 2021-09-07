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
    public bool IsPalindrome(ListNode head) {
        Stack<int> stack = new Stack<int>();
        
        this.InsertIntoStack(stack, head);
        this.RemoveFromStack(stack, head);
        
        return 0 == stack.Count;
    }
    
    private void InsertIntoStack(Stack<int> stack, ListNode head) {
        for (ListNode node = head; !(node is null); node = node.next) {
            stack.Push(node.val);
        }
    }
    
    private void RemoveFromStack(Stack<int> stack, ListNode head) {
        for (ListNode node = head; !(node is null); node = node.next) {
            if (stack.Peek() == node.val) {
                stack.Pop();
            }
            else {
                break;
            }
        }
    }
}