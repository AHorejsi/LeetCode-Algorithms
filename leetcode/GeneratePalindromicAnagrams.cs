public class Solution {
    private sealed class State : IEnumerable<(char, int)> {
        private struct Result {
            private char[] data;
            private int index;

            public Result(int length) {
                this.data = new char[length];
                this.index = 0;
            }

            public int Length {
                get => this.index;
                set {
                    this.index = value;
                }
            }

            public char this[int inIndex] => this.data[inIndex];

            public void PushBack(char val) {
                this.data[this.index] = val;
                ++(this.index);
            }

            public void PopBack() {
                --(this.index);
            }

            public override string ToString() => new string(this.data, 0, this.index);
        }
        
        private sealed class CharCounter {
            public int PrefixCount = 0;
            public int SuffixCount = 1;

            public void MoveToPrefix() {
                ++(this.PrefixCount);
                --(this.SuffixCount);
            }

            public void MoveToSuffix() {
                --(this.PrefixCount);
                ++(this.SuffixCount);
            }
        }
        
        private IDictionary<char, CharCounter> charData;
        private int suffixCount;
        private Result current;
        private int endLength;
        private int mismatchDifference;
        
        public State(string str) {
            int length = str.Length;
            
            this.charData = new Dictionary<char, CharCounter>(length);
            this.suffixCount = length;
            this.current = new Result(length);
            this.endLength = length / 2;
            this.mismatchDifference = length % 2;
            
            this.InitializeMap(str);
        }
        
        private void InitializeMap(string str) {            
            foreach (char val in str) {
                CharCounter data;
                
                if (this.charData.TryGetValue(val, out data)) {
                    ++(data.SuffixCount);
                }
                else {
                    this.charData.Add(val, new CharCounter());
                }
            }
        }
        
        public bool Terminal => this.suffixCount == this.endLength;
        
        public void MoveToPrefix(char val) {
            this.charData[val].MoveToPrefix();
            --(this.suffixCount);
            this.current.PushBack(val);
        }
        
        public void MoveToSuffix(char val) {
            this.charData[val].MoveToSuffix();
            ++(this.suffixCount);
            this.current.PopBack();
        }
        
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<(char, int)>)this).GetEnumerator();
        
        public IEnumerator<(char, int)> GetEnumerator() {
            foreach (KeyValuePair<char, CharCounter> kvp in this.charData) {
                yield return (kvp.Key, kvp.Value.SuffixCount);
            }
        }
        
        public string Check() => this.CanMirror() ? this.DoMirror() : null;
        
        private bool CanMirror() {            
            char skipValue = 0 == this.mismatchDifference ? '\u0000' : this.current[this.current.Length - 1];
            int count = 0;
            
            foreach ((char val, CharCounter counter) in this.charData) {
                count += Math.Abs(counter.PrefixCount - counter.SuffixCount);
                
                if (val != skipValue && counter.PrefixCount > counter.SuffixCount || count > this.mismatchDifference) {
                    return false;
                }
            }
            
            return true;
        }
        
        private string DoMirror() {
            int initialLength = this.current.Length;
            
            for (int index = initialLength - this.mismatchDifference - 1; index >= 0; --index) {
                this.current.PushBack(this.current[index]);
            }
            
            string output = this.current.ToString();
            this.current.Length = initialLength;
            
            return output;
        }
    }
    
    public IList<string> GeneratePalindromes(string str) {
        State state = new State(str);
        IList<string> palindromes = new List<string>();

        this.FindPalindromes(state, palindromes);

        return palindromes;
    }
    
    private void FindPalindromes(State state, IList<string> palindromes) {
        if (state.Terminal) {
            string potential = state.Check();

            if (!(potential is null)) {
                palindromes.Add(potential);
            }
        }
        else {
            foreach ((char val, int count) in state) {
                if (0 != count) {
                    state.MoveToPrefix(val);
                    this.FindPalindromes(state, palindromes);
                    state.MoveToSuffix(val);
                }
            }
        }
    }
}