using System;

namespace ConsoleApp1
{
    class Program
    {
        public static object binarySearch(int[] array, int value)
        {
            int index = 0;
            int limit = array.Length -1;

            while (index <= limit)
            {
                decimal val = (index + limit) / 2;
                int point = (int)Math.Ceiling(val);
                var entry = array[point];
                if(value < entry)
                {
                    limit = point - 1;
                    continue;
                }
                return point ;
            }
            return -1;
        }


        static void Main(string[] args)
        {

            int[] arr = { 4, 5, 7, 11, 12, 15, 15, 21, 40, 45 };
            Console.WriteLine(binarySearch(arr, 11));
            Console.WriteLine(Array.BinarySearch(arr, 11));    
        }
    }
}
