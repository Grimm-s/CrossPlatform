namespace LAB5_LIB
{
    public static class Lab2
    {
        public static string Run(string inputContent)
        {
            var dirtySectors = LoadDirtySectorsFromString(inputContent);
            var minCleaningDistance = CalculateMinimumCleaningDistance(dirtySectors);

            return minCleaningDistance.ToString();
        }

        private static int CalculateDistanceBetweenSectors(Sector a, Sector b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        private static int CalculateMinimumCleaningDistance(List<Sector> dirtySectors)
        {
            var currentSector = new Sector { X = 1, Y = 1 };
            var totalCleaningDistance = 0;

            while (dirtySectors.Any())
            {
                var closestDirtySector = dirtySectors.OrderBy(s => s.Y)
                                                     .ThenBy(s => CalculateDistanceBetweenSectors(currentSector, s))
                                                     .First();
                totalCleaningDistance += CalculateDistanceBetweenSectors(currentSector, closestDirtySector);
                currentSector = closestDirtySector;
                dirtySectors.Remove(closestDirtySector);
            }

            return totalCleaningDistance;
        }

        private static List<Sector> LoadDirtySectorsFromString(string inputContent)
        {
            var lines = inputContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var numberOfSectors = int.Parse(lines[0]);

            ValidateSectorCount(numberOfSectors, lines.Length - 1);

            return lines.Skip(1)
                        .Select(line => line.Split(' ')
                                             .Select(int.Parse)
                                             .ToArray())
                        .Select(parts => new Sector { X = parts[0], Y = parts[1] })
                        .ToList();
        }

        private static void ValidateSectorCount(int declaredCount, int actualCount)
        {
            if (declaredCount is < 1 or > 1000) throw new Exception("Error: n is out of range.");
            if (declaredCount != actualCount) throw new Exception("Error: the number of elements does not match the value of n.");
        }
    }

    public record Sector
    {
        public int X { get; init; }
        public int Y { get; init; }
    }
}
