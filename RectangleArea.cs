public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        Rectangle first = new Rectangle(A, B, C, D);
        Rectangle second = new Rectangle(E, F, G, H);
        
        // Equation for area of ovelapping shapes
        return first.Area() + second.Area() - first.OverlapArea(second);
    }
}

struct Rectangle {
    // The y-value of the top line
    private readonly int top;
    
    // The y-value of the bottom line
    private readonly int down;
    
    // The x-value of the right line
    private readonly int right;
    
    // The x-value of the left line
    private readonly int left;
    
    public Rectangle(int left, int down, int right, int top) {
        this.top = top;
        this.down = down;
        this.left = left;
        this.right = right;
    }
    
    public int Area() => (this.right - this.left) * (this.top - this.down);
    
    public int OverlapArea(Rectangle other) {
        if (this.NoOverlap(other)) {
            // If there is no overlap, the area of the overlapped area is zero
            return 0;
        }
        else {
            // Represents whether or not "other.top" is between "this.down" and "this.top"
            bool topDownTop = this.Between(this.down, this.top, other.top);
            
            // Represents whether or not "other.down" is between "this.down" and "this.top"
            bool topDownDown = this.Between(this.down, this.top, other.down);
            
            // Represents whether or not "other.left" is between "this.left" and "this.right"
            bool leftRightLeft = this.Between(this.left, this.right, other.left);
            
            // Represents whether or not "other.right" is between "this.left" and "this.right"
            bool leftRightRight = this.Between(this.left, this.right, other.right);
            
            // Select points based on whether or not the lines
            // corresponding to "other" are between the lines
            // corresponding to "this"
            Rectangle overlap = new Rectangle(
                leftRightLeft ? other.left : this.left,
                topDownDown ? other.down : this.down,
                leftRightRight ? other.right : this.right,
                topDownTop ? other.top : this.top
            );

            return overlap.Area();
        }
    }
    
    private bool NoOverlap(Rectangle other) => (other.left >= this.right || other.down >= this.top || this.left >= other.right || this.down >= other.top);
    
    private bool Between(int lowerOuter, int upperOuter, int point) => (point >= lowerOuter && point <= upperOuter);
}
