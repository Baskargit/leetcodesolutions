using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            var mergedSortedList = MergeTwoLists(list1, list2);
            while (mergedSortedList != null)
            {
                //Console.WriteLine(mergedSortedList.val);
                mergedSortedList = mergedSortedList.next;
            }

            list1 = new ListNode(1, new ListNode(2));
            list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            mergedSortedList = MergeTwoLists(list1, list2);
            while (mergedSortedList != null)
            {
                //Console.WriteLine(mergedSortedList.val);
                mergedSortedList = mergedSortedList.next;
            }

            list1 = null;
            list2 = new ListNode(1);
            mergedSortedList = MergeTwoLists(list1, list2);
            while (mergedSortedList != null)
            {
                Console.WriteLine(mergedSortedList.val);
                mergedSortedList = mergedSortedList.next;
            }

            // Get all number, sort and create new head
            // Store all nodes in an list, sort and create link based on order
        }

        public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2) 
        {
            if (list1 == null || list2 == null)
            {
                return list1 ?? list2;
            }

            ListNode? list1Head = list1;

            while (list2 != null)
            {
                var list1HeadTemp = list1Head;

                if (list2.val <= list1HeadTemp.val)
                {
                    // Update head and continue
                    var next = list2.next;
                    list2.next = list1HeadTemp;
                    list1Head = list2;

                    list2 = next;
                    continue;
                }

                var list1Prev = list1HeadTemp;
                while (list1HeadTemp != null)
                {
                    var list2Next = list2.next;

                    if (list2.val <= list1HeadTemp.val)
                    {
                        list1Prev.next = list2;
                        list2.next = list1HeadTemp;

                        // Set next
                        list2 = list2Next;
                        break;
                    }
                    else if (list1HeadTemp.next == null)
                    {
                        list1HeadTemp.next = list2;
                        list2.next = null;
                        list2 = list2Next;
                        break;
                    }

                    list1Prev = list1HeadTemp;
                    list1HeadTemp = list1HeadTemp.next;
                }
            }

            return list1Head;
        }
    }

    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode(int val=0, ListNode? next = null) {
            this.val = val;
            this.next = next;
        }
    }
}

// https://leetcode.com/problems/merge-two-sorted-lists