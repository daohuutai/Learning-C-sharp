using System;

namespace NMLT.Buoi8
{
    public class RutGonPhanSo
    {
        // Ham don the: tim uoc chung lon nhat
        static int usCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap tu so: ");
            int tuSo = int.Parse(Console.ReadLine()!);
            Console.Write("Moi ban nhap mau so: ");
            int mauSo = int.Parse(Console.ReadLine()!);

            int uc = usCLN(tuSo, mauSo);
            Console.WriteLine($"Phan so {tuSo}/{mauSo} duoc rut gon thanh {tuSo / uc}/{mauSo / uc}.");
        }
    }
}
