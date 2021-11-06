public class Solution {
    private sealed class Position : IEquatable<Position> {
        public int Row { get; }
        public int Column { get; }
        
        public Position(int row, int column) {
            this.Row = row;
            this.Column = column;
        }
        
        public bool Equals(Position other) => this.Row == other.Row && this.Column == other.Column;
        
        public override bool Equals(object obj) => this.Equals(obj as Position);
        
        public static bool operator ==(Position left, Position right) => left.Equals(right);
        
        public static bool operator !=(Position left, Position right) => !(left == right);
        
        public override int GetHashCode() => HashCode.Combine(this.Row, this.Column);
    }
    
    private sealed class TrieNode {
        public char Value { get; set; }
        public bool EndOfWord { get; set; }
        public string Full { get; set; }
        public IDictionary<char, TrieNode> Children { get; }
        
        public TrieNode(char value) {
            this.Value = value;
            this.EndOfWord = false;
            this.Children = new Dictionary<char, TrieNode>();
        }
    }
    
    public IList<string> FindWords(char[][] board, string[] wordList) {
        TrieNode root = this.BuildTrie(wordList);
        Dictionary<char, IList<string>> wordsByFirstLetter = this.OrganizeWordsByFirstLetter(wordList);
        HashSet<Position> used = new HashSet<Position>(board.Length * board[0].Length);
        HashSet<string> result = new HashSet<string>(wordList.Length);
        
        for (int row = 0; row < board.Length; ++row) {
            for (int col = 0; col < board[row].Length; ++col) {
                char letterInCell = board[row][col];
                
                if (wordsByFirstLetter.ContainsKey(letterInCell)) {
                    TrieNode node = root.Children[letterInCell];
                    Position first = new Position(row, col);
                    
                    this.SearchForWords(board, node, first, used, result);
                }
            }
        }
        
        return result.ToList();
    }
    
    private TrieNode BuildTrie(string[] words) {
        TrieNode root = new TrieNode('\u0000');
        
        foreach (string word in words) {
            (int wordIndex, TrieNode current) = this.PrefixSearch(word, root);
            
            while (wordIndex < word.Length) {
                char ch = word[wordIndex];
                
                TrieNode child = new TrieNode(ch);
                current.Children.Add(ch, child);
                current = child;
                
                ++wordIndex;
            }
            
            current.EndOfWord = true;
            current.Full = word;
        }
        
        return root;
    }
    
    private (int, TrieNode) PrefixSearch(string word, TrieNode root) {
        TrieNode current = root;
        int index = 0;
        
        while (index < word.Length) {
            TrieNode node;
            
            if (current.Children.TryGetValue(word[index], out node)) {
                current = node;
                ++index;
            }
            else {
                break;
            }
        }
        
        return (index, current);
    }
    
    private Dictionary<char, IList<string>> OrganizeWordsByFirstLetter(string[] wordList) {
        Dictionary<char, IList<string>> map = new Dictionary<char, IList<string>>(wordList.Length);
        
        foreach (string word in wordList) {
            char firstLetter = word[0];
            IList<string> wordsUnderLetter;
            
            if (map.TryGetValue(firstLetter, out wordsUnderLetter)) {
                wordsUnderLetter.Add(word);
            }
            else {
                map.Add(firstLetter, new List<string>(wordList.Length));
            }
        }
        
        return map;
    }
    
    private void SearchForWords(char[][] board, TrieNode node, Position current, HashSet<Position> used, HashSet<string> result) {
        if (node.EndOfWord) {
            result.Add(node.Full);
        }
        
        used.Add(current);

        int currentRow = current.Row;
        int currentCol = current.Column;

        if (0 != currentRow) {
            Position up = new Position(currentRow - 1, currentCol);
            this.ProcessPosition(board, node, up, used, result);
        }
        if (0 != currentCol) {
            Position left = new Position(currentRow, currentCol - 1);
            this.ProcessPosition(board, node, left, used, result);
        }
        if (board.Length - 1 != currentRow) {
            Position down = new Position(currentRow + 1, currentCol);
            this.ProcessPosition(board, node, down, used, result);
        }
        if (board[0].Length - 1 != currentCol) {
            Position right = new Position(currentRow, currentCol + 1);
            this.ProcessPosition(board, node, right, used, result);
        }

        used.Remove(current);
    }
    
    private void ProcessPosition(char[][] board, TrieNode node, Position next, HashSet<Position> used, HashSet<string> result) {
        char nextLetter = board[next.Row][next.Column];
        TrieNode nextNode;

        if (!used.Contains(next) && node.Children.TryGetValue(nextLetter, out nextNode)) {
            this.SearchForWords(board, nextNode, next, used, result);
        }
    }
}