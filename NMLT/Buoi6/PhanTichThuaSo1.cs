using System;
using System.Text;

namespace NMLT.Buoi6
{
    public class PhanTichThuaSo1
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so nguyen n: ");
            long n = long.Parse(Console.ReadLine()!);
            long soGoc = n;

            StringBuilder ketQua = new StringBuilder();
            for (long p = 2; p * p <= n; p++)
            {
                if (n % p == 0)
                {
                    int soMu = 0;
                    while (n % p == 0)
                    {
                        n /= p;
                        soMu++;
                    }
                    if (ketQua.Length > 0) ketQua.Append(" x ");
                    ketQua.Append(soMu > 1 ? $"{p}^{soMu}" : $"{p}");
                }
            }
            if (n > 1)
            {
                if (ketQua.Length > 0) ketQua.Append(" x ");
                ketQua.Append(n);
            }

            Console.WriteLine($"{soGoc} = {ketQua}");
        }
    }
}
