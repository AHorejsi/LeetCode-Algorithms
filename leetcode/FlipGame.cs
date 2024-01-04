public class Solution {
    public IList<string> GeneratePossibleNextMoves(string currentState) {
        var followStates = new List<string>();
        var sb = new StringBuilder();
        var end = currentState.Length - 1;
        
        for (var index = 0; index < end; ++index) {
            var currentLetter = currentState[index];
            var nextLetter = currentState[index + 1];

            if ('+' == currentLetter && currentLetter == nextLetter) {
                sb.Append("--");

                var nextState = sb.ToString() + currentState.Substring(index + 2);
                followStates.Add(nextState);
                
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append(currentLetter);
        }

        return followStates;
    }
}
