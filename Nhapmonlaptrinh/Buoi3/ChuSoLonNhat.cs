using System;

namespace NMLT.Buoi03
{
    class ChuSoLonNhat
    {
        public static void Main(string[] args)
        {
            int n;
            int c1, c2, c3, c4;
            int cmax;

            Console.Write("Moi ban nhap so tu nhien n co 4 chu so: ");
            n = int.Parse(Console.ReadLine());

            c1 = n / 1000;
            c2 = (n / 100) % 10;
            c3 = (n / 10) % 10;
            c4 = n % 10;

            cmax = c1;
            if (c2 > cmax) cmax = c2;
            if (c3 > cmax) cmax = c3;
            if (c4 > cmax) cmax = c4;

            Console.WriteLine("Chu so lon nhat cua {0} la {1}.", n, cmax);

            Console.Read();
        }
    }
}
