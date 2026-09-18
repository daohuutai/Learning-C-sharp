using System;

namespace NMLT.Buoi4
{
    public class TinhChatSo
    {
        public static void ChayBaiTap()
        {
            Console.Write("Nhap mot so nguyen co 4 chu so: ");
            int n = int.Parse(Console.ReadLine()!);

            if (n < 1000 || n > 9999)
            {
                Console.WriteLine("So khong co 4 chu so.");
                return;
            }

            string s = n.ToString();
            bool laSoDoiXung = s[0] == s[3] && s[1] == s[2];
            bool coBaChuSoGiongNhau = s.GroupBy(ch => ch).Any(g => g.Count() == 3) && !s.All(ch => ch == s[0]);
            bool coBonChuSoKhacNhau = s.Distinct().Count() == 4;

            Console.WriteLine($"So {n}:");
            Console.WriteLine(laSoDoiXung ? "La so doi xung." : "Khong phai la so doi xung.");
            Console.WriteLine(coBaChuSoGiongNhau ? "Co 3 chu so giong nhau." : "Khong co 3 chu so giong nhau.");
            Console.WriteLine(coBonChuSoKhacNhau ? "Co 4 chu so khac nhau." : "Khong co 4 chu so khac nhau.");
        }
    }
}