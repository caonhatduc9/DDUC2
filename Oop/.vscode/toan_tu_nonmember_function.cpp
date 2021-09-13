#include <iostream>
using namespace std;
// cach 1 su dung member function
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
    void output()
    {
        cout << tu << "/" << mau;
    }
    int layTu()
    {
        return tu;
    }
    int layMau()
    {
        return mau;
    }
    void thayDoiTu(int a)
    {
        tu = a;
    }
    void thayDoiMau(int a)
    {
        mau = a;
    }
    phanSo operator+(phanSo);
    phanSo operator+(int);

};
//nonmember function
void operator-(phanSo &p)
{
    p.thayDoiTu(-p.layTu());
}
phanSo operator+(int a, phanSo ps)
{
    phanSo temp;
    temp.thayDoiTu(a * ps.layMau() + ps.layTu());
    temp.thayDoiMau(ps.layMau());
    return temp;
}
phanSo phanSo::operator+(phanSo ps)
{
    phanSo temp;
    temp.tu = tu * ps.mau + ps.tu * mau;
    temp.mau = mau * ps.mau;
    return temp;
}
phanSo phanSo::operator+(int k)
{
    phanSo temp;
    temp.tu = k * mau + tu;
    temp.mau = mau;
    return temp;
}
int main()
{
    phanSo ps(1, 2), ps2(3, 5), ps1;
    ps.output();
    -ps;
    ps1 = 3 + ps2;
    ps1.output();
    return 0;
}