#include <iostream>
#include <queue>
using namespace std;
struct Node
{
    int key;
    Node *left;
    Node *right;
};

Node *createNode(int data)
{

    Node *p = new Node;
    p->key = data;
    p->left = NULL;
    p->right = NULL;
    return p;
}
int Height(Node *pRoot)
{
    if (pRoot == NULL)
        return -1;
    else
        return max(Height(pRoot->left), Height(pRoot->right)) + 1;
}
void LRotate(Node *&pRoot)
{
    Node *p = pRoot->right;
    pRoot->right = p->left;
    p->left = pRoot;
    pRoot = p;
}
void RRotate(Node *&pRoot)
{
    Node *p = pRoot->left;
    pRoot->left = p->right;
    p->right = pRoot;
    pRoot = p;
}
void balanceTree(Node *&pRoot)
{
    if (pRoot == NULL)
        return;
    int balance = Height(pRoot->left) - Height(pRoot->right);
    if (balance > 1) //mat can bang trai
    {
        if (Height(pRoot->left->left) > Height(pRoot->left->right))
            //mat can bnawg trai trai
            RRotate(pRoot);
        if (Height(pRoot->left->left) < Height(pRoot->left->right))
        {
            LRotate(pRoot->left);
            RRotate(pRoot);
        }
    }
    if (balance < -1) //mat can bang phai
    {
        if (Height(pRoot->right->left) < Height(pRoot->right->right))
            //mat can bnawg phai phai
            LRotate(pRoot);
        if (Height(pRoot->right->left) < Height(pRoot->right->right))
        {
            RRotate(pRoot->right);
            LRotate(pRoot);
        }
    }
}
void insertNode(Node *&pRoot, int x)
{
    if (pRoot == NULL)
        pRoot = createNode(x);
    if (pRoot->key == x)
        return;
    if (x < pRoot->key)
        insertNode(pRoot->left, x);
    if (x > pRoot->key)
        insertNode(pRoot->right, x);
    balanceTree(pRoot);
}
bool isAVL(Node *t)
{
    if (t == NULL)
        return true;
    if (abs(Height(t->left) - Height(t->right)) > 1)
        return false;
    return isAVL(t->left) && isAVL(t->right);
}
int main()
{
    Node *t;
    t = NULL;
    int n, x;
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        cin >> x;
        insertNode(t, x);
    }
    cout << Height(t);
}