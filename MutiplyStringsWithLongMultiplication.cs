public class Solution {
    // Represents the base of the numbers that "Multiply" will operate on
    private const int Radix = 10;

    // Multiplies "num1" and "num2" using the rules of long multiplication.
    // Both "num1" and "num2" must consist of digits only
    public string Multiply(string num1, string num2) {
        // If either number is zero, then the product is also zero
        if ("0" == num1 || "0" == num2) {
            return "0";
        }

        // Multiply the digits of both integers using the rules of long multiplication
        // in order to compute the integers to add together while doing long multiplication
        var adds = this.ComputeNumbersToAdd(num1, num2);

        // Add the previously computed integers together
        var product = this.AddNumbers(adds);

        // Up to this point, we have been storing the digits of our digits in reverse order
        // because the rules of long multiplication require that multiply digits from right to left
        // digits and we have been inserting digits into each "StringBuilder" from left to right.
        // Therefore, we must reverse the "StringBuilder" before returning
        this.Reverse(product);

        return product.ToString();
    }

    // As per the first step of long multiplication, we must compute a list of integers that we will later
    // add together by multiplying each digit of "num1" to each digit of "num2"
    private List<StringBuilder> ComputeNumbersToAdd(string num1, string num2) {
        // Ensure that "num1" is the shorter of the two integers.
        // Necessary so that correct amount of integers
        // are added together later as per the rules of long multiplication
        if (num1.Length > num2.Length) {
            var temp = num1;
            num1 = num2;
            num2 = temp;
        }

        // Will contain the integers that will later be added together
        var adds = new List<StringBuilder>(num1.Length);

        // Represents the final indices of both integers
        var endIndex1 = num1.Length - 1;
        var endIndex2 = num2.Length - 1;

        for (var index1 = endIndex1; index1 >= 0; --index1) {
            // Integer representation of the current digit of the first integer
            var digit1 = (int)char.GetNumericValue(num1[index1]);

            // Will contain the digits of the integer that will
            // be added together as per the rules of long multiplication.
            // Because we are moving from right to left for both "num1" and
            // "num2", this will have its digits stored from right to left due
            // to how the "Append" function of StringBuilder adds characters to
            // the left side first
            var addNum = new StringBuilder(num1.Length + 1);

            // Represents the carried digit in long multiplication. Must be
            // initialized to zero
            var carry = 0;

            // As per the rules of long multiplication, add the appropriate amount
            // of zeroes to the end of "addNum". Amount of zeroes to add is equal to
            // the amount of previously processed digits of "num1"
            this.AddZeroes(addNum, endIndex1 - index1);

            for (var index2 = endIndex2; index2 >= 0; --index2) {
                // Integer representation of the current digit of the second integer
                var digit2 = (int)char.GetNumericValue(num2[index2]);

                // Compute the product of the current digits and include the previously carried digit
                var digitResult = digit1 * digit2 + carry;

                // Compute the next value to carry. If "digitResult" is a single digit integer,
                // there is no digit to carry to the next operation. Otherwise, carry the first
                // digit of "digitResult"
                if (digitResult < Solution.Radix) {
                    carry = 0;
                }
                else {
                    carry = (int)(digitResult / Math.Pow(Solution.Radix, (int)Math.Log10(digitResult)));
                }

                // Include the last digit of "digitResult" as part of our current number
                addNum.Append(digitResult % Solution.Radix);
            }

            // If we have reached to end of "num2" and there is still a nonzero value left over, we must include
            // it in our current number
            if (0 != carry) {
                addNum.Append(carry);
            }

            adds.Add(addNum);
        }

        return adds;
    }

    private void AddZeroes(StringBuilder num, int amountToAdd) {
        for (var count = 0; count < amountToAdd; ++count) {
            num.Append('0');
        }
    }

    // As per the second step of long multiplication, we add the integers 
    // from the first step together
    private StringBuilder AddNumbers(IList<StringBuilder> numList) {
        // Will contain the digits of our final product in reverse order
        // because the digits of the integers in "numList" are in reverse order
        var totalSum = numList[0];

        foreach (var num in numList.Skip(1)) {
            // Current index of "num"
            var numIndex = 0;

            // Current index of "totalSum"
            var sumIndex = 0;

            // Represents whether or not to carry a one during long addition.
            // Initialized to false because there is no previous sum to carry from
            var carryOne = false;

            // The longest potential length of the result of the next sum
            var length = Math.Max(num.Length, totalSum.Length);

            // Will contain the digits of the next sum
            var currentSum = new StringBuilder(length);

            while (numIndex < length) {
                // Current digit of the new number to add to the current sum
                var numDigit = this.GetDigit(num, numIndex);

                // Current digit of the current sum
                var sumDigit = this.GetDigit(totalSum, sumIndex);

                // Sum of current digits
                var digitResult = numDigit + sumDigit;

                // Carry the one from the sum of the previous digits
                if (carryOne) {
                    ++digitResult;
                }

                // Carry a one to the next sum of digits if the current
                // sum of digits is greater than nine
                carryOne = digitResult >= Solution.Radix;

                // Add the last digit to our current sum
                currentSum.Append(digitResult % Solution.Radix);

                // Move to the next digits of our current sum and our current number
                ++numIndex;
                ++sumIndex;
            }

            // If there is still a one left over, need to add a one to out current sum
            if (carryOne) {
                currentSum.Append('1');
            }

            // Set the current sum to out total sum
            totalSum = currentSum;
        }

        return totalSum;
    }

    private int GetDigit(StringBuilder num, int index) => index >= num.Length ? 0 : (int)char.GetNumericValue(num[index]);

    private void Reverse(StringBuilder str) {
        // Set the indices to the leftmost and rightmost characters
        var lowIndex = 0;
        var highIndex = str.Length - 1;

        while (lowIndex < highIndex) {
            // Swap the current left-hand and right-hand characters
            var temp = str[lowIndex];
            str[lowIndex] = str[highIndex];
            str[highIndex] = temp;

            // Move the left-hand and right-hand indices inward
            ++lowIndex;
            --highIndex;
        }
    }
}
