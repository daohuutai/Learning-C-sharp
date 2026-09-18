/*
Một thiết bị hoạt động được h giờ, m phút và s giây. Hãy viết chương trình chuyển thời gian đó
sang tổng số giây.
*/

using System;

namespace NMLT.Buoi1
{
    public class DoiSangGiay
    {
        public static void ChayBaiTap()
        {
            int h, m, s, kq;

            Console.Write("Nhap so gio: ");
            h = int.Parse(Console.ReadLine());

            Console.Write("Nhap so phut: ");
            m = int.Parse(Console.ReadLine());

            Console.Write("Nhap so giay: ");
            s = int.Parse(Console.ReadLine());

            kq = h * 3600 + m * 60 + s;

            // In đúng định dạng bạn yêu cầu
            Console.WriteLine($"Tong so giay cua {h}:{m}:{s} la {kq} giay");
            
            Console.Read();
        }
    }
}