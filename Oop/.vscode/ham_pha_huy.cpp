//destructor được gọi ngay trước khi đối tượng bị thu hồi
//+thường được  dùng để thực hiện việc dọn dẹp cần thiets trước khi một đối tượng bị hủy
//+một lớp chỉ có duy nhất một destructor
//+phương thức destructor trùng tên với tên class nhưng có dấu ~ đặt trước
//+được tự động gọi thực hiện khi đối tượng hết phạm  vi sử dụng
//+destructor có thuộc tính public
#include <iostream>
using namespace std;
class phanSo
{
private:
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
    }
    ~phanSo()
    {
        cout << "\n this is destructor";
    }
};
int main()
{
    phanSo ps;
    //hoac cung co the goi thu cong
    ps.~phanSo();
    
    return 0;
}