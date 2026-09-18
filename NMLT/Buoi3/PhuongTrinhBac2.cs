using System;

namespace NMLT.Buoi3
{
    class PhuongTrinhBac2
    {
        public static void ChayBaiTap()
        {
            double a, b, c;
            double delta, x1, x2;

            Console.Write("Moi ban nhap he so a, b, c: ");
            string[] input = Console.ReadLine().Split(' ');
            a = double.Parse(input[0]);
            b = double.Parse(input[1]);
            c = double.Parse(input[2]);

            Console.Write("Phuong trinh bac 2 {0}x^2 + {1}x + {2} = 0 co: ", a, b, c);

            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                        Console.WriteLine("vo so nghiem.");
                    else
                        Console.WriteLine("vo nghiem.");
                }
                else
                {
                    x1 = -c / b;
                    Console.WriteLine("1 nghiem, x = {0:#.00}.", x1);
                }
            }
            else
            {
                delta = b * b - 4 * a * c;
                if (delta < 0)
                {
                    Console.WriteLine("vo nghiem.");
                }
                else if (delta == 0)
                {
                    x1 = -b / (2 * a);
                    Console.WriteLine("nghiem kep, x = {0:#.00}.", x1);
                }
                else
                {
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("2 nghiem, x1 = {0:#.00}, x2 = {1:#.00}.", x1, x2);
                }
            }

            Console.Read();
        }
    }
}