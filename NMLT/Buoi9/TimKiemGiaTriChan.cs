using System;

namespace NMLT.Buoi9
{
    public class TimKiemGiaTriChan
    {
        public static void ChayBaiTap()
        {
            int[] day = NhapXuatMang.nhapMangSoNguyen();

            int viTriDauTien = -1, viTriCuoiCung = -1;
            for (int i = 0; i < day.Length; i++)
            {
                if (day[i] % 2 == 0)
                {
                    if (viTriDauTien == -1) viTriDauTien = i;
                    viTriCuoiCung = i;
                }
            }

            if (viTriDauTien == -1)
            {
                Console.WriteLine("Day so khong co gia tri chan.");
                return;
            }

            Console.WriteLine($"Gia tri chan dau tien o vi tri {viTriDauTien} co gia tri {day[viTriDauTien]}.");
            Console.WriteLine($"Gia tri chan cuoi cung o vi tri {viTriCuoiCung} co gia tri {day[viTriCuoiCung]}.");
        }
    }
}
