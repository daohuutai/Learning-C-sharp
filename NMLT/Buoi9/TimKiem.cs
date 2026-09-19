using System;

namespace NMLT.Buoi9
{
    public class TimKiem
    {
        public static void ChayBaiTap()
        {
            double[] day = NhapXuatMang.nhapMangSoThuc();
            NhapXuatMang.inMang(day);

            Console.WriteLine("* Tim kiem");
            Console.Write("Moi ban nhap gia tri x can tim: ");
            double x = double.Parse(Console.ReadLine()!);

            int dauTien = -1, cuoiCung = -1, soLan = 0;
            for (int i = 0; i < day.Length; i++)
            {
                if (Math.Abs(day[i] - x) < 1e-9)
                {
                    if (dauTien == -1) dauTien = i;
                    cuoiCung = i;
                    soLan++;
                }
            }

            if (soLan > 0)
                Console.WriteLine($"Gia tri {x} xuat hien {soLan} lan o vi tri dau tien {dauTien} va cuoi cung {cuoiCung}.");
            else
                Console.WriteLine($"Gia tri {x} khong ton tai trong day so.");
        }
    }
}
