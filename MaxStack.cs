public sealed class MaxStack {
    private LinkedList<int> stack = new LinkedList<int>();
    private SortedDictionary<int, List<LinkedListNode<int>>> map = new SortedDictionary<int, List<LinkedListNode<int>>>();

    /** initialize your data structure here. */
    public MaxStack() {}
    
    public void Push(int element) {
        this.stack.AddLast(element);
        
        List<LinkedListNode<int>> nodes;
        if (this.map.TryGetValue(element, out nodes)) {
            nodes.Add(this.stack.Last);
        }
        else {
            this.map.Add(element, new List<LinkedListNode<int>>() { this.stack.Last });
        }
    }
    
    public int Top() => this.stack.Last.Value;
    
    public int Pop() {
        int element = this.Top();
        this.RemoveNode(element);
        
        return element;
    }
    
    public int PeekMax() => this.map.Keys.Last();
    
    public int PopMax() {
        int element = this.PeekMax();
        this.RemoveNode(element);
        
        return element;
    }
    
    private void RemoveNode(int element) {
        List<LinkedListNode<int>> nodes = this.map[element];
        
        this.stack.Remove(nodes[nodes.Count - 1]);
        nodes.RemoveAt(nodes.Count - 1);
        
        if (0 == nodes.Count) {
            this.map.Remove(element);
        }
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */