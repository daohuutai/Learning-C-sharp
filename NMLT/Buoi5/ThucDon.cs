using System;

namespace NMLT.Buoi5
{
    public class ThucDon
    {
        public static void ChayBaiTap()
        {
            int luaChon;
            do
            {
                Console.Clear();
                Console.WriteLine("THUC DON");
                Console.WriteLine("1. Tinh dien tich tam giac");
                Console.WriteLine("2. Tinh dien tich hinh chu nhat");
                Console.WriteLine("3. Tinh dien tich hinh tron");
                Console.WriteLine("4. Thoat");
                Console.WriteLine("-------------------------------------------");
                Console.Write("Moi ban chon chuc nang [1, 2, 3, 4]: ");
                luaChon = int.Parse(Console.ReadLine()!);
                Console.WriteLine("-------------------------------------------");

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Moi ban nhap canh day: ");
                        double day = double.Parse(Console.ReadLine()!);
                        Console.Write("Moi ban nhap chieu cao: ");
                        double chieuCao = double.Parse(Console.ReadLine()!);
                        Console.WriteLine($"Dien tich tam giac la {0.5 * day * chieuCao}.");
                        break;
                    case 2:
                        Console.Write("Moi ban nhap do dai: ");
                        double doDai = double.Parse(Console.ReadLine()!);
                        Console.Write("Moi ban nhap do rong: ");
                        double doRong = double.Parse(Console.ReadLine()!);
                        Console.WriteLine($"Hinh chu nhat do dai {doDai} va do rong {doRong} co dien tich la {doDai * doRong}.");
                        break;
                    case 3:
                        Console.Write("Moi ban nhap ban kinh: ");
                        double banKinh = double.Parse(Console.ReadLine()!);
                        Console.WriteLine($"Dien tich hinh tron la {Math.PI * banKinh * banKinh:F2}.");
                        break;
                    case 4:
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                if (luaChon != 4)
                {
                    Console.WriteLine("\nBan nhan phim bat ky de tiep tuc ...");
                    Console.ReadKey();
                }
            } while (luaChon != 4);
        }
    }
}
