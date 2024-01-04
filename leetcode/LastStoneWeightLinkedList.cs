public class Solution {
    public int LastStoneWeight(int[] stones) {
        var stoneList = new LinkedList<int>(stones);

        while (stoneList.Count > 1) {
            var maxNode1 = this.Find1stMax(stoneList);
            var maxNode2 = this.Find2ndMax(stoneList, maxNode1);

            var maxValue1 = maxNode1.Value;
            var maxValue2 = maxNode2.Value;

            if (maxValue1 < maxValue2) {
                maxNode2.Value = maxValue2 - maxValue1;
                
                stoneList.Remove(maxNode1);
            }
            else if (maxValue1 > maxValue2) {
                maxNode1.Value = maxValue1 - maxValue2;
                
                stoneList.Remove(maxNode2);
            }
            else {
                stoneList.Remove(maxNode1);
                stoneList.Remove(maxNode2);
            }
        }

        return stoneList.Any() ? stoneList.First() : 0;
    }

    private LinkedListNode<int> Find1stMax(LinkedList<int> stoneList) {
        LinkedListNode<int> maxNode = null;
        var maxValue = int.MinValue;

        for (var node = stoneList.First; !(node is null); node = node.Next) {
            var nodeValue = node.Value;

            if (nodeValue > maxValue) {
                maxNode = node;
                maxValue = nodeValue;
            }
        }

        return maxNode;
    }

    private LinkedListNode<int> Find2ndMax(LinkedList<int> stoneList, LinkedListNode<int> maxNode1) {
        LinkedListNode<int> maxNode2 = null;
        var maxValue2 = int.MinValue;

        for (var node = stoneList.First; !(node is null); node = node.Next) {
            if (!object.ReferenceEquals(maxNode1, node)) {
                var nodeValue = node.Value;

                if (nodeValue > maxValue2) {
                    maxNode2 = node;
                    maxValue2 = nodeValue;
                }
            }
        }

        return maxNode2;
    }
}
