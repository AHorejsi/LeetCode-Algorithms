public class Solution {
    public int RemoveDuplicates(int[] nums) {
        switch (nums.Length) {
            case 0:
            case 1:
                return nums.Length;
            case 2:
                return (nums[0] == nums[1]) ? 1 : 2;
        }
        
        int end = 1;
        int i = 0;
        int j = 1;
        
        while (j < nums.Length) {
            while (nums[i] >= nums[j]) {
                ++j;
                
                if (j == nums.Length) {
                    return end;
                }
            }
            
            nums[end] = nums[j];
            
            i = j;
            ++j;
            ++end;
        }
        
        return end;
    }
}