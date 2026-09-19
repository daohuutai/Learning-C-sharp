using System;

namespace NMLT.Buoi8
{
    public class GiaiThua
    {
        // Ham don the: tinh giai thua
        static long giaiThua(int x)
        {
            long ketQua = 1;
            for (int i = 2; i <= x; i++) ketQua *= i;
            return ketQua;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap k: ");
            int k = int.Parse(Console.ReadLine()!);
            Console.Write("Moi ban nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            long ketQua = giaiThua(n) / (giaiThua(k) * giaiThua(n - k));
            Console.WriteLine($"C({k}, {n}) = {ketQua}.");
        }
    }
}
