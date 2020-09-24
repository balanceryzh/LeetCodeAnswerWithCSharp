﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.tree
{
    //    给定两个非空二叉树 s 和 t，检验 s 中是否包含和 t 具有相同结构和节点值的子树。s 的一个子树包括 s 的一个节点和这个节点的所有子孙。s 也可以看做它自身的一棵子树。

    //示例 1:
    //给定的树 s:

    //     3
    //    / \
    //   4   5
    //  / \
    // 1   2
    //给定的树 t：

    //   4 
    //  / \
    // 1   2
    //返回 true，因为 t 与 s 的一个子树拥有相同的结构和节点值。

    //示例 2:
    //给定的树 s：

    //     3
    //    / \
    //   4   5
    //  / \
    // 1   2
    //    /
    //   0
    //给定的树 t：

    //   4
    //  / \
    // 1   2
    //返回 false。


    public class isSubtree
    {
        #region list
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s != null && t == null) return false;
            if (s == null && t != null) return false;
            return isSame(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }
        public bool isSame(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s != null && t == null) return false;
            if (s == null && t != null) return false;
            return s.val != t.val ? false : isSame(s.left, t.left) && isSame(s.right, t.right);
        }
        #endregion

        //public bool IsSubtree2(TreeNode s, TreeNode t)
        //{
  

        //}

        
    }
}
