using csharp_practice;
class Program
{
    public static void Main(string[] args)
    {
        //var result = LT1480.RunningSum(new int[] { 1, 2, 3, 4, 5 });
        //var result = LT724.PivotIndex(new int[] { 1, 2, 3, 4, 5 });
        //var result = LT217.ContainsDuplicate(new int[] { 1, 2, 3, 4, 5 });
        //UD_40_Refactor calculator = new UD_40_Refactor();
        //calculator.Calculate();

        //Console.WriteLine($"Result: {result}");

        Singleton sin = Singleton.Instance;
        Singleton sin2 = Singleton.Instance;

        Console.ReadKey();
    }
}