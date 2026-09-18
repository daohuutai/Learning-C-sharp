using System;

namespace NMLT.Buoi4
{
    public class PhanLoaiTamGiac
{
    public static void ChayBaiTap()
    {
        Console.WriteLine("Nhap do dai 3 canh cua tam giac: ");
        double a = double.Parse(Console.ReadLine()!);
        double b = double.Parse(Console.ReadLine()!);
        double c = double.Parse(Console.ReadLine()!);

        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Tam giac deu");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Tam giac can");
            }
            else
            {
                Console.WriteLine("Tam giac thuong");
            }
        }
        else
        {
            Console.WriteLine("Khong phai la tam giac");
        }
    }
}
}