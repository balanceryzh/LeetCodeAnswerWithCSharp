using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    using VT = System.ValueTuple<int, int>;
    public class FindWords
    {
      
        public static IList<string> FindWords1(char[][] board, string[] words)
        {
            List<string> strList = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (IsFind(board, words[i]))
                {
                    strList.Add(words[i]);
                }
            }
            return strList;
        }
        public static bool IsFind(char[][] board, string word)
        {
           
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    for (int z = 0; z < board[j].Length; z++)
                    {
                       HashSet<VT> wordlist = new HashSet<VT>();
                        if (board[j][z] == word[0])
                        {
                            wordlist.Add((j,z));
                            if (word.Length == 1)
                            {
                                return true;
                            }
                            if (IsFindOne(board, j, z, word, 1, wordlist))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool IsFindOne(char[][] board, int j, int z, string wordOne, int indexs, HashSet<VT> wordlist)
        {

            if (j - 1 >= 0 && !wordlist.Contains(((j - 1), z))&&board[j - 1][z] == wordOne[indexs])
            {
                
                    wordlist.Add(((j-1),z));
                    if (wordOne.Length == indexs + 1)
                    {
                        return true;
                    }
                    else
                    {
                        if (IsFindOne(board, j - 1, z, wordOne, indexs + 1, wordlist))
                        {
                            return true;
                        }
                    }
                
            }
            if (z - 1 >= 0 && !wordlist.Contains((j,(z - 1)))&& board[j][z - 1] == wordOne[indexs])
            {
               
               
                    wordlist.Add((j, (z - 1)));
                    if (wordOne.Length == indexs + 1)
                    {
                        return true;
                    }
                    else
                    {

                        if (IsFindOne(board, j, z - 1, wordOne, indexs + 1, wordlist))
                        {
                            return true;
                        }
                    }
                

            }
            if (j + 1 < board.Length && !wordlist.Contains(((j + 1),z))&& board[j + 1][z] == wordOne[indexs])
            {
                
               
                    wordlist.Add(((j + 1), z));
                    if (wordOne.Length == indexs + 1)
                    {
                        return true;
                    }
                    else
                    {

                        if (IsFindOne(board, j + 1, z, wordOne, indexs + 1, wordlist))
                        {
                            return true;
                        }
                    }
                

            }
            if (z + 1 < board[j].Length && !wordlist.Contains((j,(z + 1)))&& board[j][z + 1] == wordOne[indexs])
            {
              
                
                    wordlist.Add((j, (z + 1)));
                    if (wordOne.Length == indexs + 1)
                    {
                        return true;
                    }
                    else
                    {
                        if (IsFindOne(board, j, z + 1, wordOne, indexs + 1, wordlist))
                        {
                            return true;
                        }
                    }
                
            }
            wordlist.Remove((j,z));
            return false;
        }
    }



   
}
