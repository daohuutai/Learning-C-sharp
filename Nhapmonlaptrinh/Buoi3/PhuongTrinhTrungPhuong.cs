using System;

namespace NMLT.Buoi03
{
    class PhuongTrinhTrungPhuong
    {
        public static void Main(string[] args)
        {
            double a, b, c;
            double delta, t1, t2;
            bool coNghiem = false;

            Console.Write("Moi ban nhap he so a, b, c: ");
            string[] input = Console.ReadLine().Split(' ');
            a = double.Parse(input[0]);
            b = double.Parse(input[1]);
            c = double.Parse(input[2]);

            delta = b * b - 4 * a * c;

            Console.Write("Phuong trinh trung phuong {0}x^4 + {1}x^2 + {2} = 0 co: ", a, b, c);

            if (delta < 0)
            {
                Console.WriteLine("vo nghiem.");
            }
            else
            {
                if (delta == 0)
                {
                    t1 = -b / (2 * a);
                    t2 = t1;
                }
                else
                {
                    t1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    t2 = (-b - Math.Sqrt(delta)) / (2 * a);
                }

                if (t1 >= 0)
                {
                    Console.Write("x = {0:#.00}, x = {1:#.00} ", Math.Sqrt(t1), -Math.Sqrt(t1));
                    coNghiem = true;
                }
                if (t2 >= 0 && t2 != t1)
                {
                    Console.Write("x = {0:#.00}, x = {1:#.00} ", Math.Sqrt(t2), -Math.Sqrt(t2));
                    coNghiem = true;
                }

                if (!coNghiem)
                {
                    Console.WriteLine("vo nghiem.");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            Console.Read();
        }
    }
}
