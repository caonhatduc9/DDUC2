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
    void output()
    {
        cout << tu << "/" << mau;
    }
    void operator-();
};
void phanSo::operator-()
{
    tu=-tu;
}
int main(){
    phanSo ps(1,2);
    -ps;
    ps.output();
    return 0;
}