/*
su dung getter de lay
setter de thay doi
*/
#include <iostream>
using namespace std;
// cach 1 su dung member function
class phanSo
{
private:
    int tu, mau;

public:
    //getter
    int layTu()
    {
        return tu;
    }
    int layMau()
    {
        return mau;
    }
    //setter
    void thayDoiTu(int a)
    {
        tu = a;
    }
    void thayDoiMau(int a)
    {
        mau = a;
    }
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
    void operator-();
};
void phanSo::operator-()
{
    tu = -tu;
}
int main()
{
    phanSo ps(1, 2);
    cout<<ps.layTu();
    ps.thayDoiMau(5);
    ps.output();
    return 0;
}