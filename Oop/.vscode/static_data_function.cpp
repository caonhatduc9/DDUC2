/*
+phuoneg thuc tinh CHỈ  có thể truy cập thành viên tĩnh(thuộc tính hoặc phương thức tĩnh khác)
+một phuong thức tĩnh có thể đưcọ gọi qua tên class ngay khi không có đối tượng nào của lớp đó tồn tại


*/
#include <iostream>
using namespace std;
class phanSo
{
private:
    //khai bao thanh phan static
    static int dem;
    int tu, mau;

public:
    phanSo()
    {
        tu = 0;
        mau = 1;
    }
    //truyen vao 2 tham so
    phanSo(int t, int m)
    {
        tu = t;
        mau = m;
        dem++;
    }
    // ham xem gia tri bien dem
    // int showvar()
    // {
    //     return this->dem;
    // }
    static int showVar()
    {
            return dem;
    } 
    ~phanSo()
    {
        cout << "\n this is destructor";
    }
};
int phanSo::dem; //mac dinh co gia tri = 0
int main()
{
   //co the goi khi chua khoi tao
   cout<<phanSo::showVar();
    return 0;
}