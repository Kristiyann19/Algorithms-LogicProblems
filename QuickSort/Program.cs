static int FindMedian(int[] A)
{
    int minValue = A.Min();
    int maxValue = A.Max();

    for (int i = 0; i < 3; i++)
    {
        if (A[i] != minValue && A[i] != maxValue)
        {
            return A[i];
        }
    }
    return -1; // Handle the case where the median is not found
}

static int ChoosePivot(int[] A, int flag)
{
    int n = A.Length;
    int first = A[0];
    int final = A[n - 1];

    int k;
    int middle;

    if (n % 2 == 0)
    {
        k = n / 2 - 1;
        middle = A[k];
    }
    else
    {
        k = n / 2;
        middle = A[k];
    }

    int[] B = { first, middle, final };
    int med = FindMedian(B);
    int position;

    if (med == B[0])
    {
        position = 0;
    }
    else if (med == B[1])
    {
        position = k;
    }
    else
    {
        position = n - 1;
    }

    if (flag == 1)
    {
        return 0;
    }
    if (flag == 2)
    {
        return n - 1;
    }
    if (flag == 3)
    {
        return position;
    }
    else
    {
        throw new ArgumentException("Wrong flag");
    }
}

static void Swap(int[] A, int first, int second)
{
    int secondValue = A[second];
    int firstValue = A[first];
    A[first] = secondValue;
    A[second] = firstValue;
}

static int Partition(int[] A)
{
    int pivot = A[0];
    int r = A.Length;
    int i = 1;

    for (int j = 1; j < r; j++)
    {
        if (A[j] < pivot)
        {
            Swap(A, i, j);
            i++;
        }
    }

    Swap(A, 0, i - 1);
    return i - 1;
}

static void QuickSort(int[] A, int flag)
{
    int n = A.Length;

    if (n > 1)
    {
        int p = ChoosePivot(A, flag);
        Swap(A, 0, p);
        int pivotPosition = Partition(A);
        QuickSort(A.Take(pivotPosition).ToArray(), flag);
        QuickSort(A.Skip(pivotPosition + 1).ToArray(), flag);
    }
}

int[] a = File.ReadAllLines("QuickSortt.txt").Select(int.Parse).ToArray();
QuickSort(a, 3); // Change the flag to 1, 2, or 3 as needed
Console.WriteLine(string.Join(" ", a));