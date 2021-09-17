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
    friend phanSo operator+(int, phanSo);
    phanSo operator+(int);
    friend istream &operator>>(istream &, phanSo &);
    friend ostream &operator<<(ostream &, phanSo);
};
//nonmember function
void operator-(phanSo &p)
{
    p.thayDoiTu(-p.layTu());
}
phanSo operator+(int a, phanSo ps)
{
    phanSo temp;
    temp.tu = a * ps.mau + ps.tu;
    temp.mau = ps.mau;
    return temp;
}
phanSo phanSo::operator+(int k)
{
    phanSo temp;
    temp.tu = k * mau + tu;
    temp.mau = mau;
    return temp;
}
//nonmember function IO
// istream &operator>>(istream &in, phanSo &ps)
// {
//     int a, b;
//     cout << "nhap tu: ";
//     in >> a;
//     cout << "nhap mau: ";
//     in >> b;
//     ps = phanSo(a, b);
//     return in;
// }
// ostream &operator<<(ostream &out, phanSo ps)
// {
//     return out << ps.layTu() << "/" << ps.layMau();
// }
//ham friend
istream &operator>>(istream &in, phanSo &ps)
{

    cout << "nhap tu: ";
    in >> ps.tu;
    cout << "nhap mau: ";
    in >> ps.mau;
    return in;
}
ostream &operator<<(ostream &out, phanSo ps)
{
    return out << ps.tu << "/" << ps.mau;
}

int main()
{
    phanSo ps(1, 2), ps2(3, 5), ps1;
    cin >> ps1;
    cout << ps1;
    return 0;
}