using System;

namespace NMLT.Buoi3
{
    class ThuTuNgayNam
    {
        public static void ChayBaiTap()
        {
            int ngay, thang, nam;
            int soNgayCach = 0;
            bool nhuan;

            Console.Write("Moi ban nhap ngay, thang, nam: ");
            string[] input = Console.ReadLine().Split(' ');
            ngay = int.Parse(input[0]);
            thang = int.Parse(input[1]);
            nam = int.Parse(input[2]);

            nhuan = (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);

            if (thang > 1) soNgayCach += 31;
            if (thang > 2) soNgayCach += (nhuan ? 29 : 28);
            if (thang > 3) soNgayCach += 31;
            if (thang > 4) soNgayCach += 30;
            if (thang > 5) soNgayCach += 31;
            if (thang > 6) soNgayCach += 30;
            if (thang > 7) soNgayCach += 31;
            if (thang > 8) soNgayCach += 31;
            if (thang > 9) soNgayCach += 30;
            if (thang > 10) soNgayCach += 31;
            if (thang > 11) soNgayCach += 30;

            soNgayCach += (ngay - 1);

            Console.WriteLine("Ngay {0}/{1}/{2} cach ngay dau nam (1/1/{2}) la {3} ngay.", ngay, thang, nam, soNgayCach);

            Console.Read();
        }
    }
}
