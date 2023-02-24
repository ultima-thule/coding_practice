namespace csharp_practice
{
    internal class LT217
    {
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            return set.Count != nums.Length;
        }
    }
}
