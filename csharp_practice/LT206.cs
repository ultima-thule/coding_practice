using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class LT206
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

        private void InitNodes(out ListNode list1)
        {
            ListNode l15 = new ListNode(5);
            ListNode l14 = new ListNode(4, l15);
            ListNode l13 = new ListNode(3, l14);
            ListNode l12 = new ListNode(2, l13);
            list1 = new ListNode(1, l12);
        }

        public ListNode ReverseList(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();

            list.Add(head);
            ListNode current = head;
            while (current.next != null)
            {
                list.Add(current.next);
                current = current.next;
            }

            list.Reverse();
            ListNode result = new ListNode();
            if (list.Count > 0)
            {
                result = list[0];
                int i = 0;
                while (i < list.Count - 1)
                {
                    result.next = list[i + 1];
                    i++;
                }
            }
            return result;
        }

        public void Run()
        {
            ListNode list1;
            InitNodes(out list1);
            ReverseList(list1);
        }

    }
}
