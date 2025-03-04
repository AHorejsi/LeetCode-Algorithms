public class MinStack {
	// Represents the main stack. This stack does not track
	// anything regarding the minimum value
    private Stack<int> main = new Stack<int>();
	
	// Tracks the minimum element. The topmost element is the
	// current smallest value. The second topmost element is the
	// second smallest value and so on
    private Stack<int> mins = new Stack<int>();

    public MinStack() {}
    
    public void Push(int val) {
		// Insert the element into the "mins" stack if  the
		// whole stack is empty or if the current minimum value
		// is greater than or equal to the new element. The reason
		// why add equal values as well is because we need to remove
		// the correct instance of the minimum value even if there
		// are duplicates
        if (0 == this.main.Count || this.mins.Peek() >= val) {
            this.mins.Push(val);
        }
        
        // Insert the new element into the main stack
        this.main.Push(val);
    }
    
    public void Pop() {
		// Remove the top element of "main"
        int popValue = this.main.Pop();
        
		// Because of the condition that determines how elements are
		// added to the "mins" stack in the "Push" function, if the top
		// element of the "main" stack equals the top element of the "mins"
		// stack, then they are the same instance of the given value
        if (this.mins.Peek() == popValue) {
            this.mins.Pop();
        }
    }
    
    public int Top() {
        return this.main.Peek();
    }
    
    public int GetMin() {
        return this.mins.Peek();
    }
}
