public class Solution {
    public ListNode AddTwoNumbers(ListNode first, ListNode second) {
        bool carryOne = false;
        ListNode sum = this.Add(first, second, ref carryOne);
        
        ListNode head = sum;
        
        first = first.next;
        second = second.next;
        
        while (!(first is null && second is null)) {
            sum.next = this.Add(first, second, ref carryOne);
            sum = sum.next;
            
            if (!(first is null)) {
                first = first.next;
            }
            if (!(second is null)) {
                second = second.next;
            }
        }

        if (carryOne) {
            sum.next = new ListNode(1);
        }

        return head;
    }
    
    private ListNode Add(ListNode first, ListNode second, ref bool carryOne) {
		int num = ((first is null) ? 0 : first.val) + ((second is null) ? 0 : second.val);
		ListNode sum;

		if (carryOne) {
			++num;
		}

		if (num >= 10) {
			carryOne = true;
			sum = new ListNode(num - 10);
		}
		else {
			carryOne = false;
			sum = new ListNode(num);
		}

		return sum;
	}
}