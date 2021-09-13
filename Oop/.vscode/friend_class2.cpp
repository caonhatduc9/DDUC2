#include <iostream>
using namespace std;
//forwarding declare : khai bao truoc su dung sau
class conHeo;
class conGa
{
private:
    int m;
    friend void lamThit(conGa, conHeo);

public:
    conGa();
    conGa(int a)
    {
        m = a;
    }
};
class conHeo
{
private:
    int m;
    friend void lamThit(conGa, conHeo);

public:
    conHeo();
    conHeo(int a)
    {
        m = a;
    }
};
void lamThit(conGa g, conHeo h)
{
    if (g.m >= h.m)
        cout << "thit con ga";
    else
        cout << "thit con heo";
}
int main()
{
    conGa g(5);
    conHeo h(6);
    lamThit(g,h);
    return 0;
}