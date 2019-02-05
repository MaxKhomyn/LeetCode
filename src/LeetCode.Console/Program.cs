using LeetCode.Console.Models;

namespace LeetCode.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var answear = solution.FindMedianSortedArrays(new int[2] { 1, 2 }, new int[2] { 3, 4 });
        }
    }
}