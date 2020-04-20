using System;
using System.Collections.Generic;
using System.Text;

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
