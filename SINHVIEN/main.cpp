#include <iostream>
using namespace std;
class SinhVien
{
private:
    string mssv, hoTen, queQuan;
    double diem1, diem2, diem3;
    int gioiTinh;

public:
    SinhVien(string mssv = "", string hoTen = "", string queQuan = "", int gioiTinh = 1, double d1 = 0, double d2 = 0, double d3 = 0)
        : mssv(mssv), hoTen(hoTen), queQuan(queQuan), gioiTinh(gioiTinh), d1(d1), d2(d2), d3(d3)
    {
        cout << "sinh vien ham dung";
    }
}