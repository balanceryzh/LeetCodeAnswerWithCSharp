using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleTest.LinkTable
{

//    删除链表的倒数第N个节点
//给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。

//示例：

//给定一个链表: 1->2->3->4->5, 和 n = 2.

//当删除了倒数第二个节点后，链表变为 1->2->3->5.
//说明：

//给定的 n 保证是有效的。

//进阶：

//你能尝试使用一趟扫描实现吗？

    public class RemoveNthFromEnd
    {
        #region 
        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode cur = head;
            int i = 1;
            while (cur.next != null)
            {
                cur = cur.next;
                i++;
            }

            if (i == n)
            {
                return head.next;
            }
            else
            {
                cur = head;
                int index = i + 1 - n;
                int j = 1;
                while (j < index - 1)
                {
                    cur = cur.next;
                    j++;
                }
                cur.next = cur.next.next;
            }
            return head;
        }


        public ListNode RemoveNthFromEnd3(ListNode head, int n)
        {
            ListNode cre = head;
            int i = 1;
            while(cre!=null)
            {
                cre = cre.next;
                i++;
            }
            if(i==n)
            {
                return head.next;
            }
            else
            {
                cre = head;
                int index = i - n + 1;
                int j = 1;
                while(j<index-1)
                {

                    cre = cre.next;
                    j++;
                }
                cre.next = cre.next.next;
            }

            return head;

               
           
        }

  
        public ListNode RemoveNthFromEnd5(ListNode head, int n)
        {
            ListNode temp = head;
            int i = 1;
            while(temp.next!=null)
            {
                temp = temp.next;
                i++;
            }
            if(n==i)
            {
                return head.next;
            }
            else
            {
                temp = head;
                int index = i - n + 1;
                int j = 1;
                
                while(j<index-1)
                {
                    temp = temp.next;
                    j++;

                }
                temp.next = temp.next.next;

            }
            return head;

        }


        public ListNode RemoveNthFromEnd6(ListNode head, int n)
        {
            ListNode pre = head;
            int i = 1;
            while (pre.next != null)
            {
                pre = pre.next;
                i++;
            }
            if (i == n)
            {
                return head.next;
            }
            else
            {
                int index = i - n + 1;
                int j = 1;
                pre = head;
                while (j < index - 1)
                {
                    pre = pre.next;
                    j++;
                }
                pre.next = pre.next.next;
            }
            return head;
        }


        public ListNode RemoveNthFromEnd7(ListNode head, int n)
        {
            ListNode pre = head;
            int i = 1;
            while(pre.next!=null)
            {
                pre = pre.next;
                i++;
            }
            if(i==n)
            {
                return head.next;
            }
            else
            {
                int j = 1;
                int index = i - n + 1;
                pre = head;
                while(j<index-1)
                {
                    pre = pre.next;
                    j++;
                }

                pre.next = pre.next.next;



            }
            return head;

        }



        #endregion
        //public ListNode RemoveNthFromEnd21(ListNode head, int n)
    }
}
