using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result {

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr) {
        long fullSum = arr.Select((int val) => (long)val).Sum();
        
        long minSum = long.MaxValue;
        long maxSum = long.MinValue;
        
        foreach (int val in arr) {
            long sumOfFour = fullSum - val;
            
            if (sumOfFour < minSum) {
                minSum = sumOfFour;
            }
            if (sumOfFour > maxSum) {
                maxSum = sumOfFour;
            }
        }
        
        Console.WriteLine($"{minSum} {maxSum}");
    }
}

class Solution {
    public static void Main(string[] args) {
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
