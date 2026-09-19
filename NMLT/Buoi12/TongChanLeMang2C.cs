using System;

namespace NMLT.Buoi12
{
    public class TongChanLeMang2C
    {
        public static void ChayBaiTap()
        {
            int[,] a = NhapXuatMang2C.nhapMang();
            NhapXuatMang2C.inMang(a);

            int tongChan = 0, tongLe = 0;
            foreach (int x in a)
            {
                if (x % 2 == 0) tongChan += x;
                else tongLe += x;
            }

            Console.WriteLine($"Tong cac so chan la {tongChan} va tong so le la {tongLe}.");
        }
    }
}
