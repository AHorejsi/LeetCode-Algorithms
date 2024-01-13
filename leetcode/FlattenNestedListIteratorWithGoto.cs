/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public sealed class NestedIterator {
    private Stack<IEnumerator<NestedInteger>> stack;

    public NestedIterator(IList<NestedInteger> list) {
        var iter = list.GetEnumerator();

        this.stack = new Stack<IEnumerator<NestedInteger>>();
        this.stack.Push(iter);

        this.MoveIteratorForward();
    }

    public bool HasNext() => 0 != this.stack.Count;

    public int Next() {
        if (!this.HasNext()) {
            throw new InvalidOperationException("Iterator at end");
        }

        var integer = this.stack.Peek().Current.GetInteger();

        this.MoveIteratorForward();

        return integer;
    }

    private void MoveIteratorForward() {
        NextIterator:
            var iter = this.stack.Peek();

            while (!iter.MoveNext()) {
                this.stack.Pop();

                if (0 == this.stack.Count) {
                    return;
                }

                iter = this.stack.Peek();
            }
        
        var unknown = iter.Current;

        while (!unknown.IsInteger()) {
            var list = unknown.GetList();

            iter = list.GetEnumerator();
            
            if (iter.MoveNext()) {
                this.stack.Push(iter);

                unknown = iter.Current;
            }
            else {
                goto NextIterator;
            }
        }
    }
}