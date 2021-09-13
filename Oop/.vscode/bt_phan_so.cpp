/*


*/
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
    void input()
    {
        cout << "nhap tu: ";
        cin >> tu;
        cout << "nhap mau: ";
        cin >> mau;
    }
    void output()
    {
        cout << tu << "/" << mau;
    }
    phanSo tong(phanSo ps)
    {
        phanSo result;
        result.tu = tu * ps.mau + ps.tu * mau;
        result.mau = mau * ps.mau;
        return result;
    }
    // ~phanSo()
    // {
    //     cout << "\n this is destructor";
    // }
};
int main()
{
    phanSo ps1(2, 5), ps2(2, 7), ps3;
    ps3 = ps1.tong(ps2);
    ps3.output();
    return 0;
}