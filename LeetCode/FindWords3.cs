using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class FindWords3
    {
       
            class Node
            {
                public bool used;
                public bool flag;
                public char key;
                public Node previous;
                public Dictionary<char, Node> next;
                public Node(char key, Node previous)
                {
                    this.previous = previous;
                    this.used = false;
                    this.flag = false;
                    this.key = key;
                    this.next = new Dictionary<char, Node>();
                }
            }
            public IList<string> FindWords(char[][] board, string[] words)
            {
                // A=>B=>C
                Node root = new Node('\0', null);
                foreach (string word in words)
                {
                    Node node = root;
                    foreach (char c in word)
                    {
                        Node t;
                        if (node.next.TryGetValue(c, out t) == false)
                        {
                            t = new Node(c, node);
                            node.next[c] = t;
                        }
                        node = t;
                    }
                    node.used = true;
                }
                this.n = board.Length;
                this.m = board[0].Length;
                flag = new bool[n, m];
                res = new List<string>();
                this.board = board;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (root.next.ContainsKey(board[i][j]))
                        {
                            flag[i, j] = true;
                            FindWords(i, j, root.next[board[i][j]]);
                            flag[i, j] = false;
                        }
                    }
                }
                return res;
            }

            int n, m;
            char[][] board;
            IList<string> res;
            bool[,] flag;
            void FindWords(int y, int x, Node node)
            {
                if (node.used == true && node.flag == false)
                {
                    Node tmp = node;
                    node.flag = true;
                    Stack<char> stack = new Stack<char>();
                    stack.Push(tmp.key);
                    while (tmp.previous.key != '\0')
                    {
                        tmp = tmp.previous;
                        stack.Push(tmp.key);
                    }
                    res.Add(new string(stack.ToArray()));
                }
                if (node.next.Count == 0)
                {
                    return;
                }
                if (y > 0 && flag[y - 1, x] == false && node.next.ContainsKey(board[y - 1][x]))
                {
                    flag[y - 1, x] = true;
                    FindWords(y - 1, x, node.next[board[y - 1][x]]);
                    flag[y - 1, x] = false;
                }
                if (y < n - 1 && flag[y + 1, x] == false && node.next.ContainsKey(board[y + 1][x]))
                {
                    flag[y + 1, x] = true;
                    FindWords(y + 1, x, node.next[board[y + 1][x]]);
                    flag[y + 1, x] = false;
                }
                if (x > 0 && flag[y, x - 1] == false && node.next.ContainsKey(board[y][x - 1]))
                {
                    flag[y, x - 1] = true;
                    FindWords(y, x - 1, node.next[board[y][x - 1]]);
                    flag[y, x - 1] = false;
                }
                if (x < m - 1 && flag[y, x + 1] == false && node.next.ContainsKey(board[y][x + 1]))
                {
                    flag[y, x + 1] = true;
                    FindWords(y, x + 1, node.next[board[y][x + 1]]);
                    flag[y, x + 1] = false;
                }
            }
        }
    
}
