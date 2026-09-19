using System;

namespace NMLT.Buoi10
{
    public class DayDanDau
    {
        public static void ChayBaiTap()
        {
            double[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoThuc();
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            bool danDau = true;
            for (int i = 0; i < day.Length - 1; i++)
            {
                if (day[i] * day[i + 1] >= 0)
                {
                    danDau = false;
                    break;
                }
            }

            Console.WriteLine(danDau ? "Day so tren la day dan dau." : "Day so tren khong la day dan dau.");
        }
    }
}
