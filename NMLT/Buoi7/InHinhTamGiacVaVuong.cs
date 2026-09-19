using System;

namespace NMLT.Buoi7
{
    public class InHinhTamGiacVaVuong
    {
        static void inTamGiac(int h)
        {
            for (int dong = 1; dong <= h; dong++)
            {
                Console.Write(new string(' ', (h - dong) * 2));
                Console.Write("*");
                if (dong > 1)
                {
                    Console.Write(new string(' ', (dong - 1) * 2 - 1));
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void inDayNgang(int h)
        {
            Console.WriteLine(string.Concat(System.Linq.Enumerable.Repeat("* ", h * 2 - 1)).TrimEnd());
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap chieu cao h: ");
            int h = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"h={h}");
            inTamGiac(h);
            inDayNgang(h);
        }
    }
}
