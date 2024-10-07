//Minimum String Length After Removing Substrings

//You are given a string s consisting only of uppercase English letters.

//You can apply some operations to this string where, in one operation, you can remove any occurrence of one of the substrings "AB" or "CD" from s.

//Return the minimum possible length of the resulting string that you can obtain.

//Note that the string concatenates after removing the substring and could produce new "AB" or "CD" substrings.

 

//Example 1:

//Input: s = "ABFCACDB"
//Output: 2
//Explanation: We can do the following operations:
//- Remove the substring "ABFCACDB", so s = "FCACDB".
//- Remove the substring "FCACDB", so s = "FCAB".
//- Remove the substring "FCAB", so s = "FC".
//So the resulting length of the string is 2.
//It can be shown that it is the minimum length that we can obtain.
//Example 2:

//Input: s = "ACBBD"
//Output: 5
//Explanation: We cannot do any operations on the string so the length remains the same.
 

//Constraints:

//1 <= s.length <= 100
//s consists only of uppercase English letters.

namespace MinimumStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMinimum String Length After Removing Substrings");
                Console.WriteLine("\nRules:");
                Console.WriteLine("1. String should contain only uppercase English letters");
                Console.WriteLine("2. Substrings 'AB' or 'CD' can be removed in each operation");
                Console.WriteLine("3. After removal, string concatenates and may form new 'AB' or 'CD'");

                Console.Write("\nEnter the string: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                    break;

                if (!IsValidInput(input))
                {
                    Console.WriteLine("Error: String must contain only uppercase English letters!");
                    continue;
                }

                int result = MinLength(input);
                Console.WriteLine($"\nInput string: {input}");
                Console.WriteLine($"Minimum possible length: {result}");

                Console.Write("\nWould you like to run test cases? (yes/no): ");
                string runTests = Console.ReadLine().ToLower();
                if (runTests == "yes" || runTests == "y")
                {
                    RunTestCases();
                }
            }
        }

        static int MinLength(string s)
        {
            bool madeChange;
            do
            {
                madeChange = false;

                int indexAB = s.IndexOf("AB");
                if (indexAB != -1)
                {
                    s = s.Remove(indexAB, 2);
                    madeChange = true;
                    continue;
                }

                int indexCD = s.IndexOf("CD");
                if (indexCD != -1)
                {
                    s = s.Remove(indexCD, 2);
                    madeChange = true;
                }

            } while (madeChange);

            return s.Length;
        }

        static bool IsValidInput(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length > 100)
                return false;

            foreach (char c in s)
            {
                if (c < 'A' || c > 'Z')
                    return false;
            }
            return true;
        }

        static void RunTestCases()
        {
            Console.WriteLine("\nRunning Test Cases\n");

            string test1 = "ABFCACDB";
            Console.WriteLine($"Test Case 1:");
            Console.WriteLine($"Input: s = \"{test1}\"");
            Console.WriteLine($"Output: {MinLength(test1)}");
            Console.WriteLine("Expected: 2");
            Console.WriteLine("Explanation: ABFCACDB -> FCACDB -> FCAB -> FC");

            string test2 = "ACBBD";
            Console.WriteLine($"\nTest Case 2:");
            Console.WriteLine($"Input: s = \"{test2}\"");
            Console.WriteLine($"Output: {MinLength(test2)}");
            Console.WriteLine("Expected: 5");
            Console.WriteLine("Explanation: No operations possible");

            string test3 = "ABCDABCD";
            Console.WriteLine($"\nTest Case 3:");
            Console.WriteLine($"Input: s = \"{test3}\"");
            Console.WriteLine($"Output: {MinLength(test3)}");
            Console.WriteLine("Expected: 0");
            Console.WriteLine("Explanation: ABCDABCD -> CDABCD -> ABCD -> CD -> empty string");
        }
    }
}