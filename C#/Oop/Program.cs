using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System;

namespace Oop
{
    public class SinhVien
    {
        #region cac bien lop
        private int id;
        private string name;
        private DateTime birthday;
        #endregion
        public SinhVien()
        {
            id = 1;
            name = "abc";
        }
        public SinhVien(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        private bool isBirthday()
        {
            return (DateTime.Now.Year - birthday.Year >= 17);

        }
        public void outputInfor()
        {
            if (!isBirthday())
                Console.WriteLine("nam sinh khong hop le");
            else
                Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return this.id + "\t" + this.name;
        }
    }
    public class Triangle
    {
        private int edge1;
        private int edge2;
        private int edge3;

        private bool isTriangle()
        {
            if (edge1 + edge2 > edge3 && edge1 + edge3 > edge2 && edge2 + edge3 > edge1 && edge1 > 0 && edge2 > 0 && edge3 > 0)
                return true;
            return false;
        }
        public Triangle()
        {
            edge1 = edge2 = edge3 = 0;
        }
        public Triangle(int e1, int e2, int e3)
        {
            edge1 = e1;
            edge2 = e2;
            edge3 = e3;
        }
        public int Edge1
        {
            get
            {
                return edge1;
            }
            set
            {
                edge1 = value;
            }
        }
        public int Edge2
        {
            get
            {
                return edge2;
            }
            set
            {
                edge2 = value;
            }
        }
        public int Edge3
        {
            get
            {
                return edge3;
            }
            set
            {
                edge3 = value;
            }
        }
        public int chuVi()
        {
            if (!isTriangle())
                return -1;
            else
                return edge1 + edge2 + edge3;
        }
        public override string ToString()
        {
            return "canh thu nhat: " + edge1 + "\ncanh thu hai: " + edge2 + "\ncanh thu ba: " + edge3;
        }
    }
    public class KhachHang
    {
        public int Ma;// { get; set; }
        public string ten { get; set; }
        public string phone { get; set; }
    }
    class Program
    {
        static void testSV()
        {
            SinhVien sv = new SinhVien();
            // Console.WriteLine(sv);
            sv.Id = 01;
            sv.Name = "Cao Nhat Duc";
            Console.WriteLine(sv);
            SinhVien sv2 = new SinhVien(2, "Tran Thao Quyen");
            sv2.Birthday = new DateTime(2005, 12, 23);
            sv2.outputInfor();
        }
        static void testTrianle()
        {
            Triangle t1 = new Triangle(4, 2, 5);
            Console.WriteLine(t1);
            t1.Edge1 = 2;
            //neu dang sau dau + khong phai string thi ne de .toString()
            Console.WriteLine("chu vi: " + t1.chuVi().ToString());
        }
        static void testKH()
        {
            List<KhachHang> k = new List<KhachHang>();
            k.Add(new KhachHang() { Ma = 1, ten = "duc cao", phone = "0979203485" });
            foreach (KhachHang kh in k)
                Console.WriteLine(kh.Ma + " " + kh.ten + " " + kh.phone);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // testTrianle();
            testKH();
             
        }
    }
}
