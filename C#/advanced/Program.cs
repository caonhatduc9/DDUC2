using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ANIMAL;

namespace advanced
{
    public delegate void showLog(string msg);
    static class Abc
        {
            public static void PrintEx(this string s, ConsoleColor c)
            {
                Console.ForegroundColor = c;
                Console.WriteLine(s);
            }
        }
    class Program
    {
        //generic giong template trong C++
#region something
        static void swap<DUC>(ref DUC a, ref DUC b)
        {
            DUC t = a;
            a = b;
            b = t;
        }

        //multil Threading
        static void demoThread(string idx)
        {
            for (int i = 0; i < 5; i++)
            {
                //sleep 1 giay
                Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                Console.WriteLine(idx + "\t" + i);
            }
        }

        static void testMultilThread()
        {
            Thread t1 =
                new Thread(() =>
                    {
                        demoThread("t1");
                    });

            //de khi chuong trinh tat thi thread tat luon
            t1.IsBackground = true;
            t1.Start();

            Thread t2 =
                new Thread(() =>
                    {
                        demoThread("t2");
                    });
            t2.Start();
            {
                Thread t3 =
                    new Thread(() =>
                        {
                            demoThread("t3");
                        });
                t3.Start();
            }
        }

        static void testString()
        {
            // string a = "\\/\"cao duc\"";
            // Console.Write (a);
            int year = 2022;
            string s = $"happy new year {year}";
            Console.WriteLine (s);
        }
#endregion


        //kieu vo danh anonymous chi doc dell cho ghi
        static void anonymous()
        {
            var anms =
                new { name = "iphoe 13 promax", gia = 123456789, nam = 2022 };
            Console.WriteLine(anms.name + "\n" + anms.gia + "\n" + anms.nam);
        }

        // tao doi tuong vo danh truy van linq
        class SinhVien
        {
            public string name { get; set; }

            public int namSinh { get; set; }

            public string noiSinh { get; set; }
        }

        static void testLinq()
        {
            List<SinhVien> sv =
                new List<SinhVien>()
                {
                    new SinhVien()
                    { name = "cao nhat duc", namSinh = 2002, noiSinh = "QN" },
                    new SinhVien()
                    { name = "cao duc", namSinh = 2002, noiSinh = "QN" },
                    new SinhVien()
                    { name = "duc cao", namSinh = 2002, noiSinh = "QN" },
                    new SinhVien()
                    { name = "duc", namSinh = 2007, noiSinh = "QN" }
                };
            var kq =
                from s in sv
                where s.namSinh < 2005
                select new { ten = s.name, ns = s.namSinh };
            foreach (var SinhVien in kq)
            {
                Console.WriteLine(SinhVien.ten + "\t" + SinhVien.ns);
            }
        }
        //quy tac dat ten interface: bat dau bang chu I
        interface IHinhHoc
        {
            public double tinhChuvi();
            public double tinhDienTich();
        }
        class HinhChuNhat : IHinhHoc
        {
            public double a { get; set; }
            public double b { get; set; }
            public HinhChuNhat(double a, double b)
            {
                this.a = a;
                this.b = b;
            }

            public double tinhChuvi()
            {
                return 2 * (a + b);
            }

            public double tinhDienTich()
            {
                return a * b;
            }
        }
        static void testInterface()
        {
            HinhChuNhat h = new HinhChuNhat(4, 5);
            Console.WriteLine($"Dien tich: {h.tinhDienTich()}\nChu vi: {h.tinhChuvi()}");
        }
        // delegate (type) bien = phuong thuc : giong con tro trong C++
        static void infor(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void testDelegate(){
            showLog log = null;
         //   log = infor;
            // cach 1
         //   log("\n\tDUC CAO");
            //cach 2 de thi hanh
            log?.Invoke("invoke DUC CAO");
        }
        //phuong thuc mo rong
        /// <summary>
        /// phai tao static class
        /// </summary>
        static void testExtensionMethod()
        {
            string s = " CAO NHAt DUC";
            s.PrintEx(ConsoleColor.Red);
        }
        static void Main(string[] args)
        {
            // testMultilThread();
            // testString();
            // Cat cat = new Cat();
            // cat.showFood();
            // cat.showInfor();
            //  anonymous();
            // testDelegate();
            testExtensionMethod();

        }
    }
}
