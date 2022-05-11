public class Solution {
    public int LastRemaining(int max) {
        // The value currently at the head of the list
        int head = 1;
        
        // The distance from the current "head" to the next "head"
        int step = 1;
        
        // The amount of values left in the list
        int count = max;
        
        // Indicates whether or not we are doing a left
        // or right traversal
        bool movingLeft = true;
        
        while (1 != count) {
            if (movingLeft || 1 == count % 2) {
                // If moving left, the head of the list is guaranteed to be removed.
                // If moving right and the length of the list is odd, the head of the
                // list is guaranteed to be removed. In either case, "head" needs to be
                // updated
                
                head += step;
            }
            
            // The distance from current "head" to the next "head", increases
            // by a factor of 2 based on whether or not the head was removed
            step *= 2;
            
            // Swap direction of traversal
            movingLeft = !movingLeft;
            
            // By removing every other element, the list's size has been halved
            count /= 2;
        }
        
        return head;
    }
}
