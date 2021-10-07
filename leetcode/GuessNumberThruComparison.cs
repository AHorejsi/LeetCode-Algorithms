/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int value) {
        if (1 == value) {
            return value;
        }
        else {
            long low = 1;
            long high = value + 1L;
            int result = -1;

            while (low <= high) {
                result = (int)(low + (high - low) / 2);
                int guessComparison = this.guess(result);

                if (guessComparison > 0) {
                    low = result;
                }
                else if (guessComparison < 0) {
                    high = result;
                }
                else {
                    break;
                }
            }

            return result;
        }
    }
}