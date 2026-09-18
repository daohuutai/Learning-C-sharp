using System;

namespace NMLT.Buoi4
{
    public class NgaySau
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("Nhap ngay: ");
            int ngay = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap thang: ");
            int thang = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap nam: ");
            int nam = int.Parse(Console.ReadLine()!);
            int ngaySau = ngay + 1;
            if (thang == 2)
            {
                if (nam % 4 == 0 && nam % 100 != 0 || nam % 400 == 0)
                {
                    if (ngaySau > 29)
                    {
                        ngaySau = 1;
                        thang++;
                    }
                }
                else
                {
                    if (ngaySau > 28)
                    {
                        ngaySau = 1;
                        thang++;
                    }
                }
            }
            else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                if (ngaySau > 30)
                {
                    ngaySau = 1;
                    thang++;
                }
            }
            else
            {
                if (ngaySau > 31)
                {
                    ngaySau = 1;
                    thang++;
                }
            }
            if (thang > 12)
            {
                thang = 1;
                nam++;
            }
            Console.WriteLine($"Ngay sau la: {ngaySau}/{thang}/{nam}");
        }
    }
}