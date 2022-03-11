class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int maxIndexDistance, int maxValueDistance) {
        // Keys are the elements in the array and the Values are the indices in the array
        TreeMap<Integer, Integer> map = new TreeMap<Integer, Integer>();
        
        for (int currentIndex = 0; currentIndex < nums.length; ++currentIndex) {
            // The current element to check
            int currentElem = nums[currentIndex];
            
            // The nearest lower element relative to "currentElem," along with its index in "nums"
            Map.Entry<Integer, Integer> lower = map.floorEntry(currentElem);
            
            // The nearest higher element relative to "currentElem," along with its index in "nums"
            Map.Entry<Integer, Integer> higher = map.ceilingEntry(currentElem);
            
            if (this.CheckIfCloseEnough(lower, currentElem, maxValueDistance) || this.CheckIfCloseEnough(higher, currentElem, maxValueDistance)) {
                // If either value is close enough in value, we have found a pair that satisfies out condition.
                // We know that the pair is close enough in index because we remove elements from "map" based
                // on whether or not future elements will be too far away from any other elements
                
                return true;
            }
            
            // Add the current element and its index to "map"
            // This allows the current element to potentially
            // be matched with other elements for value and index later
            map.put(currentElem, currentIndex);
            
            if (map.size() > maxIndexDistance) {
                // If "map" has grown larger than "maxIndexDistance," then the element that was
                // added to the map "maxIndexDistance" iterations ago will be outside the index range
                // of the next element. Therefore stop tracking that element
                
                map.remove(nums[currentIndex - maxIndexDistance]);
            }
        }
        
        return false;
    }
    
    private boolean CheckIfCloseEnough(Map.Entry<Integer, Integer> nearest, int currentElem, int maxValueDistance) {
        if (null == nearest) {
            // If the one of the nearest elements to "currentElem" is null, then
            // There is either no value less than "currentElem" or no value greater
            // than "currentElem." Therefore ignore this entry
            
            return false;
        }
        
        // The nearest value is not null. Get it as a long to
        // avoid in overflow
        long nearestElem = nearest.getKey().longValue();
        
        // Compute whether or not the two elements are close enough together
        return Math.abs(nearestElem - currentElem) <= maxValueDistance;
    }
}
