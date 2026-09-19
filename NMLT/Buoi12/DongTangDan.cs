using System;

namespace NMLT.Buoi12
{
    public class DongTangDan
    {
        public static void ChayBaiTap()
        {
            int[,] a = NhapXuatMang2C.nhapMang();
            NhapXuatMang2C.inMang(a);

            int n = a.GetLength(0), m = a.GetLength(1);
            string ketQua = "";
            for (int i = 0; i < n; i++)
            {
                bool tangDan = true;
                for (int j = 0; j < m - 1; j++)
                {
                    if (a[i, j] >= a[i, j + 1]) { tangDan = false; break; }
                }
                if (tangDan) ketQua += (ketQua == "" ? "" : " ") + i;
            }

            Console.WriteLine($"Cac dong tao thanh day tang: {ketQua}");
        }
    }
}
