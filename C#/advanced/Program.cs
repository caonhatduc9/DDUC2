using System.Drawing;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.IO;//lam viec voi o dia
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
    class PhanSo
    {
        private int tu;
        private int mau;
        public PhanSo(int tu, int mau)
        {
            this.tu = tu;
            this.mau = mau;
        }
        public void show()
        {
            Console.WriteLine($"{tu}/{mau}");
        }
        //phanso <= phanso + phanSo
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau);
        }
        public static PhanSo operator +(PhanSo a, int b)
        {
            return new PhanSo(a.tu + b * a.mau, a.mau);
        }
        public static PhanSo operator +(int b, PhanSo a)
        {
            return new PhanSo(a.tu + b * a.mau, a.mau);
        }
        //indexer
        public int this[int i]
        {
            set
            {
                if (i == 0)
                    tu = value;
                else if (i == 1)
                    mau = value;
                else
                    throw new Exception("sai index");
            }
            get
            {
                if (i == 0)
                    return tu;
                else if (i == 1)
                    return mau;
                else
                    throw new Exception("sai index");
            }
        }
    }
 class Product
        {
            public int id { set; get; }
            public double price { set; get; }
            public string name { set; get; }
       public  void save(Stream stream)
        {
            //int -> 4byte
            var byteId = BitConverter.GetBytes(id);
            stream.Write(byteId, 0, sizeof(int));
            var bytePrice = BitConverter.GetBytes(price);
            stream.Write(bytePrice, 0, sizeof(double));
            var byteName = Encoding.UTF8.GetBytes(name);
            var byteLength = BitConverter.GetBytes(byteName.Length);
            stream.Write(byteLength, 0, byteLength.Length);
            stream.Write(byteName, 0, byteName.Length);

        }
       public void restore(Stream stream)
            {
            var byteId = new byte[4];
            stream.Read(byteId, 0, 4);
            id = BitConverter.ToInt32(byteId, 0); 

            var bytePrice = new byte[8];
            stream.Read(bytePrice, 0, 8);
            price = BitConverter.ToDouble(bytePrice, 0);

            var byteLeng = new byte[4];
            stream.Read(byteLeng, 0, 4);
            int leng = BitConverter.ToInt32(byteLeng, 0);
            var byteName = new byte[leng];
            stream.Read(byteName, 0, leng);
            name = Encoding.UTF8.GetString(byteName, 0, leng);



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
            Console.WriteLine(s);
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
        static void testDelegate()
        {
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
        //test qua tai toan tu
        static void testOperator()
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(3, 4);
            PhanSo c = new PhanSo(3, 4);
            c = 1 + b + 1;
            c.show();

        }
        static void testIndexer()
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(3, 4);
            a[0] = 9;
            Console.WriteLine(a[0]);
            Console.WriteLine(a[1]);
            Console.WriteLine(a[3]);
        }
        //test o dia ghi doc file
        static void testDrive()
        {
            //   DriveInfo drive = new DriveInfo("Z");
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine($"name drive: {drive.Name}");
                Console.WriteLine($"Drive Type: {drive.DriveType}");
                Console.WriteLine($"label drive: {drive.VolumeLabel}");
                Console.WriteLine($"format drive: {drive.DriveFormat}");
                Console.WriteLine($"size drive: {drive.TotalSize}");
                Console.WriteLine($"free drive: {drive.TotalFreeSpace}");
                Console.WriteLine("-------------------");

            }


        }
        static void testDirectory()
        {
            string path = "testDirectory";
            // tao thu muc
            Directory.CreateDirectory(path);
            if (Directory.Exists(path))
                Console.WriteLine(path + " ton tai");
            else
                Console.WriteLine(path + " khong ton tai");
            // lay cac file ben trong thu muc
            var files = Directory.GetFiles("obj");
            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
            // noi chuoi duong dan thu muc
            Console.WriteLine(Path.DirectorySeparatorChar);
            var path1 = Path.Combine("d1", "d2", "duc.txt");
            // doi phan duoi file
            path1 = Path.ChangeExtension(path1, "doc");
            Console.WriteLine(path1);
            Console.WriteLine(Path.GetFullPath(path1));

        }
        static void testFile()
        {
            string fileName = "duc.txt";
            string content = " TRan Thao Quyen";
            File.WriteAllText(fileName, content);
            // them noi dung vao file khonflam mat noi dung cu
            File.AppendAllText(fileName, content);
        }
        static void testFileStream()
        {
          //  string path1 = "duc.txt";
          // using var stream = new FileStream(path: path1, FileMode.Open);
          //luu tru
          // byte[] buffer = { 12, 13, 14 };
          // int offset = 0;
          // int count = 3;
          // stream.Write(buffer, 0, 3);
          // //doc file
          // int soByteDocDuoc = stream.Read(buffer, offset, count);
          // //convert int,double -> byte
          // int i = 1;
          // var byteI = BitConverter.GetBytes(i);
          // //byte to double,int
          // BitConverter.ToInt32(byteI, 0);
          // //string to byte
          // string s = "cao nhat duc";
          // var byteString = Encoding.UTF8.GetBytes(s);
          // //byte to string
          // Encoding.UTF8.GetString(byteString, 0, 15);
               string path1 = "duc.txt";
             using var stream = new FileStream(path: path1, FileMode.Open);
            Product p = new Product();
            // {
            //     id = 10,
            //     price = 10000,
            //     name = "iphone 13 promax"
            // };
             //    p.save(stream);
            
            p.restore(stream);
            Console.WriteLine($"id: {p.id}\nprice: {p.price}\nname: {p.name}");
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
            //testExtensionMethod();
            // testOperator();
            //testIndexer();
            //testDrive();
            // testDirectory();
            //testFile();
            testFileStream();
        }
    }
}
