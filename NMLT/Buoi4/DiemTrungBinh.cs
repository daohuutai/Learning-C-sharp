using System;

namespace NMLT.Buoi4
{
    public class DiemTrungBinh
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("Nhap so diem: ");
            int n = int.Parse(Console.ReadLine()!);
            double tong = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap diem thu {i + 1}: ");
                double diem = double.Parse(Console.ReadLine()!);
                tong += diem;
            }
            double diemTrungBinh = tong / n;
            Console.WriteLine($"Diem trung binh: {diemTrungBinh}");
        }
    }
}