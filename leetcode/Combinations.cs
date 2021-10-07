public class Solution {    
    public IList<IList<int>> Combine(int max, int amount) {
        IList<IList<int>> combos = new List<IList<int>>();
        this.FindCombos(max, amount, 1, new List<int>(amount), combos);
        
        return combos;
    }
    
    private void FindCombos(int max, int amount, int value, IList<int> currentCombo, IList<IList<int>> combos) {
        if (currentCombo.Count == amount) {
            IList<int> solution = currentCombo.ToList();
            combos.Add(solution);
        }
        else {
            while (value <= max) {
                currentCombo.Add(value);

                this.FindCombos(max, amount, value + 1, currentCombo, combos);

                currentCombo.RemoveAt(currentCombo.Count - 1);

                ++value;
            }
        }
    }
}