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

namespace ArrayEqualityChecker1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nArray Equality Checker");
                Console.WriteLine("The input format of the elements for arrays is space separated");
                Console.WriteLine($"Example format: 1 2 3 4 5");

                int N;
                while (true)
                {
                    Console.Write("\nEnter the size N of the arrays: ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                        return;

                    if (int.TryParse(input, out N) && N > 0)
                        break;
                    Console.WriteLine("Please enter a valid positive integer for N.");
                }

                int[] A;
                Console.WriteLine($"\nEnter {N} elements for array A:");
                if (!InputArray("A", N, out A))
                    return;

                int[] B;
                Console.WriteLine($"\nEnter {N} elements for array B:");
                if (!InputArray("B", N, out B))
                    return;

                Console.WriteLine("\nInput Summary:");
                Console.WriteLine($"N = {N}");
                Console.WriteLine($"A[] = [{string.Join(", ", A)}]");
                Console.WriteLine($"B[] = [{string.Join(", ", B)}]");

                int result = AreArraysEqual(A, B, N);
                Console.WriteLine($"\nResult: {result}");
                Console.WriteLine(result == 1
                    ? "The arrays are equal."
                    : "The arrays are not equal.");

                Console.Write("\nDo you want to check another pair of arrays? (yes/no): ");
                string continue_input = Console.ReadLine().ToLower();
                if (continue_input != "yes" && continue_input != "y")
                    break;
            }
        }

        static bool InputArray(string arrayName, int N, out int[] arr)
        {
            arr = null;
            while (true)
            {
                Console.Write($"Enter elements for array {arrayName}: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    return false;

                try
                {
                    arr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

                    if (arr.Length != N)
                    {
                        Console.WriteLine($"Enter exactly {N} elements.");
                        continue;
                    }
                    return true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid integers separated by spaces.");
                }
            }
        }

        static int AreArraysEqual(int[] A, int[] B, int N)
        {
            if (A.Length != N || B.Length != N)
            {
                return 0;
            }

            Dictionary<int, int> CountA = new Dictionary<int, int>();
            Dictionary<int, int> CountB = new Dictionary<int, int>();

            foreach (int num in A)
            {
                if (!CountA.ContainsKey(num))
                    CountA[num] = 0;
                CountA[num]++;
            }

            foreach (int num in B)
            {
                if (!CountB.ContainsKey(num))
                    CountB[num] = 0;
                CountB[num]++;
            }

            if (CountA.Count != CountB.Count)
                return 0;

            foreach (var kvp in CountA)
            {
                int key = kvp.Key;
                if (!CountB.ContainsKey(key) || CountB[key] != CountA[key])
                    return 0;
            }

            return 1;
        }
    }
}


