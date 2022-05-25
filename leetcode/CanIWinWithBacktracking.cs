public class Solution {
    private enum Player { Null, One, Two };
    
    private sealed class GameState : IEnumerable<int> {        
        private int choosable;
        private int desiredTotal;
        private int length;
        private int score;
        public Player Turn { get; private set; }
        
        public GameState(int choosable, int desiredTotal) {
            this.choosable = 32 == choosable ? -1 : ~(~0 << choosable);
            this.desiredTotal = desiredTotal;
            this.length = choosable;
            this.score = 0;
            this.Turn = Player.One;
        }
        
        public bool Complete => this.score >= this.desiredTotal;
        
        public void Unpick(int val) {
            int bitIndex = val - 1;
            int mask = 1 << bitIndex;
            int bit = (this.choosable >> bitIndex) & 1;
            
            if (0 != bit) {
                throw new InvalidOperationException($"Value \"{val}\" is already in the set");
            }
            
            this.choosable |= mask;
            this.score -= val;
        }
        
        public void Pick(int val) {
            int bitIndex = val - 1;
            int mask = 1 << bitIndex;
            int bit = (this.choosable >> bitIndex) & 1;
            
            if (0 == bit) {
                throw new InvalidOperationException($"Value \"{val}\" is not in the set");
            }
            
            this.choosable &= ~mask;
            this.score += val;
        }
        
        public void SwapTurn() {
            this.Turn = Player.One == this.Turn ? Player.Two : Player.One;
        }
        
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<int>)this).GetEnumerator();
        
        public IEnumerator<int> GetEnumerator() {
            for (int val = 1; val <= this.length; ++val) {
                int bitIndex = val - 1;
                int bit = (this.choosable >> bitIndex) & 1;
                
                if (0 != bit) {
                    yield return val;
                }
            }
        }
    }
    
    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        int choosableSum = (maxChoosableInteger * (maxChoosableInteger + 1)) / 2;
        
        if (desiredTotal <= maxChoosableInteger) {
            return true;
        }
        else if (desiredTotal - 1 == maxChoosableInteger || choosableSum < desiredTotal) {
            return false;
        }
        else {
            return this.PlayerMove(new GameState(maxChoosableInteger, desiredTotal));
        }
    }
    
    private bool PlayerMove(GameState state) {
        foreach (int val in state) {
            state.Pick(val);

            if (state.Complete) {
                state.Unpick(val);

                return Player.One == state.Turn;
            }
            else {
                state.SwapTurn();
                bool winState = this.PlayerMove(state);
                state.SwapTurn();

                state.Unpick(val);

                switch (state.Turn, winState) {
                case (Player.One, true):
                    return true;
                case (Player.Two, false):
                    return false;
                }
            }
        }

        return Player.Two == state.Turn;
    }
}
