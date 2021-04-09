using System.Text.RegularExpressions;

public class Solution {
    public bool IsNumber(string str) => new Regex(@"^\s*([+-]?(\d+|\d+\.|\.\d+|\d+\.\d+))([eE][+-]?\d+)?\s*$").IsMatch(str);
}