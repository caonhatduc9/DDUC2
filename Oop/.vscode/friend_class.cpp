#include <iostream>
using namespace std;
class rectangular
{
private:
    float d, r;

public:
    friend float dienTich(rectangular);
    rectangular();
    rectangular(float x, float y)
    {
        d = x;
        r = y;
    }
};

float dienTich(rectangular h)
{
    return h.d * h.r;
}
int main()
{
    rectangular h1(2, 3);
    cout << dienTich(h1);
}