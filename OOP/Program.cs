using System;
using Lab02ThucHanh.ThucHanh1;
using Lab02ThucHanh.ThucHanh2;

namespace Lab02ThucHanh
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dangChay = true;

            while (dangChay)
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("            LAB02 - MENU CHINH          ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Thuc hanh 1 - Ngon ngu lap trinh C# co ban");
                Console.WriteLine("2. Thuc hanh 2 - Lap trinh huong doi tuong ");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("Chon chuc nang: ");

                string? luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        MenuThucHanh1.Hien();
                        break;

                    case "2":
                        MenuThucHanh2.Hien();
                        Console.WriteLine("Thuc hanh 2 chua duoc cai dat, se bo sung o lan cap nhat sau.");
                        break;

                    case "0":
                        dangChay = false;
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                        break;
                }
            }

            Console.WriteLine("Da thoat chuong trinh.");
        }
    }
}
