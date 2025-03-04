class Solution {
    private static class Counter implements Comparable<Counter> {
        private int value;
        private int amount;
        
        public Counter(int value) {
            this.value = value;
            this.amount = 1;
        }
        
        public int getValue() {
            return this.value;
        }
        
        public int getAmount() {
            return this.amount;
        }
        
        public void AddValue() {
            ++(this.amount);
        }
        
        @Override
        public int compareTo(Counter other) {
            return other.amount - this.amount;
        }
    }
    
    public int[] topKFrequent(int[] nums, int amount) {
        int minValue = this.findMin(nums);
        int maxValue = this.findMax(nums);
        int size = maxValue - minValue + 1;
        
        Counter[] counts = this.countNums(nums, size, minValue);
        PriorityQueue<Counter> queue = this.buildQueue(counts);
        int[] mostFrequent = this.removeMostFrequent(queue, amount);
        
        return mostFrequent;
    }
    
    private int findMin(int[] nums) {
        int minValue = Integer.MAX_VALUE;
        
        for (int val : nums) {
            if (val < minValue) {
                minValue = val;
            }
        }
        
        return minValue;
    }
    
    private int findMax(int[] nums) {
        int maxValue = Integer.MIN_VALUE;
        
        for (int val : nums) {
            if (val > maxValue) {
                maxValue = val;
            }
        }
        
        return maxValue;
    }
    
    private Counter[] countNums(int[] nums, int size, int minValue) {
        Counter[] counts = new Counter[size];
        
        for (int val : nums) {
            if (null == counts[val - minValue]) {
                counts[val - minValue] = new Counter(val);
            }
            else {
                counts[val - minValue].AddValue();
            }
        }
        
        return counts;
    }
    
    private PriorityQueue<Counter> buildQueue(Counter[] counts) {
        PriorityQueue<Counter> queue = new PriorityQueue<>();
        
        for (Counter counter : counts) {
            if (!(null == counter)) {
                queue.offer(counter);
            }
        }
        
        return queue;
    }
    
    private int[] removeMostFrequent(PriorityQueue<Counter> queue, int total) {
        int[] mostFrequent = new int[total];
        
        for (int index = 0; index < total; ++index) {
            mostFrequent[index] = queue.poll().getValue();
        }
        
        return mostFrequent;
    }
}