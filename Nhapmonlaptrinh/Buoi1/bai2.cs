/*
Nhập vào bán kính R của một hình tròn. Hãy tính diện tích và chu vi hình tròn đó theo công
thức:S = 3.14xR^2
P = 2x3.14xR. In kết quả với 1 số lẻ thập phân.
*/

using System; 

namespace NMLT.Buoi1
{
    class HinhTron
    {
        public static void Main(string[] args)
        {
            double R; // Nên dùng double để bán kính có thể nhập số thực
            double S, P;

            Console.Write("Nhap ban kinh R: ");
            R = double.Parse(Console.ReadLine());

            S = 3.14 * R * R;
            P = 2 * 3.14 * R;

            // In kết quả lấy 1 chữ số sau dấu phẩy (F1)
            Console.WriteLine("Dien tich S = {0:F1}", S);
            Console.WriteLine("Chu vi P = {0:F1}", P);
            
            Console.Read();
        }
    }
}

