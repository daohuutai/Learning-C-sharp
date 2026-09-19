using System;

namespace NMLT.Buoi5
{
    public class GiaiThua
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so n: ");
            int n = int.Parse(Console.ReadLine()!);

            long ketQua = 1;
            string bieuThuc = "1";
            for (int i = 1; i <= n; i++)
            {
                ketQua *= i;
                if (i > 1) bieuThuc += "." + i;
            }

            Console.WriteLine($"{n}! = {bieuThuc} = {ketQua}.");
        }
    }
}
