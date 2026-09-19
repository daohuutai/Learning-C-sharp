using System;

namespace NMLT.Buoi9
{
    // Lop tien ich dung chung cho cac bai tap mang 1 chieu trong Buoi 9
    public static class NhapXuatMang
    {
        public static int[] nhapMangSoNguyen()
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()!);
            int[] day = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu {i}: ");
                day[i] = int.Parse(Console.ReadLine()!);
            }
            return day;
        }

        public static double[] nhapMangSoThuc()
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()!);
            double[] day = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu {i}: ");
                day[i] = double.Parse(Console.ReadLine()!);
            }
            return day;
        }

        public static void inMang(int[] day)
        {
            Console.Write($"Day so co {day.Length} phan tu:");
            foreach (int x in day) Console.Write($" {x}");
            Console.WriteLine();
        }

        public static void inMang(double[] day)
        {
            Console.Write($"Day so co {day.Length} phan tu:");
            foreach (double x in day) Console.Write($" {x}");
            Console.WriteLine();
        }
    }
}
