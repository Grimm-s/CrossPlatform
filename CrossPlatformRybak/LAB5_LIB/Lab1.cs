namespace LAB5_LIB
{
    public static class Lab1
    {
        public static string Run(string inputContent)
        {
            using var sr = new StringReader(inputContent);
            var n = ReadIntValue(sr);

            if (n is < 1 or > 105)
            {
                return "Error: n is out of range.";
            }

            var a = ReadIntArray(sr);
            var b = ReadIntArray(sr);

            var validationMessage = ValidateArrays(a, b, n);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                return validationMessage;
            }

            var result = ProcessValues(a, b, n);

            return result;
        }

        private static int ReadIntValue(StringReader sr) => int.Parse(sr.ReadLine());

        private static int[] ReadIntArray(StringReader sr) => sr.ReadLine().Split().Select(int.Parse).ToArray();

        private static string ValidateArrays(int[] a, int[] b, int n)
        {
            if (a.Any(ai => ai < 1) || b.Any(bi => bi > 109))
            {
                return "Error: a or b values are out of range.";
            }

            if (a.Length != n || b.Length != n)
            {
                return "Error: the number of elements in a or b does not match the value of n.";
            }

            return null;
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
    }
}
