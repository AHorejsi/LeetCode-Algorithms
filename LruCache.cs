public class LRUCache {
    private LinkedList<Entry> useOrder; // Specifies the order each element was used. The last element is the least recently used
    private Dictionary<int, LinkedListNode<Entry>> elementData;
    private int capacity; // The capacity that must not be overtaken

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.useOrder = new LinkedList<Entry>();
        this.elementData = new Dictionary<int, LinkedListNode<Entry>>(capacity);
    }
    
    public int Get(int key) {
        LinkedListNode<Entry> node;

        if (this.elementData.TryGetValue(key, out node)) {
            this.MakeMru(node);

            return node.Value.Data;
        }

        return -1;
    }
    
    public void Put(int key, int data) {
        LinkedListNode<Entry> node;

        if (this.elementData.TryGetValue(key, out node)) {
            node.Value = new Entry(key, data);

            this.MakeMru(node);
        }
        else {
            node = new LinkedListNode<Entry>(new Entry(key, data));

            this.useOrder.AddFirst(node);
            this.elementData.Add(key, node);

            this.SatisfyLruConstraints();
        }
    }

    private void MakeMru(LinkedListNode<Entry> node) {
        this.useOrder.Remove(node);
        this.useOrder.AddFirst(node);
    }

    private void SatisfyLruConstraints() {
        if (this.elementData.Count > this.capacity) {
            this.elementData.Remove(this.useOrder.Last.Value.Key);
            this.useOrder.RemoveLast();
        }
    }
}

public struct Entry {
    public int Key;
    public int Data;

    public Entry(int key, int data) {
        this.Key = key;
        this.Data = data;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
