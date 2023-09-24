static List<int> ReadIntegersFromFile(string fileName)
{
    List<int> integers = new List<int>();
    foreach (string line in File.ReadLines(fileName))
    {
        integers.Add(int.Parse(line));
    }
    return integers;
}

static Tuple<List<int>, long> CountSplitInv(List<int> B, List<int> C)
{
    int i = 0;
    int j = 0;
    long count = 0;
    List<int> D = new List<int>();

    while (i < B.Count && j < C.Count)
    {
        D.Add(Math.Min(B[i], C[j]));
        if (B[i] < C[j])
        {
            i++;
        }
        else
        {
            count += B.Count - i;
            j++;
        }
    }

    D.AddRange(B.Skip(i));
    D.AddRange(C.Skip(j));

    return Tuple.Create(D, count);
}

static Tuple<List<int>, long> SortCount(List<int> A)
{
    int n = A.Count;
    if (n > 1)
    {
        int splitPosition = n / 2;
        var B = A.Take(splitPosition).ToList();
        var C = A.Skip(splitPosition).ToList();
        var X = SortCount(B);
        var Y = SortCount(C);
        var Z = CountSplitInv(B, C);

        List<int> D = Z.Item1;
        long splitInversions = Z.Item2;

        return Tuple.Create(D, X.Item2 + Y.Item2 + splitInversions);
    }
    else
    {
        return Tuple.Create(A, (long)0);
    }
}



string fileName = "IntegerArrayyy.txt";
List<int> a = ReadIntegersFromFile(fileName);
var result = SortCount(a);
List<int> sortedArray = result.Item1;
long inversions = result.Item2;
Console.WriteLine("Sorted Array: [" + string.Join(", ", sortedArray) + "]");
Console.WriteLine("Number of Split Inversions: " + inversions);
