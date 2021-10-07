public class Solution {
    private sealed class ComboState {
        public int TargetSum { get; }
        public int CurrentSum { get; set; }
        public int[] Candidates { get; }
        public List<int> CurrentList { get; }
        public int CandidateIndex { get; set; }
        public IList<IList<int>> Result { get; }
        
        public ComboState(int[] candidates, int targetSum) {
            this.TargetSum = targetSum;
            this.CurrentSum = 0;
            this.Candidates = candidates;
            this.CurrentList = new List<int>();
            this.CandidateIndex = 0;
            this.Result = new List<IList<int>>();
        }
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        ComboState state = new ComboState(candidates, target);
        
        for (int index = 0; index < candidates.Length; ++index) {
            this.FindCombos(state);
            ++(state.CandidateIndex);
        }
        
        return state.Result;
    }
    
    private void FindCombos(ComboState state) {
        if (state.CandidateIndex < state.Candidates.Length) {
            int val = state.Candidates[state.CandidateIndex];
            
            int startIndex = state.CurrentList.Count;
            int sumAdded = 0;
            int amountAdded = 0;
            
            while (state.CurrentSum < state.TargetSum) {
                state.CurrentSum += val;
                state.CurrentList.Add(val);
                
                ++amountAdded;
                sumAdded += val;
                
                if (state.CurrentSum == state.TargetSum) {
                    IList<int> solution = state.CurrentList.ToList();
                    state.Result.Add(solution);
                    
                    break;
                }
                
                this.TraverseFollowingElements(state);
            }
            
            state.CurrentList.RemoveRange(startIndex, amountAdded);
            state.CurrentSum -= sumAdded;
        }
    }
    
    private void TraverseFollowingElements(ComboState state) {
        int end = state.Candidates.Length - state.CandidateIndex + 1;
        
        for (int distance = 1; distance < end; ++distance) {
            state.CandidateIndex += distance;
            this.FindCombos(state);
            state.CandidateIndex -= distance;
        }
    }
}