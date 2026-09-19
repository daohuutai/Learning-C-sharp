using System;

namespace NMLT.Buoi9
{
    public class LietKeChan
    {
        public static void ChayBaiTap()
        {
            int[] day = NhapXuatMang.nhapMangSoNguyen();

            Console.Write("Cac phan tu chan trong mang:");
            for (int i = day.Length - 1; i >= 0; i--)
            {
                if (day[i] % 2 == 0) Console.Write($" {day[i]}");
            }
            Console.WriteLine();
        }
    }
}
