using System;
using System.Collections.Generic;
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
    }
}
