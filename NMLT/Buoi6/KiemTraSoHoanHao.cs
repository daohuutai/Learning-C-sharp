using System;

namespace NMLT.Buoi6
{
    public class KiemTraSoHoanHao
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            int tong = 0;
            string cacUoc = "";
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    tong += i;
                    cacUoc += (cacUoc == "" ? "" : " + ") + i;
                }
            }

            if (tong == n)
                Console.WriteLine($"{n} = {cacUoc} la so hoan hao.");
            else
                Console.WriteLine($"{n} khong la so hoan hao.");
        }
    }
}
