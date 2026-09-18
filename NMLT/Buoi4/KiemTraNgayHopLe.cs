using System;

namespace NMLT.Buoi4
{
    public class KiemTraNgayHopLe
    {
        public static void ChayBaiTap()
        {
            Console.Write("Nhap ngay: ");
            int d = int.Parse(Console.ReadLine()!);
            Console.Write("Nhap thang: ");
            int m = int.Parse(Console.ReadLine()!);
            Console.Write("Nhap nam: ");
            int y = int.Parse(Console.ReadLine()!);

            if (y <= 0 || m < 1 || m > 12 || d < 1)
            {
                Console.WriteLine("Ngay khong hop le.");
                return;
            }

            int soNgayTrongThang = 0;

            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    soNgayTrongThang = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    soNgayTrongThang = 30;
                    break;
                case 2:
                    bool laNamNhuan = (y % 400 == 0) || (y % 4 == 0 && y % 100 != 0);
                    soNgayTrongThang = laNamNhuan ? 29 : 28;
                    break;
            }

            if (d > soNgayTrongThang)
            {
                Console.WriteLine("Ngay khong hop le.");
            }
            else
            {
                Console.WriteLine($"Ngay {d}/{m}/{y} hop le.");
            }
        }
    }
}
