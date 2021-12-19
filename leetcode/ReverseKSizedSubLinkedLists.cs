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
    public ListNode ReverseKGroup(ListNode head, int sublistSize) {
        ListNode startNode = head;
        bool endReached = false;
        
        while (!endReached) {
            (ListNode endNode, int currentSublistSize) = this.FindEndNode(startNode, sublistSize);
            
            if (endNode is null) {
                endReached = true;
                
                if (sublistSize > currentSublistSize) {
                    break;
                }
            }
            
            this.ReverseRange(startNode, endNode, sublistSize);
            startNode = endNode;
        }
        
        return head;
    }
    
    private (ListNode, int) FindEndNode(ListNode startNode, int sublistSize) {
        ListNode endNode = startNode;
        int count = 0;
        
        while (count < sublistSize) {
            endNode = endNode.next;
             ++count;
            
            if (endNode is null) {
                break;
            }
        }
        
        return (endNode, count);
    }
    
    private void ReverseRange(ListNode startNode, ListNode endNode, int sublistSize) {
        Stack<int> stack = this.BuildStack(startNode, endNode, sublistSize);
        ListNode node = startNode;
        
        while (0 != stack.Count) {
            node.val = stack.Pop();
            node = node.next;
        }
    }
    
    private Stack<int> BuildStack(ListNode startNode, ListNode endNode, int sublistSize) {
        Stack<int> stack = new Stack<int>(sublistSize);
        ListNode node = startNode;
        
        while (!object.ReferenceEquals(node, endNode)) {
            stack.Push(node.val);
            node = node.next;
        }
        
        return stack;
    }
}