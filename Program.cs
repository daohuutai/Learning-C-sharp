using System;
using NMLT.Buoi1;
using NMLT.Buoi01;
using NMLT.Buoi2;
using NMLT.Buoi3;
using NMLT.Buoi03;
using NMLT.Buoi4;

namespace NMLT
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== DANH SACH BAI TAP ==========");
                Console.WriteLine("--- Buoi 1 ---");
                Console.WriteLine(" 1. DienTichTamGiac");
                Console.WriteLine(" 2. DoiSangGiay");
                Console.WriteLine(" 3. HinhTron");
                Console.WriteLine(" 4. InNhan");
                Console.WriteLine(" 5. BaiMau - In chuoi");
                Console.WriteLine(" 6. BaiMau - Bieu thuc tinh toan");
                Console.WriteLine("--- Buoi 2 ---");
                Console.WriteLine(" 7. BieuThucNhanh");
                Console.WriteLine(" 8. LuyThuaNhanh");
                Console.WriteLine(" 9. TongDoan");
                Console.WriteLine("10. BaiMau - Tong so nguyen dau");
                Console.WriteLine("--- Buoi 3 ---");
                Console.WriteLine("11. ChuSoLonNhat");
                Console.WriteLine("12. DocKySo");
                Console.WriteLine("13. GiaTriHamSo1");
                Console.WriteLine("14. GiaTriHamSo2");
                Console.WriteLine("15. MaxMin5So");
                Console.WriteLine("16. PhuongTrinhBac2");
                Console.WriteLine("17. PhuongTrinhTrungPhuong");
                Console.WriteLine("18. ThangTiengAnh");
                Console.WriteLine("19. ThuTuNgayNam");
                Console.WriteLine("--- Buoi 4 ---");
                Console.WriteLine("20. DiemTrungBinh");
                Console.WriteLine("21. GiaTriHamSoDoThi");
                Console.WriteLine("22. HePhuongTrinh");
                Console.WriteLine("23. KiemTraNgayHopLe");
                Console.WriteLine("24. NgaySau");
                Console.WriteLine("25. PhanLoaiTamGiac");
                Console.WriteLine("26. PhuongTrinhBac3");
                Console.WriteLine("27. TienNuoc");
                Console.WriteLine("28. TinhChatSo");
                Console.WriteLine("29. TinhChatSo1");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(" 0. Thoat");
                Console.Write("Chon bai tap can chay: ");

                string? luaChon = Console.ReadLine();
                Console.WriteLine();

                switch (luaChon)
                {
                    case "1": DienTichTamGiac.ChayBaiTap(); break;
                    case "2": DoiSangGiay.ChayBaiTap(); break;
                    case "3": HinhTron.ChayBaiTap(); break;
                    case "4": InNhan.ChayBaiTap(); break;
                    case "5": InChuoi.ChayBaiTap(); break;
                    case "6": BieuThuc.ChayBaiTap(); break;

                    case "7": BieuThucNhanh.ChayBaiTap(); break;
                    case "8": LuyThuaNhanh.ChayBaiTap(); break;
                    case "9": TongDoan.ChayBaiTap(); break;
                    case "10": TongSoNguyenDau.ChayBaiTap(); break;

                    case "11": ChuSoLonNhat.ChayBaiTap(); break;
                    case "12": DocKySo.ChayBaiTap(); break;
                    case "13": GiaTriHamSo1.ChayBaiTap(); break;
                    case "14": GiaTriHamSo2.ChayBaiTap(); break;
                    case "15": MaxMin5So.ChayBaiTap(); break;
                    case "16": PhuongTrinhBac2.ChayBaiTap(); break;
                    case "17": PhuongTrinhTrungPhuong.ChayBaiTap(); break;
                    case "18": ThangTiengAnh.ChayBaiTap(); break;
                    case "19": ThuTuNgayNam.ChayBaiTap(); break;

                    case "20": DiemTrungBinh.ChayBaiTap(); break;
                    case "21": GiaTriHamSoDoThi.ChayBaiTap(); break;
                    case "22": HePhuongTrinh.ChayBaiTap(); break;
                    case "23": KiemTraNgayHopLe.ChayBaiTap(); break;
                    case "24": NgaySau.ChayBaiTap(); break;
                    case "25": PhanLoaiTamGiac.ChayBaiTap(); break;
                    case "26": PhuongTrinhBac3.ChayBaiTap(); break;
                    case "27": TienNuoc.ChayBaiTap(); break;
                    case "28": TinhChatSo.ChayBaiTap(); break;
                    case "29": TinhChatSo1.ChayBaiTap(); break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine("\nNhan phim bat ky de quay lai menu...");
                Console.ReadKey();
            }
        }
    }
}
