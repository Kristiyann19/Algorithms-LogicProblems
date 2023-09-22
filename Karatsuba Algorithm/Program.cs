using System;
using System.Numerics;

class Program
{
    static BigInteger Karatsuba(BigInteger x, BigInteger y)
    {
        string aS = x.ToString();
        string bS = y.ToString();

        if (x < 10 || y < 10)
        {
            return x * y;
        }

        int maxLength = Math.Max(aS.Length, bS.Length);
        int splitLength = maxLength / 2;

        // Split strings
        BigInteger a = BigInteger.Parse(aS.Substring(0, aS.Length - splitLength));
        BigInteger b = BigInteger.Parse(aS.Substring(aS.Length - splitLength));
        BigInteger c = BigInteger.Parse(bS.Substring(0, bS.Length - splitLength));
        BigInteger d = BigInteger.Parse(bS.Substring(bS.Length - splitLength));

        BigInteger z0 = Karatsuba(a, c);
        BigInteger z1 = Karatsuba(a + b, c + d);
        BigInteger z2 = Karatsuba(b, d);

        return (z0 * BigInteger.Pow(10, 2 * splitLength)) + ((z1 - z0 - z2) * BigInteger.Pow(10, splitLength)) + z2;
    }

    static void Main(string[] args)
    {
        BigInteger a = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
        BigInteger b = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");

        Console.WriteLine(Karatsuba(a, b));
    }
}