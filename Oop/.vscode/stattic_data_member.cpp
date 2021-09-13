/*
các đặc tính chính:
+một bản duy nhất tồn tại trong suốt quá trình chạt của chương trình
+dùng chung cho tất cả các đối tượng của lớp. Bất kể có bao nhiêu đố tượng được tạo từ class đó.
+phải được đinh nghĩa từ bên ngoài class vì thành viên tĩnh được lưu trữ riếng biệt không giống như các thành phần khác của đối tượng.
+giá trị khởi tạo bằng = và có thể gán giá trị khởi tạo.
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
    //ham xem gia tri bien dem
    int showvar()
    {
        return this->dem;
    }
    ~phanSo()
    {
        cout << "\n this is destructor";
    }
};
int phanSo::dem; //mac dinh co gia tri = 0
int main()
{
    phanSo ps(5, 6), ps2(3, 5);
    cout << "so luong phan so hien tai:"<<ps.showvar();
    //hoac cung co the goi thu cong
    // ps.~phanSo();

    return 0;
}