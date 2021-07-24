public class MinStack {    
    private Stack<int> main = new Stack<int>();
    private Stack<int> mins = new Stack<int>();

    /** initialize your data structure here. */
    public MinStack() {}
    
    public void Push(int val) {
        this.main.Push(val);
        
        if (0 == this.mins.Count || mins.Peek() >= val) {
            this.mins.Push(val);
        }
    }
    
    public void Pop() {
        int popValue = this.main.Pop();
        
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

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */