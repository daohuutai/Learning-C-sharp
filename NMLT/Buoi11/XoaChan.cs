using System;

namespace NMLT.Buoi11
{
    public class XoaChan
    {
        public static void ChayBaiTap()
        {
            int[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoNguyen();
            Console.WriteLine("* Mang truoc xoa:");
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            int soPhanTuMoi = 0;
            foreach (int x in day)
            {
                if (x % 2 != 0) soPhanTuMoi++;
            }

            int[] mangMoi = new int[soPhanTuMoi];
            int viTri = 0;
            foreach (int x in day)
            {
                if (x % 2 != 0) mangMoi[viTri++] = x;
            }

            Console.WriteLine("* Mang sau khi xoa:");
            NMLT.Buoi9.NhapXuatMang.inMang(mangMoi);
        }
    }
}
