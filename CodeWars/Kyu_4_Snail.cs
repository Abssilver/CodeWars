using System;
using System.Collections.Generic;
using System.Text;

/*
Snail Sort
Given an n x n array, return the array elements arranged from outermost 
elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]
This image will illustrate things more clearly:


NOTE: The idea is not sort the elements from the lowest value to the highest;
the idea is to traverse the 2-d array in a clockwise snailshell pattern.

NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
*/

namespace CodeWars
{
    public class DirectionCounter
    {
        public int right, bottom, left, top, currentDirection;
        public DirectionCounter(int right, int bottom, int left, int top, int currentDirection)
        {
            this.right = right;
            this.bottom = bottom;
            this.left = left;
            this.top = top;
            this.currentDirection = currentDirection;
        }
    }
    class Kyu_4_Snail
    {   
        public static int[] Snail(int[][] array)
        {
            if (array.Length <= 1)
                return array[0];
            int itemNumber = array.Length * array.Length;
            List<int> snailList = new List<int>();
            DirectionCounter dirCounter = new DirectionCounter(0, 0, 0, 0, 0);
            for (int i = 0; i < itemNumber; i++)
                Iteration(dirCounter, array, snailList);
            return snailList.ToArray();
        }
        static void Iteration(DirectionCounter directionCounter, int[][] array, List<int> snailList)
        {
            switch (directionCounter.currentDirection %= 4)
            {
                case 0:
                    for (int i = directionCounter.left; i < array.Length - directionCounter.right; i++)
                        snailList.Add(array[directionCounter.top][i]);
                    directionCounter.top++;
                    break;
                case 1:
                    for (int i = directionCounter.top; i < array.Length - directionCounter.bottom; i++)//rank
                        snailList.Add(array[i][array.Length - directionCounter.right - 1]);
                    directionCounter.right++;
                    break;
                case 2:
                    for (int i = array.Length - directionCounter.right - 1; i >= directionCounter.left; i--)
                        snailList.Add(array[array.Length - directionCounter.bottom - 1][i]);//rank
                    directionCounter.bottom++;
                    break;
                default:
                    for (int i = array.Length - directionCounter.bottom - 1; i >= directionCounter.top; i--)
                        snailList.Add(array[i][directionCounter.left]);
                    directionCounter.left++;
                    break;
            }
            directionCounter.currentDirection++;
        }
    }
}
