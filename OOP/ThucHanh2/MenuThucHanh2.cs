using System;

namespace Lab02ThucHanh.ThucHanh2
{
    // Menu con cho Thuc hanh 2 (Lap trinh huong doi tuong)
    // Hien tai moi cai dat muc 1 "Thiet ke lop co ban" (Bai 1.1 - 1.5).
    // Muc 2 (Thiet ke lop nang cao) va muc 3 (Ke thua va da hinh) se bo sung sau.
    public class MenuThucHanh2
    {
        public static void Hien()
        {
            bool dangChay = true;

            while (dangChay)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("     THUC HANH 2 - LAP TRINH OOP        ");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("-- 1. Thiet ke lop co ban --");
                Console.WriteLine("1. Bai 1.1 - Tinh tuoi sinh vien");
                Console.WriteLine("2. Bai 1.2 - Lop Point (khoang cach, trung diem)");
                Console.WriteLine("3. Bai 1.3 - Lop Person");
                Console.WriteLine("4. Bai 1.4 - Lop Phan so");
                Console.WriteLine("5. Bai 1.5 - Lop Don thuc");
                Console.WriteLine("0. Quay lai menu chinh");
                Console.Write("Chon bai: ");

                string? luaChon = Console.ReadLine();
                Console.WriteLine();

                switch (luaChon)
                {
                    case "1":
                        Bai1_1.Run();
                        break;

                    case "2":
                        Bai1_2.Run();
                        break;

                    case "3":
                        Bai1_3.Run();
                        break;

                    case "4":
                        Bai1_4.Run();
                        break;

                    case "5":
                        Bai1_5.Run();
                        break;

                    case "0":
                        dangChay = false;
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                        break;
                }

                if (dangChay)
                {
                    Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                }
            }
        }
    }
}
