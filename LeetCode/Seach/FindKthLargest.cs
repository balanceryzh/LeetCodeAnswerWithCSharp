using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Seach
{
//    215. 数组中的第K个最大元素
//在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。

//示例 1:

//输入: [3,2,1,5,6,4]
//    和 k = 2
//输出: 5
//示例 2:

//输入: [3,2,3,1,2,4,5,5,6]
//    和 k = 4
//输出: 4

    public class findKthLargest
    {
        #region list
        int[] nums;
        public void swap(int a, int b)
        {
            int tmp = this.nums[a];
            this.nums[a] = this.nums[b];
            this.nums[b] = tmp;
        }

        public int partition(int left, int right, int pivot_index)//把左右之间以基准值为中心分好
        {
            int pivot = this.nums[pivot_index];
            // 1. 把基准值移到最后
            swap(pivot_index, right);
            int store_index = left;

            // 2. 把所有小于基准值的元素移到左边
            for (int i = left; i <= right; i++)
            {
                if (this.nums[i] < pivot)
                {
                    swap(store_index, i);
                    store_index++;
                }
            }

            // 3. 把基准值移到应有的位置
            swap(store_index, right);

            // 4. 返回基准值的下标
            return store_index;
        }

        public int quickselect(int left, int right, int k_smallest)
        {
            /*
            返回左右之间第k小的元素
            */

            if (left == right) // 如果左右相等，即只有一个元素
                return this.nums[left];  // 返回那个元素

            // 选择一个随机的基准值的下标
            Random random_num = new Random();
            int pivot_index = left + random_num.Next(right - left);

            pivot_index = partition(left, right, pivot_index);

            // 基准值是第(N - k)小的元素，即第k大的元素
            if (k_smallest == pivot_index)
                return this.nums[k_smallest];
            // 去左（小于基准值的）区间
            else if (k_smallest < pivot_index)
                return quickselect(left, pivot_index - 1, k_smallest);
            // 去右（大于基准值的）区间
            return quickselect(pivot_index + 1, right, k_smallest);
        }

        public int FindKthLargest(int[] nums, int k)
        {
            this.nums = nums;
            int size = nums.Length;
            // 第k大即第(N - k)小的元素
            return quickselect(0, size - 1, size - k);
        }

        #endregion
        #region list2
        public void swap(int a, int b, int[] nums)
        {
            int tmp = nums[a];
            nums[a] = nums[b];
            nums[b] = tmp;
        }

        public int partition(int left, int right, int index, int[] nums)//把左右之间以基准值为中心分好
        {
            int pivot = nums[index];
            // 1. 把基准值移到最后
            swap(index, right, nums);
            int outindex = left;

            // 2. 把所有小于基准值的元素移到左边
            for (int i = left; i <= right; i++)
            {
                if (nums[i] < pivot)
                {
                    swap(outindex, i, nums);
                    outindex++;
                }
            }

            // 3. 把基准值移到应有的位置
            swap(outindex, right, nums);

            // 4. 返回基准值的下标
            return outindex;
        }

        public int quickselect(int left, int right, int k, int[] nums)
        {
            /*
            返回左右之间第k小的元素
            */

            if (left == right) // 如果左右相等，即只有一个元素
                return nums[left];  // 返回那个元素

            // 选择一个随机的基准值的下标
            Random random_num = new Random();
            int index = left + random_num.Next(right - left);

            index = partition(left, right, index, nums);

            // 基准值是第(N - k)小的元素，即第k大的元素
            if (k == index)
                return nums[k];
            // 去左（小于基准值的）区间
            else if (k < index)
                return quickselect(left, index - 1, k, nums);
            // 去右（大于基准值的）区间
            return quickselect(index + 1, right, k, nums);
        }

        public int FindKthLargest2(int[] nums, int k)
        {

            int size = nums.Length;
            return quickselect(0, size - 1, size - k, nums);
        }
        #endregion


        //public int FindKthLargest3(int[] nums, int k)
        //{
     
        //}
      
  
    }
}
