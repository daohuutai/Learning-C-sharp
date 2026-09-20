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
                Console.WriteLine("--- Buoi 5 (Cau lenh lap) ---");
                Console.WriteLine("30. GiaiThua");
                Console.WriteLine("31. GiaTriBieuThuc");
                Console.WriteLine("32. TimBeNhatThoa");
                Console.WriteLine("33. ThucDon");
                Console.WriteLine("--- Buoi 6 (Lap long, re nhanh long) ---");
                Console.WriteLine("34. XuLyChuSo1");
                Console.WriteLine("35. PhanTichThuaSo1");
                Console.WriteLine("36. KiemTraSoHoanHao");
                Console.WriteLine("37. LietKeSoHoanHao");
                Console.WriteLine("--- Buoi 7 (Lap trinh don the) ---");
                Console.WriteLine("38. InHinhTamGiacVaVuong");
                Console.WriteLine("39. TinhSoPi");
                Console.WriteLine("40. NgayTruoc");
                Console.WriteLine("41. KiemTraSoHoanHao (ham don the)");
                Console.WriteLine("--- Buoi 8 (Phoi hop giua cac don the) ---");
                Console.WriteLine("42. GiaiThua - To hop C(k,n)");
                Console.WriteLine("43. RutGonPhanSo");
                Console.WriteLine("44. DemChuSo");
                Console.WriteLine("45. LietKeSoHoanHao (dung ham)");
                Console.WriteLine("--- Buoi 9 (Mang 1 chieu) ---");
                Console.WriteLine("46. LietKeChan");
                Console.WriteLine("47. DemDau");
                Console.WriteLine("48. TimKiem");
                Console.WriteLine("49. TimKiemGiaTriChan");
                Console.WriteLine("--- Buoi 10 (Ky thuat xu ly day) ---");
                Console.WriteLine("50. TrungBinhCongCucTri");
                Console.WriteLine("51. KeNhauTraiDau");
                Console.WriteLine("52. DayDanDau");
                Console.WriteLine("53. DoanDuongDaiNhat");
                Console.WriteLine("--- Buoi 11 (Bien doi tren day) ---");
                Console.WriteLine("54. XoaChan");
                Console.WriteLine("55. DaoDay");
                Console.WriteLine("56. TronDay");
                Console.WriteLine("57. SapChanLe");
                Console.WriteLine("--- Buoi 12 (Mang 2 chieu) ---");
                Console.WriteLine("58. TongChanLeMang2C");
                Console.WriteLine("59. MaTranToanLe");
                Console.WriteLine("60. DongTangDan");
                Console.WriteLine("61. CotTongLonNhat");
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

                    case "30": NMLT.Buoi5.GiaiThua.ChayBaiTap(); break;
                    case "31": NMLT.Buoi5.GiaTriBieuThuc.ChayBaiTap(); break;
                    case "32": NMLT.Buoi5.TimBeNhatThoa.ChayBaiTap(); break;
                    case "33": NMLT.Buoi5.ThucDon.ChayBaiTap(); break;

                    case "34": NMLT.Buoi6.XuLyChuSo1.ChayBaiTap(); break;
                    case "35": NMLT.Buoi6.PhanTichThuaSo1.ChayBaiTap(); break;
                    case "36": NMLT.Buoi6.KiemTraSoHoanHao.ChayBaiTap(); break;
                    case "37": NMLT.Buoi6.LietKeSoHoanHao.ChayBaiTap(); break;

                    case "38": NMLT.Buoi7.InHinhTamGiacVaVuong.ChayBaiTap(); break;
                    case "39": NMLT.Buoi7.TinhSoPi.ChayBaiTap(); break;
                    case "40": NMLT.Buoi7.NgayTruoc.ChayBaiTap(); break;
                    case "41": NMLT.Buoi7.KiemTraSoHoanHao.ChayBaiTap(); break;

                    case "42": NMLT.Buoi8.GiaiThua.ChayBaiTap(); break;
                    case "43": NMLT.Buoi8.RutGonPhanSo.ChayBaiTap(); break;
                    case "44": NMLT.Buoi8.DemChuSo.ChayBaiTap(); break;
                    case "45": NMLT.Buoi8.LietKeSoHoanHao.ChayBaiTap(); break;

                    case "46": NMLT.Buoi9.LietKeChan.ChayBaiTap(); break;
                    case "47": NMLT.Buoi9.DemDau.ChayBaiTap(); break;
                    case "48": NMLT.Buoi9.TimKiem.ChayBaiTap(); break;
                    case "49": NMLT.Buoi9.TimKiemGiaTriChan.ChayBaiTap(); break;

                    case "50": NMLT.Buoi10.TrungBinhCongCucTri.ChayBaiTap(); break;
                    case "51": NMLT.Buoi10.KeNhauTraiDau.ChayBaiTap(); break;
                    case "52": NMLT.Buoi10.DayDanDau.ChayBaiTap(); break;
                    case "53": NMLT.Buoi10.DoanDuongDaiNhat.ChayBaiTap(); break;

                    case "54": NMLT.Buoi11.XoaChan.ChayBaiTap(); break;
                    case "55": NMLT.Buoi11.DaoDay.ChayBaiTap(); break;
                    case "56": NMLT.Buoi11.TronDay.ChayBaiTap(); break;
                    case "57": NMLT.Buoi11.SapChanLe.ChayBaiTap(); break;

                    case "58": NMLT.Buoi12.TongChanLeMang2C.ChayBaiTap(); break;
                    case "59": NMLT.Buoi12.MaTranToanLe.ChayBaiTap(); break;
                    case "60": NMLT.Buoi12.DongTangDan.ChayBaiTap(); break;
                    case "61": NMLT.Buoi12.CotTongLonNhat.ChayBaiTap(); break;

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
