using System;

namespace Logic1
{
    class Program
    {

        public static void logic1(int[] myNum, int snumber)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();

            Array.Sort(myNum); 

            int low = 0;
            int high = myNum.Length - 1;

            while (low < high)
            {
                if (myNum[low] + myNum[high] == snumber)
                {
                    Console.WriteLine("Sum found are " + low + " and " + high);
                    low++;
                    
                }
                else if (myNum[low] + myNum[high] < snumber)
                {
                    low = low + 1;
                }
                else
                {
                    high = high - 1;
                }
            }
           // watch.Stop();
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void logic2(int[] myNum, int snumber)
        {
            
            for (int i = 0; i < myNum.Length; i++)
            {
                for (int j = i + 1; j < myNum.Length; j++)
                {

                    if (myNum[i] + myNum[j] == snumber)
                    {
                        Console.WriteLine("The Match is found at Index:" + i + "&" + j + "(" + myNum[i] + "+" + myNum[j] + ")");
                    }

                }
            }
            
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Size of Array:\n");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] myNum = new int[num];
            Console.WriteLine("Enter the Sum Number that is to be Matched:\n");
            int snumber = Convert.ToInt32(Console.ReadLine()); ;
            Console.WriteLine("Enter Elements into Array:\n");
            for (int a = 0; a < num; a++)
            {
                myNum[a] = Convert.ToInt32(Console.ReadLine());
            }



            logic1(myNum, snumber);
            logic2(myNum, snumber);
        }
    }
}
