// type nul > ten tep tin => tạo tep tin bằng cmd
using System;
namespace ANIMAL{
     class Animal
        {
            //neu khai bao private thi lop ke thua khongtruy cap duoc
            //protected thi lop ke thua truy cap duocj nhung ben ngoai khong duoc
            //public thi all truy cap duoc
            // them sealed dang truoc Animal thi lop Cat khong the ke thua duoc nua
            public int leg { get; set; }

            public int height { get; set; }

            public Animal()
            {
                Console.WriteLine("khoi tao animal");
            }
            public void showLeg()
            {
                Console.WriteLine($"leg:  {leg}");
            }
        }

        class Cat : Animal
        {
            public string food;

            public Cat() : base()
            {
                this.leg = 4;
                this.food = "mouse";
            }

            public void showFood()
            {
                Console.WriteLine (food);
            }

            public void showInfor()
            {
                base.showLeg();
            }
        }

}