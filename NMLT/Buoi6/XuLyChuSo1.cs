using System;

namespace NMLT.Buoi6
{
    public class XuLyChuSo1
    {
        public static void ChayBaiTap()
        {
            Console.Write("Moi ban nhap so nguyen n: ");
            string n = Console.ReadLine()!;

            Console.Write("Moi ban nhap vi tri k: ");
            int k = int.Parse(Console.ReadLine()!);

            // a) Chu so thu k tinh tu trai
            char chuSoK = n[k - 1];
            Console.WriteLine($"Chu so o vi tri {k} (tinh tu trai) cua {n} la {chuSoK}.");

            // b) Tong cac chu so le, c) chu so le nho nhat va lon nhat
            int tongLe = 0;
            int nhoNhat = int.MaxValue, lonNhat = int.MinValue;
            bool coChuSoLe = false;
            foreach (char c in n)
            {
                int chuSo = c - '0';
                if (chuSo % 2 != 0)
                {
                    coChuSoLe = true;
                    tongLe += chuSo;
                    if (chuSo < nhoNhat) nhoNhat = chuSo;
                    if (chuSo > lonNhat) lonNhat = chuSo;
                }
            }
            Console.WriteLine($"Tong cac chu so le cua {n} la {tongLe}.");
            if (coChuSoLe)
                Console.WriteLine($"{n} co chu so le nho nhat la {nhoNhat} va lon nhat la {lonNhat}.");
            else
                Console.WriteLine($"{n} khong co chu so le.");
        }
    }
}
