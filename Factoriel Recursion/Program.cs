//5 =5 * 4 * 3 * 2 * 1

static int f(int n)
{
    if (n == 0)
    {
        return 0;
    }
    if (n == 1)
    {
        return 1;
    }

    else
    {
        return n * f(n - 1);
    }
}

int n = int.Parse(Console.ReadLine());

Console.WriteLine($"Factoriel of {n} is:" + f(n));
