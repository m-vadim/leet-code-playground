namespace AddTwoNumbers;
class Program {
    static void Main(string[] args) {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        
        var output = new Solution().AddTwoNumbers(l1, l2);
        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));

        var currentNode = output;
        while (true) {
            Console.Write(currentNode.val);
            currentNode = currentNode.next;
            if (currentNode == null) {
                break;
            }
        }
    }
}



