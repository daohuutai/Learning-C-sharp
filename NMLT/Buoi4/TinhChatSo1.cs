using System;

namespace NMLT.Buoi4
{
    public class TinhChatSo1
    {
        public static void ChayBaiTap()
        {
            Console.Write("Nhap so tu nhien n (< 1000): ");
            int n = int.Parse(Console.ReadLine()!);

            if (n < 0 || n >= 1000)
            {
                Console.WriteLine("So khong hop le. Vui long nhap so tu nhien nho hon 1000.");
                return;
            }

            int count = 0;
            int temp = n;
            int sum = 0;

            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
                count++;
            }

            if (n == 0)
            {
                count = 1;
                sum = 0;
            }

            int soCuoi = n % 10;
            int soDau = n;

            while (soDau >= 10)
            {
                soDau /= 10;
            }

            Console.WriteLine($"(a) So {n} co {count} chu so.");
            Console.WriteLine($"(b) Tong cac chu so cua {n} la: {sum}");
            Console.WriteLine($"(c) Chu so cuoi cua {n} la: {soCuoi}");
            Console.WriteLine($"(d) Chu so dau cua {n} la: {soDau}");
        }
    }
}
