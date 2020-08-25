using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.LinkTable
{
    //两数相加(重点1)
    //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
    //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
    //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。
    //示例：
    //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    //输出：7 -> 0 -> 8
    //原因：342 + 465 = 807
  public class ListNode
    {
      public int val;
     public ListNode next;
      public ListNode(int x) { val = x; }
  }
    public class AddTwoNumbers
    {


        /// <summary>
        /// 计算两个链表相加结果：递归法
        /// </summary>
        /// <param name="l1">链表1</param>
        /// <param name="l2">链表2</param>
        /// <param name="num">进位<param>
        /// <returns>相加结果逆序链表</returns>
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2, int num = 0)
        {
            /*递归边界：两个链表均为空*/
            if (l1 == null && l2 == null)
            {
                if (num != 0) return new ListNode(num);
                else return default;
            }

            /*计算两链表当前节点值相加之和：节点1值+节点2值+进位值*/
            int midValue = (l1?.val ?? 0) + (l2?.val ?? 0) + num;

            /*创建节点储存相加之和非进位部分*/
            ListNode listNode = new ListNode(midValue % 10);

            /*两链表指针右移，继续计算。*/
            listNode.next = AddTwoNumbers2(l1?.next, l2?.next, midValue / 10);

            return listNode;
        }

        public ListNode AddTwoNumbers3(ListNode l1,ListNode l2,int num=0)
        {
            if(l1==null && l2==null)
            {
                if (num > 0) { return new ListNode(num); }
                else { return default; }
            }
            int midValue = l1?.val ?? 0 + l2?.val ?? 0 + num;
            ListNode listnode = new ListNode(midValue%10);
            listnode.next = AddTwoNumbers3(l1?.next,l2?.next,midValue/10);
            return listnode;


        }
        public ListNode AddTwoNumbers4(ListNode l1, ListNode l2, int num = 0)
        {
            if (l1 == null && l2 == null)
            {
                if (num > 0) return new ListNode(num);
                else return default;
            }
            int midValue = l1?.val ?? 0 + l2?.val ?? 0 + num;
            ListNode listnode = new ListNode(midValue % 10);
            listnode.next = AddTwoNumbers4(l1?.next, l2?.next, midValue / 10);
            return listnode;

        }


            public ListNode AddTwoNumbers5(ListNode l1, ListNode l2, int num = 0)
           {
                if(l1==null&&l2==null)
                {
                    if (num > 0) { new ListNode(num); }
                    else { return default; }
                }
            int miuValue = l1?.val ?? 0 + l2?.val ?? 0 + num;
            ListNode listNode = new ListNode(miuValue % 10);
            listNode.next = AddTwoNumbers5(l1?.next, l2?.next, miuValue / 10);
                return listNode;
           }

        public ListNode AddTwoNumbers6(ListNode l1, ListNode l2, int num = 0)
        {
            if(l1==null&&l2==null)
            {
                if (num > 0) return new ListNode(num);
                return default;
            }
            int minValue = l1?.val ?? 0 + l2?.val ?? 0 + num;

            ListNode listnode = new ListNode(minValue%10);
            listnode.next = AddTwoNumbers6(l1?.next,l2?.next,minValue/10);
            return listnode;

        }


        public ListNode AddTwoNumbers7(ListNode l1, ListNode l2, int num = 0)
        {
            if(l1==null&&l2==null)
            {
                if (num > 0) return new ListNode(num);
                else return default;
            }
            int midValue = l1?.val ?? 0 + l2?.val ?? 0 + num;
            ListNode listnode = new ListNode(midValue%10);
            listnode.next = AddTwoNumbers7(l1?.next, l2?.next, midValue / 10);
            return listnode;


        }

        public ListNode AddTwoNumbers8(ListNode l1, ListNode l2, int num = 0)
    }
}
