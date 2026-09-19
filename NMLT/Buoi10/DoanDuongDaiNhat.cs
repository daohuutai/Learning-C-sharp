using System;

namespace NMLT.Buoi10
{
    public class DoanDuongDaiNhat
    {
        public static void ChayBaiTap()
        {
            double[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoThuc();
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            int viTriBatDauTot = -1, doDaiTot = 0;
            int i = 0;
            while (i < day.Length)
            {
                if (day[i] > 0)
                {
                    int batDau = i;
                    while (i < day.Length && day[i] > 0) i++;
                    int doDai = i - batDau;
                    if (doDai > doDaiTot)
                    {
                        doDaiTot = doDai;
                        viTriBatDauTot = batDau;
                    }
                }
                else
                {
                    i++;
                }
            }

            if (doDaiTot == 0)
            {
                Console.WriteLine("Day so khong co doan duong nao.");
                return;
            }

            Console.Write($"Doan duong [{viTriBatDauTot}, {viTriBatDauTot + doDaiTot - 1}] dai nhat:");
            for (int k = viTriBatDauTot; k < viTriBatDauTot + doDaiTot; k++)
            {
                Console.Write($" {day[k]}");
            }
            Console.WriteLine();
        }
    }
}
