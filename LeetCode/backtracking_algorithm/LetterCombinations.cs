using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.backtracking_algorithm
{

    //电话号码的字母组合
    public class letterCombinations
    {
        #region list
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string>();
            char[][] alpha = new char[':'][];
            alpha['2'] = new char[] { 'a', 'b', 'c' };
            alpha['3'] = new char[] { 'd', 'e', 'f' };
            alpha['4'] = new char[] { 'g', 'h', 'i' };
            alpha['5'] = new char[] { 'j', 'k', 'l' };
            alpha['6'] = new char[] { 'm', 'n', 'o' };
            alpha['7'] = new char[] { 'p', 'q', 'r', 's' };
            alpha['8'] = new char[] { 't', 'u', 'v' };
            alpha['9'] = new char[] { 'w', 'x', 'y', 'z' };
            List<string> res = new List<string>();
            dfs(digits, alpha, string.Empty, 0, res);
            return res;
        }

        public void dfs(string digits, char[][] alpha, string path, int idx, List<string> res)
        {
            if (idx >= digits.Length)
            {
                res.Add(path);
                return;
            }
            if (digits[idx] > '9' || digits[idx] < '2') dfs(digits, alpha, path, idx + 2, res);

            for (int i = 0; i < alpha[digits[idx]].Length; i++) dfs(digits, alpha, new string(path + alpha[digits[idx]][i]), idx + 1, res);
        }

        #endregion
        //public IList<string> LetterCombinations2(string digits)
        //{

     


        //}

   




    }
}
