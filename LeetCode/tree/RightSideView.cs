using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.tree
{

    //给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。

//示例:

//输入: [1,2,3,null,5,null,4]
//输出: [1, 3, 4]
//解释:

//   1            <---
// /   \
//2     3         <---
// \     \
//  5     4       <---


    public class rightSideView
    {
        #region list

        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null) return res;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int sz = q.Count;

                for (int i = 0; i < sz; i++)
                {
                    TreeNode cur = q.Dequeue();
                


                    if (cur.left != null)
                    {
                        q.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        q.Enqueue(cur.right);
                    }


                    if (i == sz - 1)
                    {
                        res.Add(cur.val);
                    }
                }
            }
            return res;


        }

        public IList<int> RightSideView2(TreeNode root)
        {
            List<int> outlist = new List<int>();
            if(root==null)
            {
                return outlist;
            }
            Queue<TreeNode> templist = new Queue<TreeNode>();
            templist.Enqueue(root);
            while(templist.Count>0)
            {
                int count = templist.Count;

                for(int i=0;i<count;i++)
                {
                    TreeNode temp = templist.Dequeue();
                    if(temp.left!=null)
                    {
                        templist.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        templist.Enqueue(temp.right);
                    }
                    if(i==count-1)
                    {
                        outlist.Add(temp.val);
                    }
                }

            }
            return outlist;
        }

        #endregion

        public IList<int> RightSideView3(TreeNode root)
        {
            List<int> outList = new List<int>();
            if(root==null)
            {
                return outList;
            }
            Queue<TreeNode> list = new Queue<TreeNode>();
            list.Enqueue(root);
            while(list.Count>0)
            {
                int count = list.Count;
                for(int i=0;i<list.Count;i++)
                {
                    TreeNode temp = list.Dequeue();
                    if (temp.right != null) { list.Enqueue(temp.right); }
                    if (temp.left != null) { list.Enqueue(temp.right); }
                    if (i == count - 1)
                    {
                        outList.Add(temp.val);
                    }
                }
            }
            return outList;
        }
    }
}
