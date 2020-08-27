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
        public Node CopyRandomList2(Node head)
        {
            if (head == null)
            {
                return head;
            }

            Node tempHead = new Node(-1);
            Node currentNode = new Node(-2);

            tempHead.next = currentNode;

            Dictionary<Node, Node> kv = new Dictionary<Node, Node>();



            while (head != null)
            {
                if (kv.ContainsKey(head))
                {
                    currentNode.next = kv[head];
                }
                else
                {
                    currentNode.next = new Node(head.val);
                    kv.TryAdd(head, currentNode.next);
                }

                if (head.random != null)
                {
                    if (kv.ContainsKey(head.random))
                    {
                        currentNode.next.random = kv[head.random];
                    }
                    else
                    {
                        currentNode.next.random = new Node(head.random.val);
                        kv.TryAdd(head.random, currentNode.next.random);
                    }
                }

                currentNode = currentNode.next;
                head = head.next;
            }





            return tempHead.next.next;
        }

        public Node CopyRandomList3(Node head)
        {
            if(head==null)
            {
                return head;
            }

            Node i = new Node(-1);
            Node j = new Node(-2);
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
                    list.TryAdd(head, j.next);

                }
                if(head.random!=null)
                {

                    if(list.ContainsKey(head.random))
                    {
                        j.next.random = list[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        list.TryAdd(head.random, j.next.random);
                    }
                }
                head = head.next;
                j = j.next;
            }

            return i.next.next;
;
        }


      

         public Node CopyRandomList5(Node head)
        {
            if (head == null)
            {
                return head;
            }
            Node i = new Node(-1);
            Node j = new Node(-2);
            j = i.next;
            Dictionary<Node, Node> list = new Dictionary<Node, Node>();
            while(head!=null)
            {
                if(list.ContainsValue(head))
                {
                    j.next = list[head];
                }
                else
                {
                    j.next =new Node(head.val);
                    list.TryAdd(head, j.next);
                }
                if(head.random!=null)
                {
                    if (list.ContainsValue(head.random))
                    {
                        j.next.random = list[head.random];
                    }
                    else
                    {
                        j.next.random = new Node(head.random.val);
                        list.TryAdd(head.random, j.next.random);
                    }
                }

                j = j.next;
                head = head.next;

            }


            return i.next.next;

            

        }
    }
}
