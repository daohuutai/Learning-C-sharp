using System;

namespace NMLT.Buoi12
{
    public class MaTranToanLe
    {
        public static void ChayBaiTap()
        {
            int[,] a = NhapXuatMang2C.nhapMang();
            NhapXuatMang2C.inMang(a);

            bool toanLe = true;
            foreach (int x in a)
            {
                if (x % 2 == 0) { toanLe = false; break; }
            }

            Console.WriteLine(toanLe ? "Mang A toan le!" : "Mang A khong toan le!");
        }
    }
}
