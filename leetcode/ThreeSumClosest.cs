public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        
        int closest = int.MaxValue / 10;
        
        for (int i = 0; i < nums.Length; ++i) {
            if (0 == i || nums[i - 1] != nums[i]) {
                closest = this.SearchForClosest(i, nums, target, closest);
                
                if (closest == target) {
                    break;
                }
            }
        }
        
        return closest;
    }
    
    private int SearchForClosest(int i, int[] nums, int target, int closest) {
        int low = i + 1;
        int high = nums.Length - 1;
        
        while (low < high) {
            int sum = nums[i] + nums[low] + nums[high];
            
            int differenceFromSum = target - sum;
            int differenceFromClosest = target - closest;
            int distanceFromSum = Math.Abs(differenceFromSum);
            int distanceFromClosest = Math.Abs(differenceFromClosest);
            
            if (distanceFromSum < distanceFromClosest) {
                closest = sum;
            }
            
            if (differenceFromSum > 0) {
                ++low;
            }
            else if (differenceFromSum < 0) {
                --high;
            }
            else {
                break;
            }
        }
        
        return closest;
    }
}