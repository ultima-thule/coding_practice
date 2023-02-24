namespace csharp_practice
{
	internal class LT724
	{
		public static int PivotIndex(int[] nums)
		{
			int maxIndex = nums.Length - 1;
			int sumLeftInc = nums[0];
			int sumRightInc = nums[maxIndex];

			for (int i = 1; i <= maxIndex; i++)
			{
				sumLeftInc += nums[i];
				sumRightInc += nums[maxIndex - i];
				if (sumLeftInc == sumRightInc)
				{
					return i;
				}
			}
			return -1;
		}
	}
}