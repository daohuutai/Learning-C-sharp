using System;

namespace NMLT.Buoi11
{
    public class TronDay
    {
        public static void ChayBaiTap()
        {
            Console.WriteLine("* Day A (tang dan):");
            int[] a = NMLT.Buoi9.NhapXuatMang.nhapMangSoNguyen();
            Console.WriteLine("* Day B (tang dan):");
            int[] b = NMLT.Buoi9.NhapXuatMang.nhapMangSoNguyen();

            int[] c = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j]) c[k++] = a[i++];
                else c[k++] = b[j++];
            }
            while (i < a.Length) c[k++] = a[i++];
            while (j < b.Length) c[k++] = b[j++];

            Console.WriteLine("* Day C (sau khi tron):");
            NMLT.Buoi9.NhapXuatMang.inMang(c);
        }
    }
}
