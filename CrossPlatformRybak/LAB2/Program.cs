public class Program
{
    private const string InputFilePath = "..//..//..//input.txt";
    private const string OutputFilePath = "..//..//..//output.txt";

    public static void Main()
    {
        if (!File.Exists(InputFilePath))
        {
            throw new Exception("Error: File input.txt not found.");
        }

        var dirtySectors = LoadDirtySectorsFromFilePath(InputFilePath);
        var minCleaningDistance = CalculateMinimumCleaningDistance(dirtySectors);
        
        WriteOutput(minCleaningDistance);
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

    private static List<Sector> LoadDirtySectorsFromFilePath(string filePath)
    {
        var fileLines = File.ReadAllLines(filePath);
        var numberOfSectors = int.Parse(fileLines[0]);

        ValidateSectorCount(numberOfSectors, fileLines.Length - 1);

        return fileLines.Skip(1)
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

    private static void WriteOutput(int result)
    {
        using var sw = new StreamWriter(OutputFilePath, false);
        sw.WriteLine(result);
    }
}

public record Sector
{
    public int X { get; init; }
    public int Y { get; init; }
}
