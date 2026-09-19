using System;

namespace NMLT.Buoi7
{
    public class NgayTruoc
    {
        static bool laNamNhuan(int nam)
        {
            return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
        }

        static int soNgayCuaThang(int thang, int nam)
        {
            int[] soNgay = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (thang == 2 && laNamNhuan(nam)) return 29;
            return soNgay[thang - 1];
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap ngay: ");
            int ngay = int.Parse(Console.ReadLine()!);
            Console.Write("Moi ban nhap thang: ");
            int thang = int.Parse(Console.ReadLine()!);
            Console.Write("Moi ban nhap nam: ");
            int nam = int.Parse(Console.ReadLine()!);

            int ngayGoc = ngay, thangGoc = thang, namGoc = nam;

            ngay--;
            if (ngay == 0)
            {
                thang--;
                if (thang == 0)
                {
                    thang = 12;
                    nam--;
                }
                ngay = soNgayCuaThang(thang, nam);
            }

            Console.WriteLine($"Ngay truoc ngay {ngayGoc}/{thangGoc}/{namGoc} la ngay {ngay}/{thang}/{nam}.");
        }
    }
}
