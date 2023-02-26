using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
    {
    
    internal class LT21
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        private void InitNodes(out ListNode list1, out ListNode list2)
        { 
            ListNode l13 = new ListNode(4);
            ListNode l12 = new ListNode(2, l13);
            list1 = new ListNode(1, l12);
            ListNode l23 = new ListNode(4);
            ListNode l22 = new ListNode(3, l23);
            list2 = new ListNode(1, l22);
        }

        public void Run()
        {
            ListNode list1, list2;
            InitNodes(out list1, out list2);
            MergeTwoLists(list1, list2);    
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode root = null;
            CompareLists(list1, list2, root);

            return root;
        }

        private void  CompareLists(ListNode list1, ListNode list2, ListNode current)
        {
            (ListNode smaller, ListNode greater) = PickSmaller(list1, list2);
            
            if (smaller != null) {
                current.next = smaller;
                if (smaller.next != null)
                {
                    CompareLists(smaller.next, greater, current);
                }
            }
            return;
        }


        private (ListNode, ListNode) PickSmaller (ListNode left, ListNode right) 
        { 
            if (left != null && right!= null)
            {
                Console.WriteLine($"Left  {left.val} right {right.val}");
                return left.val <= right.val ? (left, right) : (right, left);
            }
            if (left != null)
            {
                return (left, null);
            }
            return (right, null);
        }
    }
}
