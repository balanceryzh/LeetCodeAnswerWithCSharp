using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.LinkTable
{
//    合并两个有序链表
//将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 

 

//示例：

//输入：1->2->4, 1->3->4
//输出：1->1->2->3->4->4


    public class MergeTwoLists
    {
        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // exactly one of l1 and l2 can be non-null at this point, so connect
            // the non-null list to the end of the merged list.
            prev.next = l1 == null ? l2 : l1;

            return prehead.next;
        }
      

        public ListNode MergeTwoLists4(ListNode l1, ListNode l2)
        {
            ListNode list = new ListNode(-1);
            ListNode list2 = list;
            while(l1!=null&&l2!=null)
            {
                if(l1.val<=l2.val)
                {
                    list2.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    list2.next = l2;
                    l2 = l2.next;
                }
                list2 = list2.next;
            }
            list2.next = l1 == null ? l2 : l1;

            return list.next;


        }


        public ListNode MergeTwoLists5(ListNode l1, ListNode l2)
        {
            ListNode i = new ListNode(-1);
            ListNode j = i;

            while(l1!=null&&l2!=null)
            {
                if(l1.val<=l2.val)
                {
                    j.next = l1;
                    l1 = l1.next;

                }
                else
                {
                    j.next = l2;
                    l2 = l2.next;
                }
                j = j.next;
            }
            j.next = l1 == null ? l2 : l1;

            return i.next;

        }
    }
}
