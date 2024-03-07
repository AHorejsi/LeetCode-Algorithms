public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var maxChar = 26;

        var result = new StringBuilder();

        while (columnNumber > 0) {
            var letter = (char)('A' + (columnNumber - 1) % maxChar);

            result.Append(letter);

            columnNumber = (columnNumber - 1) / maxChar;
        }

        this.Reverse(result);

        return result.ToString();
    }

    private void Reverse(StringBuilder sb) {
        var low = 0;
        var high = sb.Length - 1;

        while (low < high) {
            var temp = sb[low];
            sb[low] = sb[high];
            sb[high] = temp;

            ++low;
            --high;
        }
    }
}
