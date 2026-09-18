using System;

namespace NMLT.Buoi3
{
    class MaxMin5So
    {
        public static void ChayBaiTap()
        {
            int a, b, c, d, e;
            int vmax, vmin;

            Console.Write("Moi ban nhap 5 so a, b, c, d ,e: ");
            string[] input = Console.ReadLine().Split(' ');
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);
            c = int.Parse(input[2]);
            d = int.Parse(input[3]);
            e = int.Parse(input[4]);

            vmax = a;
            if (b > vmax) vmax = b;
            if (c > vmax) vmax = c;
            if (d > vmax) vmax = d;
            if (e > vmax) vmax = e;

            vmin = a;
            if (b < vmin) vmin = b;
            if (c < vmin) vmin = c;
            if (d < vmin) vmin = d;
            if (e < vmin) vmin = e;

            Console.WriteLine("Gia tri lon nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, vmax);
            Console.WriteLine("Gia tri nho nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, vmin);

            Console.Read();
        }
    }
}