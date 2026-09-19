using System;

namespace NMLT.Buoi8
{
    public class DemChuSo
    {
        // Ham don the: dem so lan xuat hien cua 1 chu so trong n
        static int demMotChuSo(int n, int chuSo)
        {
            int dem = 0;
            while (n > 0)
            {
                if (n % 10 == chuSo) dem++;
                n /= 10;
            }
            return dem;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int chuSo = 0; chuSo <= 9; chuSo++)
            {
                int soLan = demMotChuSo(n, chuSo);
                if (soLan > 0)
                    Console.WriteLine($"Chu so {chuSo} xuat hien {soLan} lan.");
            }
        }
    }
}
