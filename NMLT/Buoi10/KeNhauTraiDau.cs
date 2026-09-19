using System;

namespace NMLT.Buoi10
{
    public class KeNhauTraiDau
    {
        public static void ChayBaiTap()
        {
            double[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoThuc();
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            int dem = 0;
            for (int i = 0; i < day.Length - 1; i++)
            {
                if (day[i] * day[i + 1] < 0) dem++;
            }

            Console.WriteLine($"So luong cac phan tu ke nhau ma trai dau: {dem}.");
        }
    }
}
