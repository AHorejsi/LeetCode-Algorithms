public class Solution {
    private class Task {
        public char Id { get; }
        public int CurrentCooldown { get; private set; }
        public int MinCooldownNeeded { get; }
        public int Amount { get; private set; }
        
        public Task(char id, int currentCooldown, int minCooldownNeeded, int amount) {
            this.Id = id;
            this.CurrentCooldown = currentCooldown;
            this.MinCooldownNeeded = minCooldownNeeded;
            this.Amount = amount;
        }
        
        public bool Complete() {
            if (this.CurrentCooldown >= this.MinCooldownNeeded) {
                --(this.Amount);
                this.CurrentCooldown = 0;
                
                return true;
            }
            
            return false;
        }
        
        public void IncreaseCurrentCooldown() {
            ++(this.CurrentCooldown);
        }
    }
    
    private class TaskHeap {
        private Task[] tasks;
        public int Count { get; private set; }
        
        public TaskHeap(char[] tasks, int cooldown) {
            Dictionary<char, int> counter = this.CountTasks(tasks);
            
            this.Count = 0;
            this.tasks = new Task[tasks.Length];
            
            foreach (KeyValuePair<char, int> kvp in counter) {
                this.AddTask(new Task(kvp.Key, cooldown, cooldown, kvp.Value));
            }
        }
        
        public bool IsEmpty => 0 == this.Count;
        
        private Dictionary<char, int> CountTasks(char[] tasks) {
            Dictionary<char, int> counter = new Dictionary<char, int>(tasks.Length);

            foreach (char task in tasks) {
                if (counter.ContainsKey(task)) {
                    ++(counter[task]);
                }
                else {
                    counter.Add(task, 1);
                }
            }

            return counter;
        }
        
        public void AddTask(Task task) {
            int index = this.Count;
            this.tasks[index] = task;
            
            this.MoveUp(index);
            
            ++(this.Count);
        }
        
        public Task RemoveTask() {
            Task taskToRemove = this.tasks[0];
            this.tasks[0] = this.tasks[this.Count - 1];
            
            this.MaxHeapifyRoot();
            --(this.Count);
            
            return taskToRemove;
        }
        
        private void MaxHeapifyRoot() {
            int index = 0;
            
            while (true) {
                int indexOfLargest = index;
                int leftIndex = 2 * indexOfLargest + 1;
                int rightIndex = 2 * indexOfLargest + 2;
                
                if (leftIndex < this.Count && this.Compare(this.tasks[leftIndex], this.tasks[indexOfLargest]) < 0) {
                    indexOfLargest = leftIndex;
                }
                
                if (rightIndex < this.Count && this.Compare(this.tasks[rightIndex], this.tasks[indexOfLargest]) < 0) {
                    indexOfLargest = rightIndex;
                }
                
                if (index != indexOfLargest) {
                    Task temp = this.tasks[index];
                    this.tasks[index] = this.tasks[indexOfLargest];
                    this.tasks[indexOfLargest] = temp;
                    
                    index = indexOfLargest;
                }
                else {
                    break;
                }
            }
        }
        
        private int Compare(Task left, Task right) {
            int cooldown = left.MinCooldownNeeded;
                
            int leftAmount = left.Amount;
            int rightAmount = right.Amount;
            int leftCooldown = left.CurrentCooldown;
            int rightCooldown = right.CurrentCooldown;
            
            if (leftCooldown >= cooldown && rightCooldown >= cooldown) {
                return leftAmount - rightAmount;
            }
            else if (leftCooldown >= cooldown) {
                return 1;
            }
            else if (rightCooldown >= cooldown) {
                return -1;
            }
            else {
                int cooldownDifference = leftCooldown - rightCooldown;
                
                if (cooldownDifference > 0) {
                    return leftAmount - rightAmount;
                }
                else if (cooldownDifference < 0) {
                    return rightAmount - leftAmount;
                }
                else {
                    int amountDifference = leftAmount - rightAmount;

                    if (amountDifference > 0) {
                        return -1;
                    }
                    else if (amountDifference < 0) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
            }
        }
        
        public void IncreaseTaskCooldowns() {
            for (int index = 0; index < this.Count; ++index) {
                this.tasks[index].IncreaseCurrentCooldown();
                this.MoveUp(index);
            }
        }
        
        private void MoveUp(int index) {
            int parentIndex = (index - 1) / 2;
            
            while (index > 0 && this.Compare(this.tasks[index], this.tasks[parentIndex]) >= 0) {
                Task temp = this.tasks[index];
                this.tasks[index] = this.tasks[parentIndex];
                this.tasks[parentIndex] = temp;
                
                index = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }
        }
    }
    
    public int LeastInterval(char[] tasks, int cooldown) {
        TaskHeap heap = new TaskHeap(tasks, cooldown);
        int timePassed = 0;
        
        while (!heap.IsEmpty) {
            Task task = heap.RemoveTask();
            bool isCompleted = task.Complete();
            
            heap.IncreaseTaskCooldowns();
            
            if (task.Amount > 0) {
                if (!isCompleted) {
                    task.IncreaseCurrentCooldown();
                }
                
                heap.AddTask(task);
            }
            
            ++timePassed;
        }
        
        return timePassed;
    }
}