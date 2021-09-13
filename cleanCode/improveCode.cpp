#include <iostream>
using namespace std;
void improveSwap(int &a, int &b)
{
    a ^= b ^= a ^= b;
}
int main()
{
    int a = 5, b = 6;
    improveSwap(a, b);
    cout << a << b;
    return 0;
}