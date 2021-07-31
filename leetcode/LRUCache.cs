public sealed class LRUCache {
    private struct CacheEntry {
        public int Key { get; }
        public int Data { get; }
        
        public CacheEntry(int key, int data) {
            this.Key = key;
            this.Data = data;
        }
    }
    
    private Dictionary<int, LinkedListNode<CacheEntry>> map;
    private LinkedList<CacheEntry> list;
    private int capacity;

    public LRUCache(int capacity) {
        this.map = new Dictionary<int, LinkedListNode<CacheEntry>>(capacity + 1);
        this.list = new LinkedList<CacheEntry>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        LinkedListNode<CacheEntry> node;
        
        if (this.map.TryGetValue(key, out node)) {
            list.Remove(node);
            list.AddFirst(node);
            
            return node.Value.Data;
        }
        else {
            return -1;
        }
    }
    
    public void Put(int key, int data) {          
        this.InsertIntoCollection(key, data);
        this.RemoveLeastRecentlyUsedIfNeeded();
    }
    
    private void InsertIntoCollection(int key, int data) {
        LinkedListNode<CacheEntry> node;
        
        if (this.map.TryGetValue(key, out node)) {
            node.Value = new CacheEntry(key, data);
            
            this.list.Remove(node);
            this.list.AddFirst(node);
        }
        else {
            node = new LinkedListNode<CacheEntry>(new CacheEntry(key, data));
            
            this.list.AddFirst(node);
            this.map.Add(key, node);
        }
    }
    
    private void RemoveLeastRecentlyUsedIfNeeded() {
        if (this.list.Count > this.capacity) {
            this.map.Remove(this.list.Last.Value.Key);
            this.list.RemoveLast();
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */