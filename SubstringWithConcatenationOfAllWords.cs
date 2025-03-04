public class Solution {
    public IList<int> FindSubstring(string str, string[] words) {
        var output = new List<int>();
        var wordCounter = this.CountWords(words);

        var wordLength = words[0].Length;
        var wordCount = words.Length;
        var targetLength = wordLength * wordCount;
        var endIndex = str.Length - targetLength;

        for (var range = new IndexRange(0, targetLength, wordLength); range.StartIndex <= endIndex; ++(range.StartIndex)) {            
            if (this.CheckSubstring(str, wordCounter, range)) {
                output.Add(range.StartIndex);
            }
        }

        return output;
    }

    private Dictionary<string, int> CountWords(string[] words) {
        var wordCounter = new Dictionary<string, int>(words.Length);

        foreach (var word in words) {
            if (wordCounter.ContainsKey(word)) {
                ++(wordCounter[word]);
            }
            else {
                wordCounter.Add(word, 1);
            }
        }

        return wordCounter;
    }

    private bool CheckSubstring(string str, Dictionary<string, int> wordCounter, IndexRange range) {
        var wordCounterCopy = new Dictionary<string, int>(wordCounter);

        foreach (var word in range.Words(str)) {
            if (!wordCounterCopy.ContainsKey(word)) {
                return false;
            }
            else {
                var newCount = --(wordCounterCopy[word]);

                if (-1 == newCount) {
                    return false;
                }
            }
        }

        return true;
    }

    private struct IndexRange {
        public int StartIndex { get; set; }
        private int totalLength { get; init; }
        private int wordLength { get; init; }

        public IndexRange(int startIndex, int totalLength, int wordLength) {
            this.StartIndex = startIndex;
            this.totalLength = totalLength;
            this.wordLength = wordLength;
        }

        public IEnumerable<string> Words(string str) {
            var endIndex = this.StartIndex + this.totalLength;

            for (var index = this.StartIndex; index < endIndex; index += this.wordLength) {
                yield return str.Substring(index, this.wordLength);
            }
        }
    }
}
