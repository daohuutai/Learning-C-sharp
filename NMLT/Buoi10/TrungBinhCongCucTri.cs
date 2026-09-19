using System;

namespace NMLT.Buoi10
{
    public class TrungBinhCongCucTri
    {
        public static void ChayBaiTap()
        {
            double[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoThuc();
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            double tong = 0;
            int soLuong = 0;
            for (int i = 0; i < day.Length; i++)
            {
                bool laCucTri;
                if (day.Length == 1)
                {
                    laCucTri = true;
                }
                else if (i == 0)
                {
                    laCucTri = (day[i] > day[i + 1]) || (day[i] < day[i + 1]);
                }
                else if (i == day.Length - 1)
                {
                    laCucTri = (day[i] > day[i - 1]) || (day[i] < day[i - 1]);
                }
                else
                {
                    laCucTri = (day[i] > day[i - 1] && day[i] > day[i + 1]) ||
                               (day[i] < day[i - 1] && day[i] < day[i + 1]);
                }

                if (laCucTri)
                {
                    tong += day[i];
                    soLuong++;
                }
            }

            Console.WriteLine($"Tong cac phan tu cuc tri co trong day so: {tong}.");
        }
    }
}
