using System;

namespace NMLT.Buoi12
{
    // Lop tien ich dung chung cho cac bai tap mang 2 chieu trong Buoi 12
    public static class NhapXuatMang2C
    {
        public static int[,] nhapMang()
        {
            Console.Write("Moi ban nhap so dong: ");
            int n = int.Parse(Console.ReadLine()!);
            Console.Write("Moi ban nhap so cot: ");
            int m = int.Parse(Console.ReadLine()!);

            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Phan tu [{i},{j}]: ");
                    a[i, j] = int.Parse(Console.ReadLine()!);
                }
            }
            return a;
        }

        public static void inMang(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            Console.WriteLine($"Mang co {n} dong x {m} cot:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i, j],6}");
                }
                Console.WriteLine();
            }
        }
    }
}
