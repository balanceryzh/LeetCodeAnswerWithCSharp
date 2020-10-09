using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleTest.backtracking_algorithm
{

//    数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。

 

//示例：

//输入：n = 3
//输出：[
//       "((()))",
//       "(()())",
//       "(())()",
//       "()(())",
//       "()()()"
//     ]


    public  class generateParenthesis
    {
        #region list
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
           

            sb.Append('(');

            GetNext(1, 0,n,sb,result);
            return result;
        }

       public void GetNext(int l, int r,int n, StringBuilder sb, List<string> result)
        {
            //l>r   l==n
            //l>r   l<n
            //l==r  l<n
            //l==r  l==n
            if (l > r && l == n)
            {
                sb.Append(')');
                GetNext(l, r + 1, n, sb, result);
            }
            else if (l > r && l < n)
            {
                sb.Append('(');
                GetNext(l + 1, r, n, sb, result);
                sb.Append(')');
                GetNext(l, r + 1, n, sb, result);
            }
            else if (l == r && l < n)
            {
                sb.Append('(');
                GetNext(l + 1, r, n, sb, result);
            }
            else if (l == r && l == n)
            {
                result.Add(sb.ToString());
            }

            sb.Remove(sb.Length - 1, 1);
        }
        #endregion

        //public IList<string> GenerateParenthesis2(int n)
        //{


        //}


      








    }
}
