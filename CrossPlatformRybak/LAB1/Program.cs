class Program
{
    private const string InputFilePath = "..//..//..//input.txt";
    private const string OutputFilePath = "..//..//..//output.txt";

    static void Main()
    {
        if (!File.Exists(InputFilePath))
        {
            Console.WriteLine("File input.txt not found.");
            return;
        }

        using var sr = new StreamReader(InputFilePath);
        var n = ReadIntValue(sr);

        if (n is < 1 or > 105)
        {
            Console.WriteLine("Error: n is out of range.");
            return;
        }

        var a = ReadIntArray(sr);
        var b = ReadIntArray(sr);

        ValidateArrays(a, b, n);

        var result = ProcessValues(a, b, n);

        WriteOutput(result);
    }

    private static int ReadIntValue(StreamReader sr) => int.Parse(sr.ReadLine());

    private static int[] ReadIntArray(StreamReader sr) => sr.ReadLine().Split().Select(int.Parse).ToArray();

    private static void ValidateArrays(int[] a, int[] b, int n)
    {
        if (a.Any(ai => ai < 1) || b.Any(bi => bi > 109))
        {
            Console.WriteLine("Error: a or b values are out of range.");
            Environment.Exit(0);
        }

        if (a.Length != n || b.Length != n)
        {
            Console.WriteLine("Error: the number of elements in a or b does not match the value of n.");
            Environment.Exit(0);
        }
    }

    private static string ProcessValues(int[] a, int[] b, int n)
    {
        var aSum = a.Sum();
        var order = new List<int>();

        var passed = false;
        while (order.Count < n)
        {
            passed = false;
            for (var i = 0; i < n; i++)
            {
                if (order.Contains(i + 1) || b[i] <= aSum - a[i]) continue;

                order.Add(i + 1);
                aSum -= a[i];
                passed = true;
                break;
            }

            if (!passed)
                break;
        }

        return passed ? string.Join(" ", order) : "-1";
    }

    private static void WriteOutput(string result)
    {
        using var sw = new StreamWriter(OutputFilePath, false);
        sw.WriteLine(result);
    }
}
