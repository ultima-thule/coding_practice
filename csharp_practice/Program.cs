using csharp_practice;
class Program
{
    public static void Main(string[] args)
    {
        //var result = LT1480.RunningSum(new int[] { 1, 2, 3, 4, 5 });
        //var result = LT724.PivotIndex(new int[] { 1, 2, 3, 4, 5 });
        var result = LT217.ContainsDuplicate(new int[] { 1, 2, 3, 4, 5 });

        Console.WriteLine($"Result: {result}");
        Console.ReadKey();
    }
}