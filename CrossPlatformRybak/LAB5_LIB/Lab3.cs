namespace LAB5_LIB
{
    public static class Lab3
    {
        private static readonly int[] Dx = { -1, 0, 1, 0 };
        private static readonly int[] Dy = { 0, 1, 0, -1 };

        public static string Run(string inputContent)
        {
            using var sr = new StringReader(inputContent);

            var garden = ParseGarden(sr, out var rowCount, out var colCount);
            var queen = ParseQueen(sr);
            var totalPendants = ComputeTotalPendants(sr, rowCount, colCount, garden, queen);

            return totalPendants.ToString();
        }

        private static int[][] ParseGarden(StringReader sr, out int rowCount, out int colCount)
        {
            var dimensions = sr.ReadLine().Split(' ');
            rowCount = int.Parse(dimensions[0]);
            colCount = int.Parse(dimensions[1]);
            var garden = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                garden[i] = Array.ConvertAll(sr.ReadLine().ToCharArray(), ch => ch - '0');
            }

            return garden;
        }

        private static (int x, int y, int p) ParseMusketeer(StringReader sr)
        {
            var parts = sr.ReadLine().Split(' ');
            return (int.Parse(parts[0]) - 1, int.Parse(parts[1]) - 1, int.Parse(parts[2]));
        }
        
        private static (int x, int y, int t) ParseQueen(StringReader sr)
        {
            var parts = sr.ReadLine().Split(' ');
            return (int.Parse(parts[0]) - 1, int.Parse(parts[1]) - 1, int.Parse(parts[2]));
        }

        private static int ComputeTotalPendants(StringReader sr, int rowCount, int colCount, int[][] garden, (int x, int y, int t) queen)
        {
            var musketeers = 4;
            var totalPendants = 0;

            for (int i = 0; i < musketeers; i++)
            {
                var musketeer = ParseMusketeer(sr);

                if (CalculateDeliveryTime(rowCount, colCount, garden, musketeer, queen) <= queen.t)
                {
                    totalPendants += musketeer.p;
                }
            }

            return totalPendants;
        }

        private static int CalculateDeliveryTime(int rowCount, int colCount, int[][] garden, (int x, int y, int p) start, (int x, int y, int d) end)
        {
            bool[][] visited = new bool[rowCount][];
            for (var i = 0; i < rowCount; i++)
            {
                visited[i] = new bool[colCount];
            }

            var queue = new Queue<(int x, int y, int depth)>();
            queue.Enqueue((start.x, start.y, 0));
            visited[start.x][start.y] = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.x == end.x && current.y == end.y)
                {
                    return current.depth;
                }

                for (int d = 0; d < 4; d++)
                {
                    var nx = current.x + Dx[d];
                    var ny = current.y + Dy[d];
                    if (!IsSafe(nx, ny, rowCount, colCount) || garden[nx][ny] != 0 || visited[nx][ny]) continue;
                    visited[nx][ny] = true;
                    queue.Enqueue((nx, ny, current.depth + 1));
                }
            }

            return int.MaxValue;
        }

        private static bool IsSafe(int x, int y, int rowCount, int colCount)
        {
            return x >= 0 && y >= 0 && x < rowCount && y < colCount;
        }
    }
}
