using System;

namespace NMLT.Buoi4
{
    public class PhuongTrinhBac3
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("Nhap cac he so a, b, c, d cua phuong trinh bậc 3");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine()!);

            if (Math.Abs(a) < 1e-12)
            {
                Console.WriteLine("He so a phai khac 0.");
                return;
            }

            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine()!);
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine()!);
            Console.Write("d = ");
            double d = double.Parse(Console.ReadLine()!);

            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
            double delta = (q / 2.0) * (q / 2.0) + (p / 3.0) * (p / 3.0) * (p / 3.0);
            double x0 = -b / (3 * a);

            Console.WriteLine("\nPhuong trinh can giai: ");
            Console.WriteLine($"{a}x^3 + {b}x^2 + {c}x + {d} = 0");
            Console.WriteLine("\nBien luan nghiem:");

            if (Math.Abs(delta) < 1e-10)
            {
                if (Math.Abs(p) < 1e-10 && Math.Abs(q) < 1e-10)
                {
                    Console.WriteLine("Phuong trinh co mot nghiem kep ba:");
                    Console.WriteLine($"x = {x0:F4}");
                }
                else
                {
                    double u = Math.Cbrt(-q / 2.0);
                    double x1 = 2 * u + x0;
                    double x2 = -u + x0;

                    Console.WriteLine("Phuong trinh co 3 nghiem thuc, trong do co 2 nghiem bang nhau:");
                    Console.WriteLine($"x1 = {x1:F4}");
                    Console.WriteLine($"x2 = {x2:F4}");
                    Console.WriteLine($"x3 = {x2:F4}");
                }
            }
            else if (delta > 0)
            {
                double u = Math.Cbrt(-q / 2.0 + Math.Sqrt(delta));
                double v = Math.Cbrt(-q / 2.0 - Math.Sqrt(delta));
                double x = u + v + x0;

                Console.WriteLine("Phuong trinh co mot nghiem thuc duy nhat:");
                Console.WriteLine($"x = {x:F4}");
            }
            else
            {
                double r = 2 * Math.Sqrt(-p / 3.0);
                double theta = Math.Acos((3 * q / (2 * p)) * Math.Sqrt(-3.0 / p)) / 3.0;

                double x1 = r * Math.Cos(theta) + x0;
                double x2 = r * Math.Cos(theta - 2 * Math.PI / 3) + x0;
                double x3 = r * Math.Cos(theta - 4 * Math.PI / 3) + x0;

                Console.WriteLine("Phuong trinh co 3 nghiem thuc phan biet:");
                Console.WriteLine($"x1 = {x1:F4}");
                Console.WriteLine($"x2 = {x2:F4}");
                Console.WriteLine($"x3 = {x3:F4}");
            }
        }
    }
}
