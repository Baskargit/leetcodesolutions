using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode? middleNode = null;

            middleNode = MiddleNode(new ListNode(1));
            Console.WriteLine(middleNode?.val);

            middleNode = MiddleNode(new ListNode(1,new ListNode(2)));
            Console.WriteLine(middleNode?.val);

            middleNode = MiddleNode(new ListNode(1,new ListNode(2,new ListNode(3))));
            Console.WriteLine(middleNode?.val);

            middleNode = MiddleNode(new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4)))));
            Console.WriteLine(middleNode?.val);

            middleNode = MiddleNode(new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4,new ListNode(5))))));
            Console.WriteLine(middleNode?.val);
            
            middleNode = MiddleNode(new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4,new ListNode(5, new ListNode(6)))))));
            Console.WriteLine(middleNode?.val);
        }

        public static ListNode? MiddleNode(ListNode? head)
        {
            ListNode? nextNextNode = head;

            while (head != null)
            {
                if (nextNextNode == null || nextNextNode?.next == null)
                {
                    return head;
                }

                nextNextNode = nextNextNode?.next?.next;
                head = head?.next;
            }

            return head;
        }
    }

    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode(int val=0, ListNode? next=null) {
            this.val = val;
            this.next = next;
        }
    }
}

// https://leetcode.com/problems/middle-of-the-linked-list