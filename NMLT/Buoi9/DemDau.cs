using System;

namespace NMLT.Buoi9
{
    public class DemDau
    {
        public static void ChayBaiTap()
        {
            double[] day = NhapXuatMang.nhapMangSoThuc();

            int soDuong = 0, soAm = 0, soKhong = 0;
            foreach (double x in day)
            {
                if (x > 0) soDuong++;
                else if (x < 0) soAm++;
                else soKhong++;
            }

            Console.WriteLine($"Day so co {soAm} so am, {soKhong} so khong va {soDuong} so duong.");
        }
    }
}
