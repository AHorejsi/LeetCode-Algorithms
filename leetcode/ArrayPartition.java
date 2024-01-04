class Solution {
    public int arrayPairSum(int[] nums) {
        // Because we have to take the minimum of each grouping of values,
        // getting the values in numeric order will ensure the smallest gap
        // between each pairing of values and therefore lead to the highest sum
        PriorityQueue<Integer> heap = this.InitializeHeap(nums);
        
        // The maximum sum of the minimum of each grouping
        int sum = 0;
        
        while (!heap.isEmpty()) {
            // We can remove two values from the heap without fear of
            // an exception because "nums" is guaranteed to be of even length.
            // "val1" and "val2" are the current grouping
            int val1 = heap.poll();
            int val2 = heap.poll();
            
            sum += Math.min(val1, val2);
        }
        
        return sum;
    }
    
    private PriorityQueue<Integer> InitializeHeap(int[] nums) {
        // Initialize the heap with all of the values of "nums" so that
        // the values of "nums" can be retrieved in numeric order. 
        
        PriorityQueue<Integer> heap = new PriorityQueue<Integer>();
        
        for (int val : nums) {
            heap.add(val);
        }
        
        return heap;
    }
}
