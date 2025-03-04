public class Solution {
    public string DecodeString(string str) => this.ParseString(str, 0).ToString();
    
    private StringBuilder ParseString(string str, int index) {
        StringBuilder sb = new StringBuilder();
        
        while (index < str.Length) {
            // The current character of the string to decode
            char val = str[index];
        
            if (char.IsLetter(val)) {
                // If "val" is a letter, then the current subcomponent
                // is just a single character
                
                sb.Append(val);
                ++index;
            }
            else {
                // In this case, the current subcomponent is a substring
                // that needs to be copied some number of times. This substring
                // may contain its own subcomponents, so we will recursively call
                // "ParseString" on the the current subcomponent
                
                // The starting index of "str" that contains the substring to copy
                int subStartIndex = this.FindStartBracket(str, index);
                
                // The ending index of "str" that contains the substring to copy
                int subEndIndex = this.FindEndBracket(str, subStartIndex);
                
                // The length of the substring of "str"
                int subLength = subEndIndex - subStartIndex;
                
                // The number of times "substr" is to be copied during decoding
                int subcount = this.ParseNumber(str, index, subStartIndex - 1);
                
                // The substring that may contain its own subcomponents and needs
                // to be copied "subcount" amount of times after its own subcomponents
                // are decoded
                string substr = str.Substring(subStartIndex, subLength);
                
                // Decode the subcomponent represented by "substr"
                StringBuilder subSB = this.ParseString(substr, 0);
                
                // Copy the results of parsing the current subcomponent into
                // this component "subcount" times
                for (int amount = 0; amount < subcount; ++amount) {
                    sb.Append(subSB);
                }
                
                // Move to the next subcomponent
                index = subEndIndex + 1;
            }
        }
        
        return sb;
    }
    
    private int FindStartBracket(string str, int strIndex) {
        // The index of the starting, enclosing brackets in "str"
        int index = strIndex;
        
        // Search for the starting, enclosing bracket
        while (index < str.Length && '[' != str[index]) {
            ++index;
        }
        
        // Return "+ 1" because the substring to copy is one index after the
        // starting bracket
        return index + 1;
    }
    
    private int FindEndBracket(string str, int startBracketIndex) {
        // Represents the number of subcomponents currently being traversed.
        // Need this because we need to stop traversing once the end of the
        // current subcomponent has been found. Inner subcomponents will have
        // their ending, enclosing brackets occur before the ending, enclosing
        // bracket of the current subcomponent
        int startBracketCount = 1;
        
        // The index of the ending, enclosing bracket in "str"
        int index = startBracketIndex;
        
        while (index < str.Length) {
            // The current character
            char ch = str[index];
            
            if ('[' == ch) {
                // If another starting, enclosing bracket is found, then an inner
                // subcomponent has been found. We must skip over the inner subcomponents
                // ending, enclosing bracket to avoid terminating this loop too early.
                ++startBracketCount;
            }
            else if (']' == ch) {
                // If an ending, enclosing bracket is found, then the end of the last
                // seen subcomponent has been found. The incrementing of "startBracketCount"
                // in the first if-condition and the decrementing of "startBracketCount" in this
                // if-condition ensures that the below break statement will only be executed if
                // the number of starting, enclosing brackets found equals the the number of
                // ending, enclosing brackets
                --startBracketCount;
                
                if (0 == startBracketCount) {
                    break;
                }
            }
            
            ++index;
        }
        
        return index;
    }
    
    // Converts the range specified to an int
    private int ParseNumber(string str, int startIndex, int endIndex) {
        // The position of the current digit should be the exponent of 10
        int exponent = 0;
        
        // The number represented in the range specified by "startIndex" and "endIndex"
        int number = 0;
        
        for (int index = endIndex - 1; index >= startIndex; --index) {
            number += (str[index] - '0') * (int)Math.Pow(10, exponent);
            ++exponent;
        }
        
        return number;
    }
    
    // Refers to a component of an encoded string
    public sealed class Element {
        // The number of times "this.Str" will be repeated in the final, decoded string
        public int Count { get; }
        
        // The substring to be repeated "this.Count" times
        public String Str { get; }
        
        public Element(int count, string str) {
            this.Count = count;
            this.Str = str;
        }
        
        // Inserts the decoded substring into a StringBuilder
        public void Parse(StringBuilder sb) {
            for (int amount = 0; amount < this.Count; ++amount) {
                sb.Append(this.Str);
            }
        }
    }
}
