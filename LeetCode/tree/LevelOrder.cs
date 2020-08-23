using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    //二叉树的层序遍历(重点)

    public class TreeNode
    {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
    }
    /// <summary>
    /// 8/3
    /// </summary>
    public class LevelOrder
    {
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var list = new List<int>();
                int count = queue.Count;

                for (int i = 0; i < count; ++i)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                result.Add(list);
            }

            return result;
        }


    }
    #region 测试区域

    public class Test
    {
        public IList<IList<int>> LevelOrderTest(TreeNode root)
        {
            IList<IList<int>> outList = new List<IList<int>>();
            if (root == null) return outList;
            var tempList = new Queue<TreeNode>();
            tempList.Enqueue(root);
            while(tempList.Count>0)
            {
               
                int Count = tempList.Count;
                List<int> nodeList = new List<int>();
                
                for (int i=0;i<Count;i++)
                {
                    TreeNode temp = tempList.Dequeue();
                    nodeList.Add(temp.val);
                    if(temp.left!=null)
                    {
                        tempList.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        tempList.Enqueue(temp.right);
                    }

                }
                outList.Add(nodeList);
            }



            return outList;
        }


        public IList<IList<int>> LevelOrderTest2(TreeNode root)
        {
            List<IList<int>> outList = new List<IList<int>>();

            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);

            while(treeNodes.Count>0)
            {
                List<int> nodeList = new List<int>();
                int count = treeNodes.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode tempNode = treeNodes.Dequeue();
                    nodeList.Add(tempNode.val);
                    if(tempNode.left!=null)
                    {
                        treeNodes.Enqueue(tempNode.left);
                    }
                    if(tempNode.right != null)
                    {
                        treeNodes.Enqueue(tempNode.right);
                    }
                }
               

                
                outList.Add(nodeList);
            }

            return outList;
        }

        public IList<IList<int>> LevelOrderTest3(TreeNode root)
        {
            List<IList<int>> outlist = new List<IList<int>>();
            Queue<TreeNode> templist = new Queue<TreeNode>();

            templist.Enqueue(root);
            while(templist.Count>0)
            {
                List<int> node = new List<int>();
                int count = templist.Count;
                for(int i=0;i<count;i++)
                {
                   TreeNode tempNode= templist.Dequeue();
                    node.Add(tempNode.val);
                    if (tempNode.left != null) { templist.Enqueue(tempNode.left); }
                    if (tempNode.right != null) { templist.Enqueue(tempNode.right); }
                }
                outlist.Add(node);
            }
            return outlist;
        }


        public IList<IList<int>> LevelOrderTest5(TreeNode root)
        {
            List<IList<int>> outList = new List<IList<int>>();
            if(root==null)
            {
                return outList;
            }
            Queue<TreeNode> temp = new Queue<TreeNode>();
            temp.Enqueue(root);
            while(temp.Count>0)
            {
                int count = temp.Count;
                List<int> outListNode = new List<int>();
                for(int i=0;i<count;i++)
                {
                  TreeNode tempnode=  temp.Dequeue();
                    outListNode.Add(tempnode.val);
                    if (tempnode.left != null) { temp.Enqueue(tempnode.left); }
                    if (tempnode.right != null) { temp.Enqueue(tempnode.right); }
                }

                outList.Add(outListNode);

            }

            return outList;

        }

    }
    #endregion
}
