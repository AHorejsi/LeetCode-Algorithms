public class RandomizedSet {
    // Random number generator to select indices randomly
    private static readonly Random Rand = new Random();
    
    // Map the values to their index in "list"
    private IDictionary<int, int> map;
    
    // Contains the values to be selected randomly
    private IList<int> list;

    public RandomizedSet() {
        this.map = new Dictionary<int, int>();
        this.list = new List<int>();
    }
    
    public bool Insert(int val) {
        if (this.map.ContainsKey(val)) {
            return false;
        }
        else {
            this.map.Add(val, this.list.Count);
            this.list.Add(val);
            
            return true;
        }
    }
    
    public bool Remove(int val) {
        if (this.map.ContainsKey(val)) {
            // Get the last element in "list" and the index of the element to be removed
            int last = this.list[this.list.Count - 1];
            int index = this.map[val];
            
            // Assign the last element to the index of the element to be removed.
            // The last element is now assigned to the last index and "index",
            // effectively removing "val" from the set
            this.list[index] = last;
            this.map[last] = index;
            
            // Remove the last element. Now "last" is only assigned to "index"
            this.list.RemoveAt(this.list.Count - 1);
            this.map.Remove(val);
            
            return true;
        }
        
        return false;
    }
    
    public int GetRandom() {
        int randIndex = RandomizedSet.Rand.Next(this.list.Count);
        
        return this.list[randIndex];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */