using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class SearchRange
    {
        public static int[] SearchRange1(int[] nums, int target)
        {

            int[] outlist = new int[] { -1, -1 };
            if(nums.Length<1)
            {
                return outlist;
            }
            else if(nums.Length==1)
            {
                if(nums[0]==target)
                {
                    return new int[] {0,0 };
                }
            }

            int i = 0;
            int j = nums.Length - 1;
            while (i<j)
            {

                if(target > nums[j]|| target < nums[i])
                {
                    return outlist;
                }
                if(target>nums[i])
                {
                    i++;
                }
                if (target < nums[j])
                {
                    j--;
                }
                if(target== nums[i])
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
                        for (int x = j -1; x >=i; x--)
                        {
                            if (nums[x] == target)
                            {
                                outlist[0] = x;
                            }
                            else
                            {
                                outlist[0] = x+1;
                                break;
                            }
                        }
                    }
                    return outlist;

                }




            }
            return outlist;
        }


        public int[] SearchRange2(int[] nums, int target)
        {
            //数字的上标和下标
            int low = -1;
            int high = -1;
            //对数组搜索的双指针
            int i = 0;
            int j = nums.Length - 1;
            //先找下标
            //以一半开始查
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (nums[mid] == target)
                {
                    if (mid == 0 || nums[mid - 1] < target)
                    {
                        low = mid;
                        break;
                    }
                    //上指针朝后查
                    else j = mid - 1;
                }
                //上指针朝后查
                else if (nums[mid] > target) j = mid - 1;
                //下指针朝前查
                else i = mid + 1;
            }

            i = 0;
            j = nums.Length - 1;
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (nums[mid] == target)
                {
                    if (mid == nums.Length - 1 || nums[mid + 1] > target)
                    {
                        high = mid;
                        break;
                    }
                    else i = mid + 1;
                }
                else if (nums[mid] > target) j = mid - 1;
                else i = mid + 1;
            }

            return new int[] { low, high };
        }


        #region 测试区域

        public int[] SearchRange3(int[] nums, int target)
        {
            int low = -1;
            int high = -1;
            int left = 0;
            int right = nums.Length - 1;
            while(left<=right)
            {
                int mid = (left + right) / 2;
                if (nums[mid]==target)
                {
                    if(mid==0||nums[mid-1]<target)
                    {
                        low = mid;
                        break;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else if(nums[mid]>target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            left = 0;
            right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    if (mid == nums.Length - 1 || nums[mid + 1] > target)
                    {
                        high = mid;
                        break;
                    }
                    else
                    {
                        left = mid + 1;
                    }

                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }


            return new int[] { low, high };
        }
        #endregion
    }
}
