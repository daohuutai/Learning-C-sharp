using System;

namespace NMLT.Buoi5
{
    public class GiaTriBieuThuc
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine()!);

            // S1 = 1/1 + 1/2 + ... + 1/n
            double s1 = 0;
            for (int i = 1; i <= n; i++)
            {
                s1 += 1.0 / i;
            }

            // S2 = 1/n - 1/(n-1) + 1/(n-2) - ... + (-1)^(n+1) * 1/1
            double s2 = 0;
            int dau = 1;
            for (int i = n; i >= 1; i--)
            {
                s2 += dau * (1.0 / i);
                dau = -dau;
            }

            Console.WriteLine($"S1(n={n}) = {s1:F4}.");
            Console.WriteLine($"S2(n={n}) = {s2:F4}.");
        }
    }
}
