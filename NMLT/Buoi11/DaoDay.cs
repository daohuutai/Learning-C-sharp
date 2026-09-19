using System;

namespace NMLT.Buoi11
{
    public class DaoDay
    {
        public static void ChayBaiTap()
        {
            int[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoNguyen();
            Console.WriteLine("* Mang truoc khi dao:");
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            for (int i = 0, j = day.Length - 1; i < j; i++, j--)
            {
                int tam = day[i];
                day[i] = day[j];
                day[j] = tam;
            }

            Console.WriteLine("* Mang sau khi dao:");
            NMLT.Buoi9.NhapXuatMang.inMang(day);
        }
    }
}
