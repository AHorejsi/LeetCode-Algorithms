public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        Rectangle first = new Rectangle(A, B, C, D);
        Rectangle second = new Rectangle(E, F, G, H);
        
        return first.Area() + second.Area() - first.OverlapArea(second);
    }
}

struct Rectangle {
    private readonly int top;
    private readonly int down;
    private readonly int right;
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
            return 0;
        }
        else {
            bool topDownTop = this.Between(this.down, this.top, other.top);
            bool topDownDown = this.Between(this.down, this.top, other.down);
            bool leftRightLeft = this.Between(this.left, this.right, other.left);
            bool leftRightRight = this.Between(this.left, this.right, other.right);

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