using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ListNode(1,new ListNode(2, new ListNode(3, new ListNode(4))));
            var reversed = ReverseList(list);
            while (reversed != null)
            {
                Console.Write(reversed.val + ", ");
                reversed = reversed.next;
            }

            list = new ListNode(1,new ListNode(2));
            reversed = ReverseList(list);
            while (reversed != null)
            {
                //Console.Write(reversed.val + ", ");
                reversed = reversed.next;
            }

            list = new ListNode(1);
            reversed = ReverseList(list);
            while (reversed != null)
            {
                //Console.Write(reversed.val + ", ");
                reversed = reversed.next;
            }
        }

        public static ListNode? ReverseList(ListNode? head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode? reversed = head;
            head = head.next;
            reversed.next = null;

            ListNode? next = null;
            while (head != null)
            {
                next = head.next;
                head.next = reversed;
                reversed = head;
                head = next;
            }

            return reversed;
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