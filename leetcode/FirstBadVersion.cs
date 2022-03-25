/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int versionCount) {
        // The lower bound on the binary search
        int lowVersion = 1;
        
        // The upper bound on the binary search
        int highVersion = versionCount;
        
        while (lowVersion <= highVersion) {
            // The version that is the midpoint
            int midVersion = lowVersion + (highVersion - lowVersion) / 2;
            
            if (this.IsBadVersion(midVersion)) {
                // If "midversion" is bad, it is possible that it is not the FIRST
                // bad version
                
                if (!this.IsBadVersion(midVersion - 1)) {
                    // If "midVersion - 1" is good, then "midVersion" is the
                    // first bad version. Return it
                    return midVersion;
                }
                else {
                    // If "midVersion - 1" is also bad, then "midVersion" is not
                    // the FIRST bad version. Therefore we must continue searching.
                    // Since all versions after the first bad version are also bad,
                    // The first bad version is before "midVersion"
                    highVersion = midVersion - 1;
                }
            }
            else {
                // If "midVersion" is good, then all prior versions
                // are good as well
                lowVersion = midVersion + 1;
            }
        }
        
        // In this case, there is no 
        return -1;
    }
}
