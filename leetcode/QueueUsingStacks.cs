public class MyQueue {
    private Stack<int> stack;
    private Stack<int> reverse;

    /** Initialize your data structure here. */
    public MyQueue() {
        this.stack = new Stack<int>();
        this.reverse = new Stack<int>();
    }
    
    /** Push element to the back of queue. */
    public void Push(int elem) {
        this.stack.Push(elem);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        this.MoveIfNeeded();
        return this.reverse.Pop();
    }
    
    /** Get the front element. */
    public int Peek() {
        this.MoveIfNeeded();
        return this.reverse.Peek();
    }
    
    private void MoveIfNeeded() {
        if (0 == this.reverse.Count) {
            while (0 != this.stack.Count) {
                this.reverse.Push(this.stack.Pop());
            }
        }
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() => 0 == (this.stack.Count + this.reverse.Count);
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */