using System;

namespace NMLT.Buoi8
{
    public class LietKeSoHoanHao
    {
        // Ham don the: tinh tong cac uoc so cua n
        static int tongUocSo(int n)
        {
            int tong = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) tong += i;
            }
            return tong;
        }

        // Ham don the: kiem tra so hoan hao, dung lai ham tongUocSo
        static bool laSoHoanHao(int n)
        {
            return n > 0 && tongUocSo(n) == n;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so n: ");
            int n = int.Parse(Console.ReadLine()!);

            string ketQua = "";
            for (int i = n; i >= 1; i--)
            {
                if (laSoHoanHao(i))
                    ketQua += (ketQua == "" ? "" : ", ") + i;
            }

            Console.WriteLine($"Cac so hoan hao trong doan [1, {n}]: {ketQua}");
        }
    }
}
