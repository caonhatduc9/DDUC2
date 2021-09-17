
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
/*
truyền tham chiếu: thêm <out> hoặc <ref>
+ref: bắt buộc phải khởi tạo giá trị cho biến trước khi vòa hàm
+out: bắt buộc phải gán giá trị cho biến trước khi ra khỏi hàm

*/


using System.Text;
// dotnet new console -0 MYAPP
using System;

namespace C_
{
    class Program
    {
        static void demoRef(out int a)
        {
            a = 0;
            a += 2;
        }
        static void testDataTime()
        {
            DateTime d = new DateTime(2002, 07, 10);
            Console.WriteLine(d.ToString("MM/dd/yyyy"));


        }
        static void xuLyChuoi()
        {
            string s;
            Console.Write("nhap chuoi: ");
            s = Console.ReadLine();
            Console.Write("nhap chuoi tiep theo:  ");
            string s2 = Console.ReadLine();
            int kq = s.CompareTo(s2);
            Console.WriteLine(kq);
        }
        static void xuLyChuoi2()
        {
            string s = string.Format("{0:dd/MM/yyyy ss:mm:HH}", DateTime.Now);
            Console.WriteLine(s);
        }
        static void testArray()
        {
            Console.Write("enter volumn: ");
            int n = int.Parse(Console.ReadLine());
            Random rd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rd.Next(10);
            int[] b = new int[a.Length];
            // coppy tu vi tri 0
            a.CopyTo(b, 0);
            // coppy2
            // Array.Copy(a,b,a.Length);
            //coppy 3
            //  b = (int[])a.Clone();
            Console.WriteLine("origin array");
            for (int i = 0; i < b.Length; i++)
                Console.Write("{0}\t", b[i]);
            Array.Sort(b);
            Console.WriteLine("\nSORTED:");
            for (int i = 0; i < b.Length; i++)
                Console.Write("{0}\t", b[i]);
            Array.Clear(a, 0, a.Length);
        }
        static void testList()
        {
            List<int> a = new List<int>();
        }
        static void testArray2D()
        {
            Console.Write("enter row: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("enter col: ");
            int c = int.Parse(Console.ReadLine());
            int[,] a = new int[d, c];
            Random rd = new Random();
            for (int i = 0; i < d; i++)
                for (int j = 0; j < c; j++)
                    a[i, j] = rd.Next(10);
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static void testDictionary()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Cao Nhat Duc");
            if(!dic.ContainsKey(2))
                dic.Add(2, "Tran Thao Quyen");
            foreach (KeyValuePair<int, string> item in dic)
                Console.WriteLine("Ma = " + item.Key + "; ten = " + item.Value);

        }
        static void Main(string[] args)
        {//go tieng viet
         // Console.OutputEncoding = Encoding.UTF8;
         // int x = int.Parse(Console.ReadLine());
         // int y = 100;
         // Console.WriteLine(y);
         //Console.WriteLine(DateTime.Now);
         // int a = -5;
         // demoRef(out a);
         // Console.Write(a);
         //random
         //  Random rd = new Random();
         //int z = rd.Next(10);
         //khoi tao tu 0 den tiem can 1
         //   double z1 = rd.NextDouble();
         //   Console.WriteLine(z1 + z);
         //  testDataTime();
            testDictionary();
        }
    }
}
