/*
Nhập vào hai số nguyên a và b (a<=b). Hãy tính tổng các số nằm trong đoạn [a, b]. (Lưu ý: tổng
từ a đến b bằng tổng từ 1 đến b trừ cho tổng từ 1 đến a-1).
*/

using System;

namespace NMLT.Buoi2
{
    class TongDoan
    {
        static void Main()
        {
            Console.Write("Nhap so a: ");
            long a = long.Parse(Console.ReadLine());

            Console.Write("Nhap so b: ");
            long b = long.Parse(Console.ReadLine());

            long tongDenB = b * (b + 1) / 2;
            long tongDenAMot = (a - 1) * a / 2;

            long tong = tongDenB - tongDenAMot;

            Console.WriteLine($"Tong cac so trong doan [{a}, {b}] la: {tong}");
        }
    }
}