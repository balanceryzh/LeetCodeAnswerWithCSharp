using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{

//    验证二叉搜索树
//给定一个二叉树，判断其是否是一个有效的二叉搜索树。

//假设一个二叉搜索树具有如下特征：

//节点的左子树只包含小于当前节点的数。
//节点的右子树只包含大于当前节点的数。
//所有左子树和右子树自身必须也是二叉搜索树。
//示例 1:

//输入:
//    2
//   / \
//  1   3
//输出: true
//示例 2:

//输入:
//    5
//   / \
//  1   4
//     / \
//    3   6
//输出: false
//解释: 输入为: [5,1,4,null,null,3,6]。
//     根节点的值为 5 ，但是其右子节点值为 4 。

    public class isValidBST
    {
        #region list
        public bool helper2(TreeNode rot, int low, int up)
        {   //rot为当前节点值，low为子树下限，up为上限
            if (rot == null)
            {
                return true;
            }

            if (low != -1 && rot.val <= low)
                return false;
            if (up != -1 && rot.val >= up)
                return false;


            if (!helper2(rot.left, low, rot.val))      //当前为左子树时，无下限，上限为根节点
                return false;
            if (!helper2(rot.right, rot.val, up))      //当前为右子树时，无上限，下限为根节点
                return false;




            return true;
        }

        public bool isValidBST2(TreeNode root)
        {
            return helper2(root, -1, -1);


        }
        #endregion
        public bool IsValidBST(TreeNode root)
        {
            return helper3(root, -1, -1);
        }

        public bool helper3(TreeNode rot, int low, int up)
        {
            if(rot==null)
            {
                return true;
            }
            if(low!=-1&&rot.val<=low)
            {
                return false;
            }
            if (up != -1 && rot.val >= up)
            {
                return false;
            }

            if(!helper3(rot.left,low,rot.val))
            {
                return false;
            }

            if (!helper3(rot.right, rot.val, up))
            {
                return false;
            }


            return true;


        }
    }
}
