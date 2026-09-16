using System;

namespace NMLT.Buoi03
{
    class GiaTriHamSo2
    {
        public static void Main(string[] args)
        {
            double a, fa;

            Console.Write("Moi ban nhap so thuc a: ");
            a = double.Parse(Console.ReadLine());

            if (a <= 0.5)
            {
                fa = -0.5;
            }
            else if (a < 1.5)
            {
                fa = 1.5 * a - 1.25;
            }
            else
            {
                fa = 1;
            }

            Console.WriteLine("f({0}) = {1:#.00}.", a, fa);

            Console.Read();
        }
    }
}
