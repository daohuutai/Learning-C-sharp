using System;
namespace NMLT.Buoi01
{
class BieuThuc
{
public static void ChayBaiTap()
{
// Khai báo biến
int a, b;
int kqCong, kqTru, kqNhan, kqChiaNguyen, kqDu;
double kqChiaThuc;
// Nhập dữ liệu
Console.Write("Moi ban nhap so a: ");
a = int.Parse(Console.ReadLine());
Console.Write("Moi ban nhap so b: ");
b = int.Parse(Console.ReadLine());
// Xử lý
kqCong = a + b;
kqTru = a - b;
kqNhan = a * b;
kqChiaNguyen = a / b;
kqDu= a % b;
kqChiaThuc = a / (double)b;
// Xuất dữ liệu
Console.WriteLine("Cac ket qua tinh toan: ");
Console.WriteLine("{0, -5} + {1, 5} = {2, 5}", a, b, kqCong);
Console.WriteLine("{0, -5} - {1, 5} = {2, 5}", a, b, kqTru);
Console.WriteLine("{0, -5} * {1, 5} = {2, 5}", a, b, kqNhan);
Console.WriteLine("{0, -5} / {1, 5} = {2, 5}", a, b, kqChiaNguyen);
Console.WriteLine("{0, -5} % {1, 5} = {2, 5}", a, b, kqDu);
Console.WriteLine("{0, -5} / {1, 5} = {2, 5: #.00}", a, b, kqChiaThuc);
// Dừng chương trình chờ nhập phím
Console.Read();
}
}
}