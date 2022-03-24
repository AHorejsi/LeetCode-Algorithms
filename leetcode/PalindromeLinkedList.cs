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
        // Used to reverse the order of the linked list
        Stack<int> stack = new Stack<int>();
        
        // After insertion, the stack will have the
        // the same values as the linked list, but in
        // reverse order. If the linked list is a palindrome,
        // the initial order and the reverse order will be equal
        this.InsertIntoStack(stack, head);
        
        // Removes elements from the stack based on whether or not they are
        // equal to the corresponding elements in the linked list. If there
        // is a point where the initial order and the reverse order are not equal,
        // then elements will remain in the stack. If orders are the same, the stack
        // will be empty
        this.RemoveFromStack(stack, head);
        
        // All elements will be removed from the stack if the reverse order and the initial
        // order are the same
        return 0 == stack.Count;
    }
    
    private void InsertIntoStack(Stack<int> stack, ListNode head) {
        for (ListNode node = head; !(node is null); node = node.next) {
            stack.Push(node.val);
        }
    }
    
    private void RemoveFromStack(Stack<int> stack, ListNode head) {
        // If the linked list is a palindrome, then iterating through
        // the linked list and popping elements off the stack one-by-one
        // will result in the same string on ints
        
        for (ListNode node = head; !(node is null); node = node.next) {
            if (stack.Peek() == node.val) {
                // If the element at the top of the stack is equal to
                // the current element in the linked list, then the
                // linked list has currently retained the properties
                // of a palindrome. Pop the current element off the stack
                // and compare the next element in the linked list to the
                // stack's new top element
                
                stack.Pop();
            }
            else {
                // If the element at the top of the stack is not equal to
                // the current element in the linked list, then the linked
                // list is not a palindrome
                
                break;
            }
        }
    }
}
