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

namespace ArrayEqualityChecker2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = 5;
            int[] A1 = new int[] { 1, 2, 5, 4, 0 };
            int[] B1 = new int[] { 2, 4, 5, 0, 1 };
            Console.WriteLine("Example 1:");
            Console.WriteLine($"N = {N1}");
            Console.WriteLine($"A[] = [{string.Join(", ", A1)}]");
            Console.WriteLine($"B[] = [{string.Join(", ", B1)}]");
            Console.WriteLine($"Output: {AreArraysEqual(A1, B1, N1)}");
            Console.WriteLine();

            int N2 = 3;
            int[] A2 = new int[] { 1, 2, 5 };
            int[] B2 = new int[] { 2, 4, 15 };
            Console.WriteLine("Example 2:");
            Console.WriteLine($"N = {N2}");
            Console.WriteLine($"A[] = [{string.Join(", ", A2)}]");
            Console.WriteLine($"B[] = [{string.Join(", ", B2)}]");
            Console.WriteLine($"Output: {AreArraysEqual(A2, B2, N2)}");
            Console.WriteLine();

            int N3 = 6;
            int[] A3 = new int[] { 1, 2, 2, 3, 3, 4 };
            int[] B3 = new int[] { 3, 3, 2, 4, 1, 2 };
            Console.WriteLine("Example 3");
            Console.WriteLine($"N = {N3}");
            Console.WriteLine($"A[] = [{string.Join(", ", A3)}]");
            Console.WriteLine($"B[] = [{string.Join(", ", B3)}]");
            Console.WriteLine($"Output: {AreArraysEqual(A3, B3, N3)}");
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