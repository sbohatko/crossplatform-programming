#include <stdio.h>
#include <math.h>
int res, N, mas[18];
void rec(int n, int sum1, int sum2)
{
    if(n==N)
    {
        if(abs(sum1-sum2)<res)
            res=abs(sum1-sum2);
        return;
    }
    rec(n+1, sum1+mas[n], sum2);
    rec(n+1, sum1, sum2+mas[n]);
}
int main()
{
      freopen("input.txt","r",stdin);
  freopen("output.txt","w",stdout);
    res=2000000;
    int i;
    scanf("%d", &N);
    for(i=0; i<N; i++)
        scanf("%d", &mas[i]);
    rec(0,0,0);
    printf("%d\n", res);
 
return 0;
}