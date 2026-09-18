using System;

namespace NMLT.Buoi4
{
    public class HePhuongTrinh
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("Nhap 6 so thuc a, b, c, d, e, f:");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine()!);
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine()!);
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine()!);
            Console.Write("d = ");
            double d = double.Parse(Console.ReadLine()!);
            Console.Write("e = ");
            double e = double.Parse(Console.ReadLine()!);
            Console.Write("f = ");
            double f = double.Parse(Console.ReadLine()!);

            double det = a * e - b * d;

            if (Math.Abs(det) < 1e-10)
            {
                double delta1 = a * f - c * d;
                double delta2 = b * f - c * e;

                if (Math.Abs(delta1) < 1e-10 && Math.Abs(delta2) < 1e-10)
                {
                    Console.WriteLine("He phuong trinh co vo so nghiem.");
                }
                else
                {
                    Console.WriteLine("He phuong trinh vo nghiem.");
                }
            }
            else
            {
                double x = (c * e - b * f) / det;
                double y = (a * f - c * d) / det;

                Console.WriteLine($"Nghiem cua he la: x = {x}, y = {y}");
            }
        }
    }
}
