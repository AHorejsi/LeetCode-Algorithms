public class Solution {
    public bool IsSubsequence(string str1, string str2) {
        Queue<char> queue = this.CreateQueue(str1);
        
        foreach (char value in str2) {
            if (0 == queue.Count) {
                return true;
            }
            
            if (queue.Peek() == value) {
                queue.Dequeue();
            }
        }
        
        return 0 == queue.Count;
    }
    
    private Queue<char> CreateQueue(string str1) {
        Queue<char> queue = new Queue<char>();
        
        foreach (char value in str1) {
            queue.Enqueue(value);
        }
        
        return queue;
    }
}