using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ConsoleTest.Design
{
    public class LRUCache
    {

        int capacity;
        Node head, tail;
        Dictionary<int, Node> LRUDic;
        public class Node
        {
            public int key;
            public int value;
            public Node pre;
            public Node next;
        }
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            LRUDic = new Dictionary<int, Node>();
            head = new Node();
            tail = new Node();
            head.next = tail;
            tail.pre = head;

        }

        public int Get(int key)
        {
            if (LRUDic.ContainsKey(key))
            {
                int value = LRUDic[key].value;
                DelletNode(LRUDic[key]);
                AddNodeAtHead(LRUDic[key]);
                return value;
            }
            else
            {
                return -1;
            }
        }

        public void Set(int key, int value)
        {
            if (LRUDic.ContainsKey(key))
            {
                Node node = LRUDic[key];
                DelletNode(node);
                node.value = value;
                AddNodeAtHead(node);
                return;
            }
            if (capacity > LRUDic.Count)
            {
                Node node = new Node();
                node.key = key;
                node.value = value;
                LRUDic.Add(key, node);
                AddNodeAtHead(node);
            }
            else
            {
                Node node = LRUDic[tail.pre.key];
                LRUDic.Remove(DelletTail());
                node.key = key;
                node.value = value;
                AddNodeAtHead(node);
                LRUDic.Add(key, node);
            }
        }

       

        public void AddNodeAtHead(Node node)
        {
            node.next = head.next;
            head.next.pre = node;
            head.next = node;
            node.pre = head;

        }
        public void DelletNode(Node node)
        {
            node.pre.next = node.next;
            node.next.pre = node.pre;
        }
        public int DelletTail()
        {
            int key = tail.pre.key;
            Node node = tail.pre;
            node.pre.next = tail;
            tail.pre = node.pre;
            return key;
        }
    }

    public class LRUCache2 {
        public class Node
        {
           public  int key;
           public  int value;
           public  Node pre;
           public  Node next;
            

        }
     
    }
}
