class Solution {
    public int minMeetingRooms(int[][] intervals) {
        if (0 == intervals.length) {
            return 0;
        }
        else {
            Arrays.sort(intervals, (int[] left, int[] right) -> left[0] - right[0]);
        
            PriorityQueue<Integer> used = new PriorityQueue<Integer>(intervals.length);
            used.add(intervals[0][1]);

            for (int index = 1; index < intervals.length; ++index) {
                int[] current = intervals[index];
                
                if (current[0] >= used.peek()) {
                    used.poll();
                }
                
                used.add(current[1]);
            }

            return used.size();
        }
    }
}