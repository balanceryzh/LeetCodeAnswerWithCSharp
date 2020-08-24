using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.tree
{

    //给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
    public class ZigzagLevelOrder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;

            bool left2right = true;
            stack.Push(root);
            while (stack.Count != 0)
            {
                int n = stack.Count;
                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                List<int> l = new List<int>();

                while (n > 0)
                {
                    TreeNode tn = stack.Pop();
                    l.Add(tn.val);
                    if (left2right)
                    {
                        if (tn.left != null)
                            stack2.Push(tn.left);
                        if (tn.right != null)
                            stack2.Push(tn.right);
                    }
                    else
                    {
                        if (tn.right != null)
                            stack2.Push(tn.right);
                        if (tn.left != null)
                            stack2.Push(tn.left);
                    }
                    n--;
                }

                left2right = !left2right;
                stack = stack2;
                list.Add(l);
            }
            return list;
        }

        public IList<IList<int>> ZigzagLevelOrder3(TreeNode root)
        {
            List<IList<int>> outList = new List<IList<int>>();
            if (root == null)
            {
                return outList;
            }
            Stack<TreeNode> treeNodes = new Stack<TreeNode>();
            treeNodes.Push(root);
            int temp = 0;
            while (treeNodes.Count > 0)
            {
                List<int> nodeList = new List<int>();
                int count = treeNodes.Count;
                Stack<TreeNode> treeNodes2 = new Stack<TreeNode>();
                for (int i = 0; i < count; i++)
                {
                    TreeNode tempNode = treeNodes.Pop();
                    nodeList.Add(tempNode.val);
                    if (temp == 1)
                    {
                       
                        if (tempNode.right != null) treeNodes2.Push(tempNode.right);
                        if (tempNode.left != null) treeNodes2.Push(tempNode.left);
                    }
                    else
                    {
                        
                        if (tempNode.left != null) treeNodes2.Push(tempNode.left);
                        if (tempNode.right != null) treeNodes2.Push(tempNode.right);

                    }

                }



                if (temp == 0) temp = 1;
                else temp = 0;

                treeNodes = treeNodes2;
                outList.Add(nodeList);
            }

            return outList;
        }


        public IList<IList<int>> ZigzagLevelOrder4(TreeNode root) {
            List<IList<int>> outList = new List<IList<int>>();

            if(root==null)
            {
                return outList;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            int temp = 0;
            while(stack.Count>0)
            {
                List<int> list = new List<int>();
                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                int count = stack.Count;
                for(int i=0;i<count;i++)
                {
                    TreeNode treeNode = stack.Pop();
                    list.Add(treeNode.val);
                    if(temp==0)
                    {
                        if (treeNode.left != null) stack2.Push(treeNode.left);
                        if (treeNode.right != null) stack2.Push(treeNode.right);
                    }
                    else
                    {
                        if (treeNode.right != null) stack2.Push(treeNode.right);
                        if (treeNode.left != null) stack2.Push(treeNode.left);

                    }

                }


                stack = stack2;
                if (temp == 0) temp = 1;
                else temp = 0;
                outList.Add(list);
            }
            return outList;
        }

        public IList<IList<int>> ZigzagLevelOrder5(TreeNode root)
        {
            List<IList<int>> outList = new List<IList<int>>();
            Stack<TreeNode> tempList = new Stack<TreeNode>();
            int temp = 0;
            tempList.Push(root);
            while(tempList.Count>0)
            {
                int count = tempList.Count;
                Stack<TreeNode> tempList2 = new Stack<TreeNode>();
                List<int> node = new List<int>();
                for (int i=0;i<count;i++)
                {
                    TreeNode treeNode = tempList.Pop();
                    node.Add(treeNode.val);
                    if(temp==0)
                    {
                        if (treeNode.left != null) { tempList2.Push(treeNode.left); }
                        if (treeNode.right != null) { tempList2.Push(treeNode.right); }
                    }
                    else
                    {
                        if (treeNode.right != null) { tempList2.Push(treeNode.right); }
                        if (treeNode.left != null) { tempList2.Push(treeNode.left); }
                       
                    }
                }

                if(temp==0)
                {
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
                tempList = tempList2;
                outList.Add(node);
            }
            return outList;

        }
    }
}
