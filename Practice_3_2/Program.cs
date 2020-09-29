using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_2
{
    class Program
    {
        static readonly int[] primes = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 21, 23, 29, 31};
       
        static void DFS(ref Stack<int> some_ans, ref List<int>[] next, ref bool[] explored, int current_num)
        {

            
            explored[current_num] = true;
            some_ans.Push(current_num);

            if ((some_ans.Count == next.Length - 1) && (next[current_num].Contains<int>(1))) //answer found
            {
                foreach (int i in some_ans)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
                return;
            }

            //answer not found yet
            foreach (int n in next[current_num]) {
                if (!explored[n])
                {
                    DFS(ref some_ans, ref next, ref explored, n);
                    //if unavailable
                    some_ans.Pop();
                    explored[n] = false;
                }
            }
            
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            while(input <2 || input >16 || input % 2 != 0)
            {
                Console.WriteLine("Invalid Input. Please Try Again...");
                input = int.Parse(Console.ReadLine());
            }

            int[] arr = new int[input + 1];
            
            for(int i=1; i<arr.Length; i++)
            {
                arr[i] = i;
            }
          
            //find all possible next numbers for each number
            List<int>[] next = new List<int>[arr.Length];
            bool[] explored = new bool[arr.Length];
            explored[1] = true;

            for (int j = 1; j < arr.Length; j++)
            {
                next[j] = new List<int>();
                for (int i = 1; i < arr.Length; i++)
                {
                    if (i != j)
                    {
                        int sum = i + j;
                        if (primes.Contains<int>(sum)) //sum is prime
                        {
                            next[j].Add(i);//record
                        }
                    }
                }
            }
            
            Stack<int> some_ans = new Stack<int>();
            DFS(ref some_ans, ref next, ref explored, 1);

            Console.ReadKey();
        }
    }
}
