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
        this.stack = new Stack<IEnumerator<NestedInteger>>();

        this.stack.Push(list.GetEnumerator());

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
        var (iterator, atIteratorEnd) = this.FindNextIterator();

        if (atIteratorEnd) {
            return;
        }
        
        this.FindNextInteger(iterator);
    }

    private (IEnumerator<NestedInteger>, bool) FindNextIterator() {
        var iterator = this.stack.Peek();

        while (!iterator.MoveNext()) {
            this.stack.Pop();

            if (0 == this.stack.Count) {
                return (iterator, true);
            }

            iterator = this.stack.Peek();
        }

        return (iterator, false);
    }

    private void FindNextInteger(IEnumerator<NestedInteger> iterator) {
        var unknown = iterator.Current;

        while (!unknown.IsInteger()) {
            iterator = unknown.GetList().GetEnumerator();
            
            if (iterator.MoveNext()) {
                this.stack.Push(iterator);
            }
            else {
                (iterator, var atIteratorEnd) = this.FindNextIterator();

                if (atIteratorEnd) {
                    return;
                }
            }

            unknown = iterator.Current;
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */