using System;

namespace NMLT.Buoi4
{
    public class GiaTriHamSoDoThi
    {
        public static void ChayBaiTap()
        {
            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine()!);

            double f;

            if (a < 0)
            {
                f = -0.5;
            }
            else if (a <= 1)
            {
                f = a;
            }
            else if (a <= 1.5)
            {
                f = 3 - 2 * a;
            }
            else
            {
                f = 0;
            }

            Console.WriteLine($"f({a}) = {f:F2}");
        }
    }
}
