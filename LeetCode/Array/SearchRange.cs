﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class SearchRange
    {
        //在排序数组中查找元素的第一个和最后一个位置(重点)
        //给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。

        //你的算法时间复杂度必须是 O(log n) 级别。

        //如果数组中不存在目标值，返回[-1, -1]。





        //public int[] SearchRange2(int[] nums, int target)
        //{

          



        //}

        #region 测试区域
        public static int[] SearchRange1(int[] nums, int target)
        {

            int[] outlist = new int[] { -1, -1 };
            if (nums.Length < 1)
            {
                return outlist;
            }
            else if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    return new int[] { 0, 0 };
                }
            }

            int i = 0;
            int j = nums.Length - 1;
            while (i < j)
            {

                if (target > nums[j] || target < nums[i])
                {
                    return outlist;
                }
                if (target > nums[i])
                {
                    i++;
                }
                if (target < nums[j])
                {
                    j--;
                }
                if (target == nums[i])
                {
                    outlist[0] = i;
                    if (i + 1 > j)
                    {
                        outlist[1] = i;
                    }
                    else
                    {
                        for (int x = i + 1; x <= j; x++)
                        {
                            if (nums[x] == target)
                            {
                                outlist[1] = x;
                            }
                            else
                            {
                                outlist[1] = x - 1;
                                break;
                            }
                        }
                    }
                    return outlist;
                }

                if (target == nums[j])
                {
                    outlist[1] = j;
                    if (j - 1 < i)
                    {
                        outlist[0] = j;
                    }
                    else
                    {
                        for (int x = j - 1; x >= i; x--)
                        {
                            if (nums[x] == target)
                            {
                                outlist[0] = x;
                            }
                            else
                            {
                                outlist[0] = x + 1;
                                break;
                            }
                        }
                    }
                    return outlist;

                }




            }
            return outlist;
        }
        public int[] SearchRange3(int[] nums, int target)
        {
            int low = -1;int high = -1;
            int i = 0;
            int j = nums.Length - 1;
            //要有等号
            while(i<=j)
            {
                int mid = (i + j) / 2;
                if (target == nums[mid])
                { 
                    if(mid==0||nums[mid-1]< target)
                    {
                        low = mid;
                        break;
                    }
                    else
                    {
                        j = mid - 1;
                    }
                }
                else if(target> nums[mid])
                {

                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }

            }
            i = 0;
            j = nums.Length - 1;
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (target == nums[mid])
                {
                    if (mid == nums.Length - 1 || nums[mid + 1] > target)
                    {
                        high = mid;
                        break;
                    }
                    else
                    {
                        i = mid + 1;
                    }
                }
                else if (target > nums[mid])
                {

                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }

            }


            return new int[]{low,high};
        }

        public int[] SearchRange5(int[] nums, int target)
        {
            int low = -1;
            int high = -1;
            int i = 0;
            int j = nums.Length - 1;
            while(i<=j)
            {
                int mid = (i + j) / 2;
                if(target==nums[mid])
                {
                    if(mid==0||nums[mid-1]<target)
                    {
                        low = mid;
                        break;
                    }
                    else
                    {
                        j = mid - 1;
                    }
                }
                else if(target>nums[mid])
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }

            }
            i = 0;
            j = nums.Length - 1;
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (target == nums[mid])
                {
                    if (mid == nums.Length - 1 || nums[mid + 1] > target)
                    {
                        high = mid;
                        break;
                    }
                    else
                    {
                        i = mid + 1;
                    }
                }
                else if (target > nums[mid])
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }

            }
            return new int[] { low,high };
        }
        #endregion
    }
}
