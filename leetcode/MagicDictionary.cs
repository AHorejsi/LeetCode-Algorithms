public sealed class MagicDictionary {
    private sealed class TrieNode {
        public char Character { get; }
        public bool EndOfWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; }
        
        public TrieNode(char character) {
            this.Character = character;
            this.Children = new Dictionary<char, TrieNode>();
        }
    }
    
    private const char RootValue = '\u0000';
    private TrieNode root;

    public MagicDictionary() {
        this.root = new TrieNode(MagicDictionary.RootValue);
    }
    
    public void BuildDict(string[] dictionary) {
        foreach (string word in dictionary) {
            this.Insert(word);
        }
    }
    
    private void Insert(string word) {
        (TrieNode endpoint, int indexOfWord) = this.SearchForEndpoint(word);
        
        for (int index = indexOfWord; index < word.Length; ++index) {
            char ch = word[index];
            
            TrieNode newNode = new TrieNode(ch);
            endpoint.Children.Add(ch, newNode);
            
            endpoint = newNode;
        }
        
        endpoint.EndOfWord = true;
    }
    
    private (TrieNode, int) SearchForEndpoint(string word) {
        TrieNode node = this.root;
        int index = 0;
        
        while (index < word.Length) {
            if (node.Children.TryGetValue(word[index], out TrieNode current)) {
                node = current;
                ++index;
            }
            else {
                break;
            }
        }
        
        return (node, index);
    }
    
    public bool Search(string searchWord) => this.SearchChildren(searchWord, 0, false, this.root);
    
    private bool SearchChildren(string word, int wordIndex, bool skippedChar, TrieNode node) {
        if (word.Length == wordIndex) {
            return node.EndOfWord && skippedChar;
        }
        
        foreach (TrieNode child in node.Children.Values) {
            if (child.Character == word[wordIndex]) {
                if (this.SearchChildren(word, wordIndex + 1, skippedChar, child)) {
                    return true;
                }
            }
            else if (!skippedChar) {
                if (this.SearchChildren(word, wordIndex + 1, true, child)) {
                    return true;
                }
            }
        }
        
        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dictionary);
 * bool param_2 = obj.Search(searchWord);
 */