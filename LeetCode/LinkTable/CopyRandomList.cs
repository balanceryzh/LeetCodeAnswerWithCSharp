using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
/// <summary>
/// 给定一个链表，每个节点包含一个额外增加的随机指针，该指针可以指向链表中的任何节点或空节点。

//要求返回这个链表的 深拷贝。 
/// </summary>
namespace ConsoleTest.LinkTable
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public class CopyRandomList
    {

        #region 例子
        public Node CopyRandomList2(Node head)
        {
            if (head == null)
            {
                return head;
            }

            Node i = new Node(-1);
            Node j = new Node(-2);

            i.next = j;

            Dictionary<Node, Node> kv = new Dictionary<Node, Node>();



            while (head != null)
            {
                if (kv.ContainsKey(head))
                {
                    j.next = kv[head];
                }
                else
                {
                    j.next = new Node(head.val);
                    kv.TryAdd(head, j.next);
                }

                if (head.random != null)
                {
                    if (kv.ContainsKey(head.random))
                    {
                        j.next.random = kv[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        kv.TryAdd(head.random, j.next.random);
                    }
                }

                j = j.next;
                head = head.next;
            }





            return i.next.next;
        }

       


      

    


        public Node CopyRandomList6(Node head)
        {
            Node i = new Node(-2);
            Node j = new Node(-1);
            i.next = j;
            Dictionary<Node, Node> list = new Dictionary<Node, Node>();
            while(head!=null)
            {
                if(list.ContainsKey(head))
                {
                    j.next = list[head];
                }
                else
                {
                    j.next = new Node(head.val);
                    list.Add(head,j.next);
                }
                if(head.random!=null)
                {
                    if (list.ContainsKey(head.random))
                    {
                        j.next.random = list[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        list.Add(head.random, j.next.random);
                    }


                }

                j = j.next;
                head = head.next;
            }


            return i.next.next;
        }

        public Node CopyRandomList7(Node head) 
        {
            Node i = new Node(-2);
            Node j = new Node(-1);
            i.next = j;
            Dictionary<Node, Node> list = new Dictionary<Node, Node>();

            while(head!=null)
            {
                if(list.ContainsKey(head))
                {
                    j.next = list[head];
                }
                else
                {
                    j.next = new Node(head.val);
                    list.Add(head, j.next);
                }
                if(head.random!=null)
                {
                    if (list.ContainsKey(head.random))
                    {
                        j.next.random = list[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        list.Add(head.random, j.next.random);
                    }

                }
                head = head.next;
                j = j.next;

            }

            return i.next.next;
        
        }
        #endregion

        public Node CopyRandomLists(Node head)
        {
            Node j = new Node(-1);
            Node i =j;
            Dictionary<Node, Node> list = new Dictionary<Node, Node>();
          
            while(head!=null)
            {
                if(list.ContainsKey(head))
                {
                    j.next = list[head];
                }
                else
                {
                    j.next = new Node(head.val);
                    list.Add(head, j.next);
                }
                if(head.random!=null)
                {
                    if (list.ContainsKey(head.random))
                    {
                        j.next.random = list[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        list.Add(head.random, j.next.random);
                    }
                }
                head = head.next;
                j = j.next;
            }

            return i.next;


        }

    }
}
