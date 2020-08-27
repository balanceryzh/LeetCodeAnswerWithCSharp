using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.StackQeueue
{
    //会议室
    public class MinMeetingRooms
    {
        public static  int MinMeetingRooms2(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return 0;
            }
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            Queue<int[]> temp = new Queue<int[]>();
            for(int i=0;i<intervals.Length;i++)
            {
                if (temp.Count > 0)
                {
                    int go = temp.Count;
                    for (int j=0;j< go; j++)
                    {
                        int[] tempint = temp.Dequeue();
                        if (tempint[1] <= intervals[i][0])
                        {
                            tempint = intervals[i];
                            temp.Enqueue(tempint);
                            break;
                        }
                        else
                        {
                            temp.Enqueue(tempint);
                            if(j==go-1)
                            {
                                temp.Enqueue(intervals[i]);
                            }
                        }
                    }
  
                    
                }   
                else
                {
                    temp.Enqueue(intervals[i]);
                }
            }

            return temp.Count;
        }

        public static int MinMeetingRooms3(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return 0;
            }

            Queue<int[]> list = new Queue<int[]>();
            intervals = intervals.OrderBy(o=>o[0]).ToArray();
            for(int i=0;i<intervals.Length;i++)
            {
                if(list.Count>0)
                {
                    int count = list.Count;
                    for(int j=0;j<count;j++)
                    {
                        int[] temp = list.Dequeue();
                        if(temp[1]<= intervals[i][0])
                        {
                            temp = intervals[i];
                            list.Enqueue(temp);
                            break;
                        }
                        else
                        {
                            list.Enqueue(temp);
                            if(j==count-1)
                            {
                                list.Enqueue(intervals[i]);
                            }
                        }
                    }
                }
                else
                {
                    list.Enqueue(intervals[i]);
                }

            }


            return list.Count;

        }


        public static int MinMeetingRooms4(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return 0;
            }
            Queue<int[]> queue = new Queue<int[]>();
            for(int i=0;i<intervals.Length;i++)
            {
                if(queue.Count>0)
                {
                    int count = queue.Count;
                    for(int j=0;j<count;j++)
                    {
                        int[] temp = queue.Dequeue();
                        if(temp[1]<= intervals[i][0])
                        {
                            temp = intervals[i];
                            queue.Enqueue(temp);
                            break;
                        }
                        else
                        {
                            queue.Enqueue(temp);
                            if(j==count-1)
                            {
                                queue.Enqueue(intervals[i]);
                            }
                        }
                    }
                }
                else
                {
                    queue.Enqueue(intervals[i]);

                }

            }



            return queue.Count;

        }

        public static int MinMeetingRooms5(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return 0;
            }

            intervals = intervals.OrderBy(o => o[0]).ToArray();

            Queue<int[]> list = new Queue<int[]>();

            for(int i=0;i< intervals.Length;i++)
            {
                if(list.Count>0)
                {
                    int count = list.Count;
                    for(int j=0;j<count;j++)
                    {
                        int[] temp = list.Dequeue();
                        if(temp[1]<=intervals[i][0])
                        {
                            temp = intervals[i];
                            list.Enqueue(temp);
                            break;
                        }
                        else
                        {
                            list.Enqueue(temp);
                            if(j==count-1)
                            {
                                list.Enqueue(intervals[i]);
                            }
                        }

                    }
                }
                else
                {

                    list.Enqueue(intervals[i]);
                };


            }

            return list.Count;
        }
    }
}
