//Cho số thực a. Hãy tính a2, a5 và a17 chỉ dùng 6 phép nhân.

using System;

namespace NMLT.Buoi2
{
    class LuyThuaNhanh
    {
        static void Main()
        {
            double a = 2.0;
            double a2 = a*a;
            double a4 = a2*a2;
            double a5 = a*a4;
            double a8 = a4*a4;
            double a16 = a8*a8;
            double a17 = a16*a;

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"a^2  = {a2}");
            Console.WriteLine($"a^5  = {a5}");
            Console.WriteLine($"a^17 = {a17}");
        }
    }
}