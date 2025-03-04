public class Solution {
    public void Rotate(int[] nums, int rotationCount) {
        int minRotationCount = rotationCount % nums.Length;
        (Queue<int> prefix, Queue<int> suffix) = this.ArrangeElements(nums, minRotationCount);
        int index = 0;
        
        while (0 != prefix.Count) {
            nums[index] = prefix.Dequeue();
            ++index;
        }
        
        while (0 != suffix.Count) {
            nums[index] = suffix.Dequeue();
            ++index;
        }
    }
    
    private (Queue<int>, Queue<int>) ArrangeElements(int[] nums, int rotationCount) {
        int length = nums.Length;
        int midpoint = length - rotationCount;
        
        Queue<int> prefix = new Queue<int>(rotationCount);
        Queue<int> suffix = new Queue<int>(midpoint);
        
        int index = 0;
        
        while (index < midpoint) {
            suffix.Enqueue(nums[index]);
            ++index;
        }
        
        while (index < length) {
            prefix.Enqueue(nums[index]);
            ++index;
        }
        
        return (prefix, suffix);
    }
}
