public class Trie {
    private sealed class Node {        
        public char Value { get; }
        public bool EndOfWord { get; set; } = false;
        private readonly Dictionary<char, Node> children = new Dictionary<char, Node>();
        
        public Node(char val) {
            this.Value = val;
        }
        
        public Node AddChild(char ch) {
            Node newNode = new Node(ch);
            this.children.Add(ch, newNode);
            
            return newNode;
        }
        
        public Node FindChildWith(char ch) {            
            Node node;
            
            if (!this.children.TryGetValue(ch, out node)) {
                node = null;
            }
            
            return node;
        }
    }
    
    private const char RootValue = '\u0000';
    private readonly Node root = new Node(Trie.RootValue);

    /** Initialize your data structure here. */
    public Trie() {}
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {        
        (Node endpoint, int indexOfWord) = this.SearchForEndpoint(word);
        
        foreach (char val in word.Skip(indexOfWord)) {
            endpoint = endpoint.AddChild(val);
        }
        
        endpoint.EndOfWord = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        (Node endpoint, int indexOfWord) = this.SearchForEndpoint(word);
        
        return endpoint.EndOfWord && word.Length == indexOfWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        (_, int indexOfPrefix) = this.SearchForEndpoint(prefix);
        
        return prefix.Length == indexOfPrefix;
    }
    
    private (Node, int) SearchForEndpoint(string word) {
        Node node = this.root;
        int index = 0;
        
        while (index < word.Length) {
            Node current = node.FindChildWith(word[index]);
            
            if (current is null) {
                break;
            }
            else {
                node = current;
                ++index;
            }
        }
        
        return (node, index);
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */