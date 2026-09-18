/*
Cho 3 số thực a, b, c là độ dài 3 cạnh của một tam giác. Hãy tính diện tích tam giác này theo
công thức Heron: S = sqrt(p*(p-a)*(p-b)*(p-c)) với p = (a+b+c)/2. 
In kết quả với 2 số lẻ thập phân.
*/

using System;

namespace NMLT.Buoi1
{
    public class DienTichTamGiac
    {
        public static void ChayBaiTap()
        {
            double a, b, c, p, s;

            Console.Write("Nhap do dai canh a: ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Nhap do dai canh b: ");
            b = int.Parse(Console.ReadLine());

            Console.Write("Nhap do dai canh c: ");
            c = int.Parse(Console.ReadLine());

            p = (a+b+c)/2;
            s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            // In đúng định dạng bạn yêu cầu
            Console.WriteLine("Dien tich tam giac s = {0:F2} ",s );
            Console.Read();
        }
    }
}