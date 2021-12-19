using System.Threading;

public class Solution {
    private sealed class Fleet {
        public int Position { get; private set; }
        public int Speed { get; private set; }
        
        public Fleet(int position, int speed) {
            this.Position = position;
            this.Speed = speed;
        }
        
        public int OldPosition => this.Position - this.Speed;
        
        public void Merge(Fleet other) {
            this.Speed = Math.Min(this.Speed, other.Speed);
            this.Position = Math.Min(this.Position, other.Position);
        }
        
        public void Move() {
            this.Position += this.Speed;
        }
    }
    
    public int CarFleet(int target, int[] positions, int[] speeds) {
        LinkedList<Fleet> fleetList = new LinkedList<Fleet>(
            Enumerable
            .Zip(positions, speeds)
            .Select(((int position, int speed) data) => new Fleet(data.position, data.speed))
            .OrderBy((Fleet fleet) => fleet.Position)
        );
        int fleetCount = 0;
        
        while (!object.ReferenceEquals(fleetList.First, fleetList.Last)) {
            this.MoveFleets(fleetList);
            this.MergeFleets(fleetList, target);
            fleetCount += this.CountAmountThatFinished(fleetList, target);
        }
        
        return fleetCount + fleetList.Count;
    }
    
    private void MoveFleets(LinkedList<Fleet> fleetList) {
        foreach (Fleet fleet in fleetList) {
            fleet.Move();
        }
    }
    
    private void MergeFleets(LinkedList<Fleet> fleetList, int target) {
        for (LinkedListNode<Fleet> currentNode = fleetList.Last; !(currentNode is null); currentNode = currentNode.Previous) {
            Fleet currentFleet = currentNode.Value;
            LinkedListNode<Fleet> nextNode = currentNode.Next;

            if (!(nextNode is null)) {
                Fleet aheadFleet = nextNode.Value;
                
                int currentPosition = currentFleet.Position;
                int aheadPosition = aheadFleet.Position;
                
                Lazy<float> timeToFinishOfCurrent = new Lazy<float>(
                    () => this.TimeFromTarget(target, currentFleet),
                    LazyThreadSafetyMode.None
                );
                Lazy<float> timeToFinishOfAhead = new Lazy<float>(
                    () => this.TimeFromTarget(target, aheadFleet),
                    LazyThreadSafetyMode.None
                );
                
                if (currentPosition >= aheadPosition && (aheadPosition <= target || timeToFinishOfCurrent.Value <= timeToFinishOfAhead.Value)) {
                    currentFleet.Merge(aheadFleet);
                    fleetList.Remove(nextNode);
                }
            }
        }
    }
    
    private float TimeFromTarget(int target, Fleet fleet) => (target - fleet.OldPosition) / (float)fleet.Speed;
    
    private int CountAmountThatFinished(LinkedList<Fleet> fleetList, int target) {
        int amountThatFinished = 0;
        
        while (!(fleetList.Last is null) && fleetList.Last.Value.Position > target) {
            fleetList.RemoveLast();
            ++amountThatFinished;
        }
        
        return amountThatFinished;
    }
}