using System;

namespace NMLT.Buoi03
{
    class GiaTriHamSo1
    {
        public static void Main(string[] args)
        {
            double x, f1, f2;

            Console.Write("Moi ban nhap so thuc x: ");
            x = double.Parse(Console.ReadLine());

            if (x <= 0)
            {
                f1 = 0;
            }
            else if (x <= 1)
            {
                f1 = x;
            }
            else
            {
                f1 = Math.Pow(x, 4);
            }

            if (x <= 2)
            {
                f2 = x * x + 4 * x + 5;
            }
            else
            {
                f2 = 1.0 / (x * x + 4 * x + 5);
            }

            Console.WriteLine("f1({0}) = {1:#.00}.", x, f1);
            Console.WriteLine("f2({0}) = {1:#.00}.", x, f2);

            Console.Read();
        }
    }
}