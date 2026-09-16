using System;

namespace NMLT.Buoi03
{
    class DocKySo
    {
        public static void Main(string[] args)
        {
            int n;
            int c1, c2, c3, c4;
            string t1 = "", t2 = "", t3 = "", t4 = "";

            Console.Write("Moi ban nhap so nguyen duong n co 4 chu so: ");
            n = int.Parse(Console.ReadLine());

            c1 = n / 1000;
            c2 = (n / 100) % 10;
            c3 = (n / 10) % 10;
            c4 = n % 10;

            switch (c1)
            {
                case 0: t1 = "khong"; break;
                case 1: t1 = "mot"; break;
                case 2: t1 = "hai"; break;
                case 3: t1 = "ba"; break;
                case 4: t1 = "bon"; break;
                case 5: t1 = "nam"; break;
                case 6: t1 = "sau"; break;
                case 7: t1 = "bay"; break;
                case 8: t1 = "tam"; break;
                case 9: t1 = "chin"; break;
            }
            switch (c2)
            {
                case 0: t2 = "khong"; break;
                case 1: t2 = "mot"; break;
                case 2: t2 = "hai"; break;
                case 3: t2 = "ba"; break;
                case 4: t2 = "bon"; break;
                case 5: t2 = "nam"; break;
                case 6: t2 = "sau"; break;
                case 7: t2 = "bay"; break;
                case 8: t2 = "tam"; break;
                case 9: t2 = "chin"; break;
            }
            switch (c3)
            {
                case 0: t3 = "khong"; break;
                case 1: t3 = "mot"; break;
                case 2: t3 = "hai"; break;
                case 3: t3 = "ba"; break;
                case 4: t3 = "bon"; break;
                case 5: t3 = "nam"; break;
                case 6: t3 = "sau"; break;
                case 7: t3 = "bay"; break;
                case 8: t3 = "tam"; break;
                case 9: t3 = "chin"; break;
            }
            switch (c4)
            {
                case 0: t4 = "khong"; break;
                case 1: t4 = "mot"; break;
                case 2: t4 = "hai"; break;
                case 3: t4 = "ba"; break;
                case 4: t4 = "bon"; break;
                case 5: t4 = "nam"; break;
                case 6: t4 = "sau"; break;
                case 7: t4 = "bay"; break;
                case 8: t4 = "tam"; break;
                case 9: t4 = "chin"; break;
            }

            Console.WriteLine("{0} doc la: {1} {2} {3} {4}", n, t1, t2, t3, t4);

            Console.Read();
        }
    }
}
