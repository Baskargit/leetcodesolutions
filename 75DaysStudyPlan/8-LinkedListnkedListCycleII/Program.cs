using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            var headNode = new ListNode(3);
            headNode.next = new ListNode(2);
            headNode.next.next = new ListNode(0);
            headNode.next.next.next = new ListNode(-4);
            headNode.next.next.next.next = headNode.next;

            // var temp = headNode;
            // while (temp != null)
            // {
            //     Console.WriteLine(temp.val);
            //     temp = temp.next;
            // }

            ListNode? cycleNode = DetectCycle(headNode);
            if (cycleNode != null)
            {
                Console.WriteLine(cycleNode.val);
            }
        }

        // Naive approach
        // Memory: O(n)
        public static ListNode? DetectCycle(ListNode? head) 
        {
            var nodes = new List<ListNode>();

            while (head != null)
            {
                var node = nodes.FirstOrDefault(x => x.Equals(head));
                if (node != null)
                {
                    return node;
                }
                nodes.Add(head);
                head = head?.next;
            }

            return null;
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

// https://leetcode.com/problems/linked-list-cycle-ii/