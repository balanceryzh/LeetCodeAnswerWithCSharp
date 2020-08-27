using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.LinkTable
{
    //反转链表
    
//反转一个单链表。

//示例:

//输入: 1->2->3->4->5->NULL
//输出: 5->4->3->2->1->NULL
//进阶:
//你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
    public class ReverseList
    {
        public ListNode reverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }
        public ListNode reverseList2(ListNode head)
        {
            ListNode i = null;
            ListNode j = head;
            while(j!=null)
            {
                ListNode temp = j.next;
                j.next = i;
                i = j;

                j = temp;

            }
            return i;
        }

        public ListNode reverseList3(ListNode head)
        {
            ListNode i = null;
            ListNode j = head;
            while(j!=null)
            {
                ListNode temp = j.next;
                j.next = i;
                i = j;
                j = temp;
            }
            return i;

        }
        public ListNode reverseList4(ListNode head)
        {
            ListNode i = null;
            ListNode j = head;
            while(j!=null)
            {
                ListNode temp = j.next;
                j.next = i;
                i = j;
                j = temp;
            }
            return i;
        }
    }
}
