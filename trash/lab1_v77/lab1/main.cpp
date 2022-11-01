//
//  main.cpp
//  lab1
//
//  Created by Alex Bogatko on 27.10.2022.
//

#include <iostream>
#include <fstream>

int n, k, m[10];

void show() {for (int i=0; i<n; i++) if (m[i]>=0) std::cout<<char('a'+i)<<(m[i]+1)<<'\t'; std::cout<<'\n';}
 
bool tst(int i, int t, int p) {
    int x=i-p, y=t-m[p]; x*=x; y*=y;
    return t<0 || p==i || ((m[p]<0 || (y!=0 && x!=y && x+y!=5)) && tst(i,t,p+1)); }
 
void f(int i, int j) {
    if (i==n) { if (j==k) show(); return; }
    for (int t=-1; t<(j==k ? 0 : n); t++) if (tst(i,t,0)) { m[i]=t; f(i+1, j+(t>=0)); } }
 
int main(int argc, char * argv[]) {
    // insert code here...
    std::fstream myfile("input.txt", std::ios_base::in);

        float a;
        while (myfile >> a)
        {
            printf("%f ", a);
        }

        getchar();

        return 0;
    
    std::cin >> n >> k;
    f(0, 0);
    return 0;
}
