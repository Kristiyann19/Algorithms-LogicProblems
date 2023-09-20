//for 5 is 0 1 1 2 3
static int fib(int n)
{
    if (n == 0)
    {
        return 0;
    }
    else if (n == 1 || n == 2)
    {
        return 1;
    }
    else
    {
        return fib(n - 1) + fib(n - 2);
    }
}

int n = int.Parse(Console.ReadLine());

Console.WriteLine($"Fibonacci series of {n} numbers is:");

for (int i = 0; i < n; i++)
{
    Console.WriteLine(fib(i));
}