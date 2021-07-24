public class Trie {
    private class Node {        
        public char Value { get; }
        public bool EndOfWord { get; set; }
        private Dictionary<char, Node> children;
        
        public Node(char val) {
            this.Value = val;
            this.children = new Dictionary<char, Node>();
            this.EndOfWord = false;
        }
        
        public Node AddChild(char ch) {
            Node newNode = new Node(ch);
            this.children.Add(ch, newNode);
            
            return newNode;
        }
        
        public Node FindChildWith(char ch) {            
            Node node;
            this.children.TryGetValue(ch, out node);
            
            return node;
        }
    }
    
    private static readonly char ROOT_VALUE = '\u0000';
    private Node root;

    /** Initialize your data structure here. */
    public Trie() {
        this.root = new Node(Trie.ROOT_VALUE);
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {        
        (Node endpoint, int indexOfWord) = this.SearchForEndpoint(word);
        
        
        foreach (char val in word.Skip(indexOfWord)) {
            endpoint = endpoint.AddChild(val);
        }
        
        endpoint.EndOfWord = true;
    }
    
    private (Node, int) SearchForEndpoint(string word) {
        Node node = this.root;
        int index = 0;
        
        while (index < word.Length) {
            Node current = node;
            current = current.FindChildWith(word[index]);
            
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
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        Node node = this.root;
        
        foreach (char val in word) {
            node = node.FindChildWith(val);
            
            if (node is null) {
                return false;
            }
        }
        
        return node.EndOfWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        Node node = this.root;
        
        foreach (char val in prefix) {
            node = node.FindChildWith(val);
            
            if (node is null) {
                return false;
            }
        }
        
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */