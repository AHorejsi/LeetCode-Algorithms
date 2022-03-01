public class Solution {
    private enum Player { Null, One, Two };
    
    private sealed class GameState : IEnumerable<int> {
        private struct WinState : IEquatable<WinState> {
            private int choosable;
            private Player turn;

            public WinState(int choosable, Player turn) {
                this.choosable = choosable;
                this.turn = turn;
            }
            
            public override bool Equals(object obj) => obj is WinState && this.Equals((WinState)obj);
            
            public bool Equals(WinState? other) => !(other is null) && this.Equals((WinState)other);
            
            public bool Equals(WinState other) => this.choosable == other.choosable && this.turn == other.turn;
            
            public override int GetHashCode() => HashCode.Combine(this.choosable, this.turn);
            
            public static bool operator ==(WinState? left, WinState? right) =>
                (left is null, right is null) switch {
                    (true, true) => true,
                    (true, false) => false,
                    (false, true) => false,
                    _ => ((WinState)left).Equals((WinState)right)
                };
            
            public static bool operator ==(WinState left, WinState right) => left.Equals(right);
            
            public static bool operator !=(WinState? left, WinState? right) => !(left == right);
            
            public static bool operator !=(WinState left, WinState right) => !(left == right);
        }
        
        private Dictionary<WinState, Player> states;
        private int choosable;
        private int desiredTotal;
        private int length;
        private int score;
        public Player Turn { get; private set; }
        
        public GameState(int choosable, int desiredTotal) {
            this.states = new Dictionary<WinState, Player>();
            this.choosable = 32 == choosable ? -1 : ~(~0 << choosable);
            this.desiredTotal = desiredTotal;
            this.length = choosable;
            this.score = 0;
            this.Turn = Player.One;
        }
        
        public bool Complete => this.score >= this.desiredTotal;
        
        public Player Other => Player.One == this.Turn ? Player.Two : Player.One;
        
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
        
        public void Save(Player winner) {
            WinState winState = new WinState(this.choosable, this.Turn);
            
            if (!this.states.TryAdd(winState, winner)) {
                throw new InvalidOperationException("Winner already recorded");
            }
        }
        
        public Player CheckStates() {
            if (this.states.TryGetValue(new WinState(this.choosable, this.Turn), out Player winner)) {
                return winner;
            }
            else {
                return Player.Null;
            }
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
        Player winner = state.CheckStates();
        
        if (Player.Null != winner) {
            return Player.One == winner;
        }
        else {
            foreach (int val in state) {
                state.Pick(val);
                
                if (state.Complete) {
                    state.Unpick(val);
                    state.Save(state.Turn);
                    
                    return Player.One == state.Turn;
                }
                else {
                    state.SwapTurn();
                    bool currentPlayerWins = this.PlayerMove(state);
                    state.SwapTurn();
                    
                    state.Unpick(val);
                    
                    switch (state.Turn, currentPlayerWins) {
                    case (Player.One, true):
                        state.Save(state.Turn);
                        return true;
                    case (Player.Two, false):
                        state.Save(state.Turn);
                        return false;
                    }
                }
            }
            
            state.Save(state.Other);
            
            return Player.Two == state.Turn;
        }
    }
}
