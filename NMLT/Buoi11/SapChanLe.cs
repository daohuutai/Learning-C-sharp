using System;

namespace NMLT.Buoi11
{
    public class SapChanLe
    {
        public static void ChayBaiTap()
        {
            int[] day = NMLT.Buoi9.NhapXuatMang.nhapMangSoNguyen();
            Console.WriteLine("* Mang truoc khi sap xep:");
            NMLT.Buoi9.NhapXuatMang.inMang(day);

            // Tach thanh 2 danh sach: chan va le
            int soChan = 0;
            foreach (int x in day) if (x % 2 == 0) soChan++;

            int[] chan = new int[soChan];
            int[] le = new int[day.Length - soChan];
            int ic = 0, il = 0;
            foreach (int x in day)
            {
                if (x % 2 == 0) chan[ic++] = x;
                else le[il++] = x;
            }

            // Sap xep chan tang dan (bubble sort don gian)
            for (int i = 0; i < chan.Length - 1; i++)
                for (int j = 0; j < chan.Length - 1 - i; j++)
                    if (chan[j] > chan[j + 1]) { int t = chan[j]; chan[j] = chan[j + 1]; chan[j + 1] = t; }

            // Sap xep le giam dan (bubble sort don gian)
            for (int i = 0; i < le.Length - 1; i++)
                for (int j = 0; j < le.Length - 1 - i; j++)
                    if (le[j] < le[j + 1]) { int t = le[j]; le[j] = le[j + 1]; le[j + 1] = t; }

            int[] ketQua = new int[day.Length];
            Array.Copy(chan, 0, ketQua, 0, chan.Length);
            Array.Copy(le, 0, ketQua, chan.Length, le.Length);

            Console.WriteLine("* Mang sau khi sap xep:");
            NMLT.Buoi9.NhapXuatMang.inMang(ketQua);
        }
    }
}
