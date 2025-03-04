public class ZigzagIterator {
    // The left side array
    private IList<int> left;
    
    // The right side array
    private IList<int> right;
    
    // The index being pointed to
    private int index;
    
    // Flag that indicates if an element from
    // the left side array should be returned next
    // or if an element from the right side array
    // should be returned next
    private bool onLeft;

    public ZigzagIterator(IList<int> left, IList<int> right) {
        this.left = left;
        this.right = right;
        this.index = 0;
        this.onLeft = true;
    }

    public bool HasNext() => Math.Max(this.left.Count, this.right.Count) != this.index;

    public int Next() {
        int elem; // Element to be returned
        
        if (this.index >= this.left.Count) {
            // Happens when the left side array is shorter
            // than the right side array and only elements
            // from the right side array need be returned
            // for now
            
            elem = this.right[this.index];
            
            ++(this.index);
        }
        else if (this.index >= this.right.Count) {
            // Happens when the right side array is shorter
            // than the left side array and only elements
            // from the left side array need be returned
            // for now
            
            elem = this.left[this.index];
            
            ++(this.index);
        }
        else {
            // Happens when the end of neither array has been reached
            // and we must alternate returning elements from each based
            // on "onLeft" state
            
            if (this.onLeft) {
                this.onLeft = false;
                elem = this.left[this.index];
            }
            else {
                this.onLeft = true;
                elem = this.right[this.index];
                
                // Move index forward only when an
                // element from the right side array
                // has been returned
                ++(this.index);
            }
        }
        
        return elem;
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */