/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Input: nums = [2,7,11,15], target = 9

Output: [0,1]

Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
*/

namespace ChallengeLab_3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [2, 7, 11, 15];
            int target = 9;

            Console.WriteLine("Test with initial brute force solution.");
            int[] results = FindSolution(nums, target);
            Console.WriteLine($"Output: [{results[0]},{results[1]}]");
            Console.WriteLine($"Index {results[0]} ({nums[results[0]]}) and index {results[1]} ({nums[results[1]]}) add up to {target}.");

            // Test with hashmap
            Console.WriteLine("\nTest with efficient hashmap/dictionary solution.");
            results = FindSolution(nums, target, 1);
            Console.WriteLine($"Output: [{results[0]},{results[1]}]");
            Console.WriteLine($"Index {results[0]} ({nums[results[0]]}) and index {results[1]} ({nums[results[1]]}) add up to {target}.");
        }

        static int[] FindSolution(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)
                        return [i, j];
                }
            }

            return [-1, -1];
        }
        
        static int[] FindSolution(int[] array, int target, int unusedVariableToTestHashmap)
        {
            Dictionary<int, int> map = new();

            for (int i = 0; i < array.Length; i++)
            {
                int complement = target - array[i];
                if (map.ContainsKey(complement))
                    return [map[complement], i];

                if (!map.ContainsKey(i))
                    map[array[i]] = i;
            }
            
            return [-1, -1];
        }
    }
}
