using System;

namespace NMLT.Buoi7
{
    public class TinhSoPi
    {
        static double tinhPi(double epsilon, out double soHang)
        {
            double tong = 0;
            int n = 0;
            double hang;
            do
            {
                hang = 1.0 / (2 * n + 1);
                tong += (n % 2 == 0 ? 1 : -1) * hang;
                n++;
            } while (hang >= epsilon);

            soHang = hang;
            return tong * 4;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap do sai so epsilon: ");
            double epsilon = double.Parse(Console.ReadLine()!);

            double pi = tinhPi(epsilon, out _);
            double saiSoThucTe = Math.Abs(pi - Math.PI);

            Console.WriteLine($"So pi tinh den do chinh xac {epsilon} la {pi:F6}.");
            Console.WriteLine($"Do sai so thuc te la {saiSoThucTe:F6}.");
        }
    }
}
