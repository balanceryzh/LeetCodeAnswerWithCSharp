using ConsoleTest.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{

//    二叉树中的最大路径和
//给定一个非空二叉树，返回其最大路径和。

//本题中，路径被定义为一条从树中任意节点出发，沿父节点-子节点连接，达到任意节点的序列。该路径至少包含一个节点，且不一定经过根节点。

 

//示例 1：

//输入：[1,2,3]

//       1
//      / \
//     2   3

//输出：6
//示例 2：

//输入：[-10,9,20,null,null,15,7]

//   -10
//   / \
//  9  20
//    /  \
//   15   7

//输出：42



      public class TreeNode
    {
     public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
 }

    public class maxPathSum
    {
        #region list
        public int MaxPathSum(TreeNode root)
        {
            int? maxPathValue = null;
            MaxValue(root, ref maxPathValue);
            return maxPathValue.Value;
        }

        public int MaxValue(TreeNode root, ref int? maxPathValue)
        {
            //子节点最大路径列表
            List<int> childrenMaxValueList = new List<int>();
            if (root.left != null)
            {
                //排除最大路径为负数的子节点（即将最大路径为负数的子节点路径置0），加入子节点最大路径列表。
                childrenMaxValueList.Add(Math.Max(0, MaxValue(root.left, ref maxPathValue)));
            }
            if (root.right != null)
            {
                //排除最大路径为负数的子节点（即将最大路径为负数的子节点路径置0），加入子节点最大路径列表。
                childrenMaxValueList.Add(Math.Max(0, MaxValue(root.right, ref maxPathValue)));
            }

            if (maxPathValue == null || (maxPathValue < 0 && maxPathValue < root.val))
            {
                maxPathValue = root.val;
            }

            bool listCountOverZero = childrenMaxValueList.Count > 0;
            //计算当前节点的最大路径和
            int currentMaxvalue = root.val + (listCountOverZero ? childrenMaxValueList.Sum() : 0);
            //全局变量在整树各节点最大路径和中取最大值
            maxPathValue = maxPathValue > currentMaxvalue ? maxPathValue : currentMaxvalue;
            //计算当前节点的最大路径：叶子节点为其节点值；非叶子节点为【节点值】与【其各子节点的最大路径中取最大值】之和
            return root.val + (listCountOverZero ? childrenMaxValueList.Max() : 0);
        }

        public int MaxPathSum2(TreeNode tr)
        {
            int? outs = null;
            MaxValue2(tr, ref outs);
            return outs.Value;
        }
        public int MaxValue2(TreeNode rt, ref int? max)
        {
            List<int> childmax = new List<int>();
            if (rt.left != null)
            {
                childmax.Add(Math.Max(0, MaxValue2(rt.left, ref max)));
            }
            if (rt.right != null)
            {
                childmax.Add(Math.Max(0, MaxValue2(rt.right, ref max)));
            }
            if (max == null || (max < 0 && max < rt.val))
            {
                max = rt.val;
            }

            int currmax = rt.val;
            int outInt = rt.val;
            if (childmax.Count > 0)
            {
                currmax = currmax + childmax.Sum();
                outInt= rt.val + childmax.Max();
            }

            max = Math.Max(max.Value, currmax);

            return outInt;

        }
        #endregion
        #region list2
        int max = int.MinValue;
        public int MaxPathSum3(TreeNode root)
        {
            DFS(root);
            return max;
        }

        /// <summary>
        /// 通过root节点的单边最大和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int DFS(TreeNode root)
        {
            if (root == null) return 0;
            int leftVal = Math.Max(0, DFS(root.left));
            int rightVal = Math.Max(0, DFS(root.right));

            max = Math.Max(max, leftVal + root.val + rightVal);

            return root.val + Math.Max(leftVal, rightVal);
        }
        #endregion

    
        //public int DFSTEST(TreeNode root)
        //{
            
        //}
 

    }
}
