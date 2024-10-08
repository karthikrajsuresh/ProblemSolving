//Find All Five Product Numbers
//Given an array of integers and another number. Find all the unique quintuplicate from the given array that products up to the given number.
//Example 1:
//Input:
//N = 12, K = 45000
//A[] = {2,5,4,50,7,30,8,50,25,6,15,3}
//Output: 2 5 6 15 50 $ 3 4 5 25 30 $ 3 5 8 15 25
//Explanation: Product of 2, 5, 6, 15, 50 is equal to K.
//Example 2:
//Input:
//N = 10, K = 120
//A[] = {2,5,9,4,10,8,12,1,6,3}
//Output: 1 2 3 4 5
//Explanation: Product of 1, 2, 3, 4, 5 is equal to K.
//Constraints:
//1 <= N <= 100
//120 <= K <= 100000
//1 <= A[] <= 100

namespace FiveProductNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find All Five Product Numbers\n");

            Console.WriteLine("Example 1:");
            int N1 = 12;
            int K1 = 45000;
            int[] A1 = { 2, 5, 4, 50, 7, 30, 8, 50, 25, 6, 15, 3 };
            Console.WriteLine($"N = {N1}, K = {K1}");
            Console.WriteLine($"A = {string.Join(", ", A1)}");
            FindFiveProducts(N1, K1, A1);
            Console.WriteLine();

            Console.WriteLine("Example 2:");
            int N2 = 10;
            int K2 = 120;
            int[] A2 = { 2, 5, 9, 4, 10, 8, 12, 1, 6, 3 };
            Console.WriteLine($"N = {N2}, K = {K2}");
            Console.WriteLine($"A = {string.Join(", ", A2)}");
            FindFiveProducts(N2, K2, A2);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("\nExample 3 - Enter your own values:");

                Console.Write("Enter N (array size, 1-100): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

                if (!int.TryParse(input, out int N3) || N3 < 1 || N3 > 100)
                {
                    Console.WriteLine("Invalid N value, Enter a number between 1 and 100.");
                    continue;
                }

                Console.Write("Enter K (target product, 120-100000): ");
                if (!int.TryParse(Console.ReadLine(), out int K3) || K3 < 120 || K3 > 100000)
                {
                    Console.WriteLine("Invalid K! Enter a number between 120 and 100000.");
                    continue;
                }

                Console.WriteLine($"Enter {N3} numbers 1-100 separated by spaces:");
                string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length != N3)
                {
                    Console.WriteLine($"Error: Enter exactly {N3} numbers!");
                    continue;
                }

                int[] A3 = new int[N3];
                bool validInput = true;

                for (int v = 0; v < N3; v++)
                {
                    if (!int.TryParse(elements[v], out A3[v]) || A3[v] < 1 || A3[v] > 100)
                    {
                        Console.WriteLine("Invalid array element. Each number must be between 1 and 100.");
                        validInput = false;
                        break;
                    }
                }

                if (!validInput)
                    continue;

                Console.WriteLine("\nYour Input:");
                Console.WriteLine($"N = {N3}, K = {K3}");
                Console.WriteLine($"A = {string.Join(", ", A3)}");
                FindFiveProducts(N3, K3, A3);
            }
        }

        static void FindFiveProducts(int N, int K, int[] A)
        {
            var result = new SortedSet<string>();

            for (int v = 0; v < N - 4; v++)
            {
                for (int w = v + 1; w < N - 3; w++)
                {
                    for (int x = w + 1; x < N - 2; x++)
                    {
                        for (int y = x + 1; y < N - 1; y++)
                        {
                            for (int z = y + 1; z < N; z++)
                            {
                                if ((long)A[v] * A[w] * A[x] * A[y] * A[z] == K)
                                {
                                    int[] combo = new int[] { A[v], A[w], A[x], A[y], A[z] };
                                    Array.Sort(combo);
                                    result.Add(string.Join(" ", combo));
                                }
                            }
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine("Output: -1");
                Console.WriteLine("Explanation: No combinations found.");
            }
            else
            {
                Console.WriteLine("Output: " + string.Join(" $ ", result));
                Console.WriteLine("Explanation: Found " + result.Count + " combinations that multiply to " + K);
            }
        }
    }
}