using System;

namespace NMLT.Buoi4
{
    public class TienNuoc
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("Nhap so dien tieu thu: ");
            int soDien = int.Parse(Console.ReadLine()!);
            double tienNuoc = 0;
            if (soDien <= 50)
            {
                tienNuoc = soDien * 1000;
            }
            else if (soDien <= 100)
            {
                tienNuoc = 50 * 1000 + (soDien - 50) * 1200;
            }
            else
            {
                tienNuoc = 50 * 1000 + 50 * 1200 + (soDien - 100) * 1500;
            }
            Console.WriteLine($"Tien nuoc phai tra: {tienNuoc}");
        }
    }
}