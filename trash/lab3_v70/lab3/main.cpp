//
//  main.cpp
//  lab3
//
//  Created by Alex Bogatko on 26.10.2022.
//
#include <fstream>
#include <iostream>
#include <vector>

using namespace std;

enum napr {
       UR = 0,
       UL,
       DL,
       DR
};

char a[102][102];


void ray(int z, int x, napr napr) {
       switch (napr){
       case UR: {
             if (a[z - 1][x + 1] == '.' && (a[z-1][x] !='*' || a[z][x+1]!='*')) {
                    a[z - 1][x + 1] = '/';
                    ray(z - 1, x + 1, UR);
                    break;
             }
             if (a[z - 1][x + 1] == '\\' && (a[z - 1][x] != '*' || a[z][x + 1] != '*')) {
                    a[z - 1][x + 1] = 'X';
                    ray(z - 1, x + 1, UR);
                    break;
             }
             if (a[z - 1][x + 1] == '*' && a[z][x + 1] == '*' && a[z - 1][x] == '.') {
                    a[z - 1][x] = '\\';
                    ray(z - 1, x, UL);
                    break;
             }
             if (a[z - 1][x + 1] == '*' && a[z][x + 1] == '*' && a[z - 1][x] == '/') {
                    a[z - 1][x] = 'X';
                    ray(z - 1, x, UL);
                    break;
             }
             if (a[z - 1][x] == '*' && a[z-1][x + 1] == '*' && a[z][x+1] == '.') {
                    a[z][x+1] = '\\';
                    ray(z, x + 1, DR);
                    break;
             }
             if (a[z - 1][x] == '*' && a[z - 1][x + 1] == '*' && a[z][x + 1] == '/') {
                    a[z][x+1] = 'X';
                    ray(z, x + 1, DR);
                    break;
             }
           return;
       }
       case DR: {
             if (a[z + 1][x + 1] == '.' && (a[z + 1][x] != '*' || a[z][x + 1] != '*')) {
                    a[z + 1][x + 1] = '\\';
                    ray(z + 1, x + 1, DR);
                    break;
             }
             if (a[z + 1][x + 1] == '/' && (a[z + 1][x] != '*' || a[z][x + 1] != '*')) {
                    a[z + 1][x + 1] = 'X';
                    ray(z + 1, x + 1, DR);
                    break;
             }
             if (a[z + 1][x + 1] == '*' && a[z+1][x] == '*' && a[z][x+1] == '.') {
                    a[z][x+1] = '/';
                    ray(z, x+1, UR);
                    break;
             }
             if (a[z + 1][x + 1] == '*' && a[z+1][x] == '*' && a[z][x+1] == '\\') {
                    a[z][x+1] = 'X';
                    ray(z, x+1, UR);
                    break;
             }
             if (a[z + 1][x+1] == '*' && a[z][x + 1] == '*' && a[z+1][x] == '.') {
                    a[z+1][x] = '/';
                    ray(z+1, x, DL);
                    break;
             }
             if (a[z + 1][x + 1] == '*' && a[z][x + 1] == '*' && a[z + 1][x] == '\\') {
                    a[z + 1][x] = 'X';
                    ray(z+1, x, DL);
                    break;
             }
             return;
       }
       case UL: {
             if (a[z - 1][x - 1] == '.' && (a[z - 1][x] != '*' || a[z][x - 1] != '*')) {
                    a[z - 1][x - 1] = '\\';
                    ray(z - 1, x - 1, UL);
                    break;
             }
             if (a[z - 1][x - 1] == '/' && (a[z - 1][x] != '*' || a[z][x - 1] != '*')) {
                    a[z - 1][x - 1] = 'X';
                    ray(z - 1, x - 1, UL);
                    break;
             }
             if (a[z - 1][x - 1] == '*' && a[z - 1][x] == '*' && a[z][x - 1] == '.') {
                    a[z][x - 1] = '/';
                    ray(z, x - 1, DL);
                    break;
             }
             if (a[z - 1][x - 1] == '*' && a[z - 1][x] == '*' && a[z][x - 1] == '\\') {
                    a[z][x - 1] = 'X';
                    ray(z, x - 1, DL);
                    break;
             }
             if (a[z - 1][x - 1] == '*' && a[z][x - 1] == '*' && a[z - 1][x] == '.') {
                    a[z - 1][x] = '/';
                    ray(z-1, x, UR);
                    break;
             }
             if (a[z - 1][x - 1] == '*' && a[z][x - 1] == '*' && a[z - 1][x] == '\\') {
                    a[z - 1][x] = 'X';
                    ray(z-1, x, UR);
                    break;
             }
             return;
       }
       case DL: {
             if (a[z + 1][x - 1] == '.' && (a[z + 1][x] != '*' || a[z][x - 1] != '*')) {
                    a[z + 1][x - 1] = '/';
                    ray(z + 1, x - 1, DL);
                    break;
             }
             if (a[z + 1][x - 1] == '\\' && (a[z + 1][x] != '*' || a[z][x - 1] != '*')) {
                    a[z + 1][x - 1] = 'X';
                    ray(z + 1, x - 1, DL);
                    break;
             }
             if (a[z][x - 1] == '*' && a[z + 1][x - 1] == '*' && a[z + 1][x] == '.') {
                    a[z + 1][x] = '\\';
                    ray(z + 1, x, DR);
                    break;
             }
             if (a[z][x - 1] == '*' && a[z + 1][x - 1] == '*' && a[z + 1][x] == '/') {
                    a[z + 1][x] = 'X';
                    ray(z + 1, x, DR);
                    break;
             }
             if (a[z + 1][x] == '*' && a[z + 1][x - 1] == '*' && a[z][x - 1] == '.') {
                    a[z][x-1] = '\\';
                    ray(z, x-1, UL);
                    break;
             }
             if (a[z + 1][x] == '*' && a[z + 1][x - 1] == '*' && a[z][x - 1] == '/') {
                    a[z][x-1] = 'X';
                    ray(z, x-1, UL);
                    break;
             }
       }
       default: return;
       }
       return;
}

using namespace std;

int main() {
       ifstream in("input.txt");
       ofstream out("output.txt");
        out.clear();
       int n, m;
       in >> n >> m;
       for (int z = 0; z < 2 + n; z++) a[z][0] = a[z][m + 1] = '*';
       for (int z = 0; z < 2 + m; z++) a[0][z] = a[n + 1][z] = '*';
       int Xz, Xx;
       for (int z = 1; z < 1 + n; z++)
             for (int x = 1; x < 1 + m; x++) {
                    in >> a[z][x];
                    if (a[z][x] == 'X') {
                           Xz = z;
                           Xx = x;
                    }
             }
       ray(Xz, Xx, UR);
       ray(Xz, Xx, UL);
       ray(Xz, Xx, DL);
       ray(Xz, Xx, DR);

       for (int z = 1; z < 1 + n; z++) {
             for (int x = 1; x < 1 + m; x++) out << a[z][x];
             out << '\n';
       }
}
