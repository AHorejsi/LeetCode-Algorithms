public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var stack = new List<int>(asteroids.Length);
        
        foreach (var current in asteroids) {
            if (stack.Any()) {
                var prev = stack.Last();

                if (current < 0 && prev > 0) {
                    this.SmashAsteroids(current, prev, stack);

                    continue;
                }
            }

            stack.Add(current);  
        }
        
        return stack.ToArray();
    }

    private void SmashAsteroids(int current, int prev, List<int> stack) {
        var currentPositive = -current;

        if (currentPositive > prev) {
            do {
                stack.RemoveAt(stack.Count - 1);
                
                if (stack.Any()) {
                    prev = stack.Last();
                }
                else {
                    break;
                }
            } while (prev > 0 && prev < currentPositive);
        }
        
        if (currentPositive == prev) {
            stack.RemoveAt(stack.Count - 1);
        }
        else if (currentPositive > prev) {
            stack.Add(current);
        }
    }
}
