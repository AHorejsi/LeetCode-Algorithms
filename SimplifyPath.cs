public class Solution {
    public string SimplifyPath(string path) {
        // The relevant file/folder names needed for the canonical path in reverse order
        var parts = this.FindPathParts(path);
        
        // Reverses the order of "parts" so that the file/folder names are in the correct order
        var reversedParts = new Stack<string>(parts);
        
        // The parts of the canonical file path as a string
        var simplifiedPath = this.MakeSimplifiedPath(reversedParts, path.Length);
        
        return  0 == simplifiedPath.Length ? "/" : simplifiedPath;
    }
    
    private Stack<string> FindPathParts(string path) {
        // All of the folder and file names separated as array elements
        var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        
        // Used to track which directory is the topmost/bottommost
        var stack = new Stack<string>(parts.Length);
        
        foreach (string part in parts) {
            var first = part[0];
            
            if (".." == part) {
                // A double dot indicates that we need to move to the parent directory
                // of the current directory
                
                if (0 != stack.Count) {
                    stack.Pop();
                }
            }
            else if ("." != part) {
                // A single dot indicates staying in the current directory.
                // Otherwise, "part" is a valid file/folder
                
                stack.Push(part);
            }
        }
        
        return stack;
    }
    
    private string MakeSimplifiedPath(Stack<string> parts, int capacity) {
        var simplifiedPath = new StringBuilder(capacity);
        
        while (0 != parts.Count) {
            simplifiedPath.Append($"/{parts.Pop()}");
        }
        
        return simplifiedPath.ToString();
    }
}
