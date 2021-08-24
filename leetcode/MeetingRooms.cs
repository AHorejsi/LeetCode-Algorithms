public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        if (0 == intervals.Length) {
            return true;
        }
        else {
            Array.Sort(intervals, (int[] left, int[] right) => left[0] - right[0]);
        
            int[] prev = intervals[0];

            for (int index = 1; index < intervals.Length; ++index) {
                if (prev[1] <= intervals[index][0]) {
                    prev = intervals[index];
                }
                else {
                    return false;
                }
            }

            return true;
        }
    }
}