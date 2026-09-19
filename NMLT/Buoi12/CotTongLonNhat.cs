using System;

namespace NMLT.Buoi12
{
    public class CotTongLonNhat
    {
        public static void ChayBaiTap()
        {
            int[,] a = NhapXuatMang2C.nhapMang();
            NhapXuatMang2C.inMang(a);

            int n = a.GetLength(0), m = a.GetLength(1);
            int[] tongCot = new int[m];
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    tongCot[j] += a[i, j];
                }
            }

            int tongLonNhat = int.MinValue;
            foreach (int t in tongCot) if (t > tongLonNhat) tongLonNhat = t;

            string ketQua = "";
            for (int j = 0; j < m; j++)
            {
                if (tongCot[j] == tongLonNhat) ketQua += (ketQua == "" ? "" : " ") + j;
            }

            Console.WriteLine($"Cac cot co tong lon nhat: {ketQua}");
        }
    }
}
