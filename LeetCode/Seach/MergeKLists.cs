﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Seach
{
//    合并K个排序链表
//给你一个链表数组，每个链表都已经按升序排列。

     //请你将所有链表合并到一个升序链表中，返回合并后的链表。



     //示例 1：

     //输入：lists = [[1,4,5],[1,3,4],[2,6]]
     //输出：[1,1,2,3,4,4,5,6]
     //    解释：链表数组如下：
     //[
     //  1->4->5,
     //  1->3->4,
     //  2->6
     //]
     //    将它们合并到一个有序链表中得到。
     //1->1->2->3->4->4->5->6
     //示例 2：

     //输入：lists = []
     //    输出：[]
     //    示例 3：

     //输入：lists = [[]]
     //输出：[]


     //    提示：

     //k == lists.length
     //0 <= k <= 10^4
     //0 <= lists[i].length <= 500
     //-10^4 <= lists[i][j] <= 10^4
     //lists[i] 按 升序 排列
     //lists[i].length 的总和不超过 10^4

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
    public class mergeKLists
    {
        #region list
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = new ListNode(0);
            List<int> numbers = new List<int>();
            for (int i = 0; i < lists.Length; i++)
            {
                while (lists[i] != null)
                {
                    numbers.Add(lists[i].val);
                    lists[i] = lists[i].next;
                }
            }
            numbers.Sort();
            int index = 0;
            ListNode temp = result;
            while (index < numbers.Count)
            {
                temp.next = new ListNode(numbers[index]);
                index++;
                temp = temp.next;
            }
            return result.next;


        }
        #endregion
        //public ListNode MergeKLists2(ListNode[] lists)
        //{
          
            
        //}

    }
}
