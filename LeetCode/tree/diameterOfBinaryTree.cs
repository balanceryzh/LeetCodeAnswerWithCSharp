using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.tree
{

//    二叉树的直径
//给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过也可能不穿过根结点。

 

//示例 :
//给定二叉树

//          1
//         / \
//        2   3
//       / \     
//      4   5    
//返回 3, 它的长度是路径[4, 2, 1, 3] 或者[5, 2, 1, 3]。



    public class diameterOfBinaryTree
    {
        #region list
        public int DiameterOfBinaryTree(TreeNode root)
        {
            m_maxDistance = 0;
            Recursive(root);
            return m_maxDistance;
        }

        private int m_maxDistance;

        private int Recursive(TreeNode root)
        {
            if (root == null) return -1;

            var leftDistance = Recursive(root.left) + 1;
            var rightDistance = Recursive(root.right) + 1;
            m_maxDistance = Math.Max(leftDistance + rightDistance, m_maxDistance);

            return Math.Max(leftDistance, rightDistance);
        }
        #endregion


        //public int DiameterOfBinaryTree2(TreeNode root)
        ////{
         
        ////}
      
    }



}
