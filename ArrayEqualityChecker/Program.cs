//Check if two arrays are equal or not
//Given two arrays A and B of equal size N, the task is to find if given arrays are equal or not. Two arrays are said to be equal if both of them contain same set of elements, arrangements (or permutation) of elements may be different though.
//Note : If there are repetitions, then counts of repeated elements must also be the same for two arrays to be equal.
//Example 1:
//Input: N = 5
//A[] = {1,2,5,4,0}
//B[] = {2,4,5,0,1}
//Output: 1
//Explanation: Both the array can be rearranged to {0,1,2,4,5}
//Example 2:
//Input: N = 3
//A[] = {1,2,5}
//B[] = {2,4,15}
//Output: 0
//Explanation: A[] and B[] have only one common value.

using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayEqualityChecker3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nArray Equality Checker1");

                int N;
                while (true)
                {
                    Console.Write("\nEnter the size of the arrays: ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                        return;

                    if (int.TryParse(input, out N) && N > 0)
                        break;
                    Console.WriteLine("Enter a valid positive integer for N.");
                }

                int[] A = new int[N];
                Console.WriteLine($"\nEnter {N} elements for array A:");
                if (!InputArray("A", A))
                    return;

                int[] B = new int[N];
                Console.WriteLine($"\nEnter {N} elements for array B:");
                if (!InputArray("B", B))
                    return;

                Console.WriteLine("\nInput:");
                Console.WriteLine($"N = {N}");
                Console.WriteLine($"A = [{string.Join(", ", A)}]");
                Console.WriteLine($"B = [{string.Join(", ", B)}]");

                int result = AreArraysEqual(A, B, N);
                Console.WriteLine($"\nResult: {result}");
                Console.WriteLine(result == 1 ? "The arrays are equal." : "The arrays are not equal.");

                Console.Write("\nDo you want to check another pair of arrays? (yes/no): ");
                string continue_input = Console.ReadLine().ToLower();
                if (continue_input != "yes" && continue_input != "y")
                    break;
            }
        }

        static bool InputArray(string arrayName, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter element {i + 1} for array {arrayName}: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                        return false;

                    if (int.TryParse(input, out arr[i]))
                        break;

                    Console.WriteLine("Enter a valid integer.");
                }
            }
            return true;
        }

        static int AreArraysEqual(int[] A, int[] B, int N)
        {
            if (A.Length != N || B.Length != N)
            {
                return 0;
            }

            Dictionary<int, int> freqA = new Dictionary<int, int>();
            Dictionary<int, int> freqB = new Dictionary<int, int>();

            foreach (int num in A)
            {
                if (!freqA.ContainsKey(num))
                    freqA[num] = 0;
                freqA[num]++;
            }

            foreach (int num in B)
            {
                if (!freqB.ContainsKey(num))
                    freqB[num] = 0;
                freqB[num]++;
            }

            if (freqA.Count != freqB.Count)
                return 0;

            foreach (var kvp in freqA)
            {
                int key = kvp.Key;
                if (!freqB.ContainsKey(key) || freqB[key] != freqA[key])
                    return 0;
            }
            return 1;
        }
    }
}