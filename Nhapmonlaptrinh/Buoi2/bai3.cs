/*
Cho số thực x. Hãy tính giá trị của biểu thức sau chỉ dùng phép cộng, trừ, nhân:
f(x) = 1 + 2x + 3x2 – 4x3
trong đó sử dụng không quá 8 phép toán.
*/

using System;

namespace NMLT.Buoi2
{
    class BieuThucNhanh
    {
        static void Main()
        {
            double x ; 
            Console.Write("Moi nhap so thuc x: ");
            x = int.Parse(Console.ReadLine()); 
            double fx = 1 + x * (2 + x * (3 - 4 * x));
            Console.WriteLine($"f({x}) = {fx}");
        }
    }
}