using System;

namespace NMLT.Buoi5
{
    public class TimBeNhatThoa
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine()!);

            double tong = 0;
            int n = 0;
            while (tong <= a)
            {
                n++;
                tong += 1.0 / n;
            }

            Console.WriteLine($"So nguyen duong n be nhat de 1 + 1/2 + ... + 1/n > {a} la n = {n}.");
            Console.WriteLine($"(Tong tai n = {n} la {tong:F4})");
        }
    }
}
