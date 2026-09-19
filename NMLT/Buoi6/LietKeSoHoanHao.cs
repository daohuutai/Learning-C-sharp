using System;

namespace NMLT.Buoi6
{
    public class LietKeSoHoanHao
    {
        static bool laSoHoanHao(int n)
        {
            int tong = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) tong += i;
            }
            return tong == n && n > 0;
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
