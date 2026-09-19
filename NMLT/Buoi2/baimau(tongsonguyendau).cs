using System;
namespace NMLT.Buoi2
{
public class TongSoNguyenDau
{
public static void ChayBaiTap()
{
// Khai báo biến
int n, tong;
// Nhập dữ liệu
Console.Write("Moi ban nhap so nguyen n: ");
n = int.Parse(Console.ReadLine());
// Xử lý
tong = n * (n + 1) / 2;
// Xuất kết quả
Console.WriteLine("S = 1 + 2 + ... + {0} = {1}.", n, tong);
}
}
}