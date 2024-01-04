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
    public ListNode addTwoNumbers(ListNode left, ListNode right) {
        // Deques represent the linked lists in reverse order
        ArrayDeque<Integer> leftDeque = this.BuildDeque(left);
        ArrayDeque<Integer> rightDeque = this.BuildDeque(right);
        
        // Prepend the shorter number with zeroes so that the lengths
        // of each number matches
        this.PrependZeroes(leftDeque, rightDeque);
        
        return this.ComputeResult(leftDeque, rightDeque);
    }
    
    private ArrayDeque<Integer> BuildDeque(ListNode node) {
        ArrayDeque<Integer> deque = new ArrayDeque<Integer>();
        
        while (!(null == node)) {
            deque.addFirst(node.val); // Use "addFirst" to get numbers represented by the linked lists in reverse order
            node = node.next;
        }
        
        return deque;
    }
    
    private void PrependZeroes(ArrayDeque<Integer> leftDeque, ArrayDeque<Integer> rightDeque) {
        if (leftDeque.size() > rightDeque.size()) {
	    // If left deque is longer than right deque, 
	    // swap both variables so that we end up prepending the shorter one with zeroes
		
            ArrayDeque<Integer> temp = leftDeque;
            leftDeque = rightDeque;
            rightDeque = temp;
        }
        
	// Prepend shorter deque with zeroes
        while (leftDeque.size() < rightDeque.size()) {
            leftDeque.addLast(0);
        }
    }
    
    private ListNode ComputeResult(ArrayDeque<Integer> left, ArrayDeque<Integer> right) {
	// Current node to be filled in with a value for the output list
        ListNode node = new ListNode();
		
	// Represents whether or not the previous addition of two digits
	// means that a one needs to be carried to the next addition of
	// two digits
        boolean carryOne = false;
        
	// Since the shorter number was prepended with zeroes, both deques
	// have the same size. Therefore, we only have to check if one of them is empty
        while (!left.isEmpty()) {
		// Digit of left number
            	int leftDigit = left.removeFirst();
			
		// Digit of right number
            	int rightDigit = right.removeFirst();
			
		// Sum of both digits
            	int result = leftDigit + rightDigit;
            
		// If previous addition of digits caused in "result",
		// being 10 or more, then add one
	    	if (carryOne) {
			++result;
	    	}
            
		// If current addition of digits and carrying the one
		// caused "result" being 10 or more, then subtracted 10
		// from "result" and set "carryOne" to true. Otherwise
		// set "carryOne" to false
		if (result >= 10) {
			result -= 10;
			carryOne = true;
		}
		else {
			carryOne = false;
		}
            
		// Assign new digit to the current node
            	node.val = result;
            
		// Create a new node and attach to the node that was just
		// assigned a digit
            	ListNode newNode = new ListNode();
            	newNode.next = node;
            	node = newNode;
	}
        
	// If "carryOne" is true after adding all numbers, output value
	// must be prepended with a 1. Otherwise, we have an extra node
	// in the front of the list because create a new node
	// at the end of each iteration of the above loop. So we return "node.next"
        if (carryOne) {
            node.val = 1;
            
            return node;
        }
        else {
            return node.next;
        }
    }
}
