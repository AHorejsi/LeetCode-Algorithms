public class Solution {
    public bool IsOneEditDistance(string str1, string str2) {
        if (str1.Length == str2.Length) {
            return this.CheckReplace(str1, str2);
        }
        else if (str1.Length + 1 == str2.Length) {
            return this.CheckInsert(str1, str2);
        }
        else if (str1.Length == str2.Length + 1) {
            return this.CheckInsert(str2, str1);
        }
        else {
            return false;
        }
    }
    
    private bool CheckReplace(string str1, string str2) {
        int maxDifferences = 1;
        int differenceCount = 0;
        
        for (int index = 0; index < str1.Length; ++index) {
            if (str1[index] != str2[index]) {
                ++differenceCount;
            }
            
            if (differenceCount > maxDifferences) {
                return false;
            }
        }
        
        return maxDifferences == differenceCount;
    }
    
    private bool CheckInsert(string str1, string str2) {
        int indexOfStr1 = 0;
        int indexOfStr2 = 0;
        
        while (indexOfStr1 < str1.Length && str1[indexOfStr1] == str2[indexOfStr2]) {
            ++indexOfStr1;
            ++indexOfStr2;
        }
        
        ++indexOfStr2;
        
        while (indexOfStr2 < str2.Length) {
            if (str1[indexOfStr1] != str2[indexOfStr2]) {
                return false;
            }
            
            ++indexOfStr1;
            ++indexOfStr2;
        }
        
        return true;
    }
}