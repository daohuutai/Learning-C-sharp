using System;

namespace NMLT.Buoi7
{
    public class KiemTraSoHoanHao
    {
        // Ham don the: tinh tong cac uoc so cua n (khong tinh chinh no)
        static int tongUocSo(int n)
        {
            int tong = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) tong += i;
            }
            return tong;
        }

        // Ham don the: kiem tra so hoan hao dua tren ham tongUocSo
        static bool laSoHoanHao(int n)
        {
            return tongUocSo(n) == n;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            if (laSoHoanHao(n))
                Console.WriteLine($"{n} = {tongUocSo(n)} (tong cac uoc) la so hoan hao.");
            else
                Console.WriteLine($"{n} khong la so hoan hao.");
        }
    }
}
