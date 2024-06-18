#include"stdio.h"
#include"mpi.h"

void main(int argc, char *argv[])
{
    MPI_Init(&argc, &argv);

    int procesador, cantidad;
    long c;
    long m1, m2, n1, n2, p, a, b, res, tam;
    MPI_Comm_rank(MPI_COMM_WORLD, &procesador);
    MPI_Comm_size(MPI_COMM_WORLD, &cantidad);

    freopen("datos.in", "r", stdin);
    freopen("datos.out", "w", stdout);

    scanf("%ld", &m1);
    scanf("%ld", &n1);
    long M1[m1][n1];

    for(long i = 0; i < m1; i++){
        for(long j = 0; j < n1; j++)
            scanf("%ld", &M1[i][j]);
    }

    scanf("%ld", &m2);
    scanf("%ld", &n2);
    long M2[m2][n2];
    for(long i = 0; i < m2; i++){
        for(long j = 0; j < n2; j++)
            scanf("%ld", &M2[i][j]);
    }

    long AUX[m1*n2];
    long I[2];//longervalo 

    if(m1 == n2){
        if(cantidad > 1 && cantidad < m1)
        {
            if(procesador == 0)
            {
                p = m1 / (cantidad - 1);//Numero de intervalos
                
                a = 0;
                b = 0;
                for(long i = 1; i < cantidad; i++)
                {
                    b = (i == (cantidad - 1)) ? m1 : b + p;
                    I[0] = a;
                    I[1] = b;
                    // int AUX[m1*b];
                    MPI_Send(I, 2, MPI_LONG, i, 0, MPI_COMM_WORLD);
                    // MPI_Send(AUX, m1*n2, MPI_LONG, i, 0, MPI_COMM_WORLD);
                    a += p;
                }

                printf("\nMatriz de dimension: %dx%d\n", m1, n1);
                for(long i = 0; i < m1; i++){
                    for(long j = 0; j < n1; j++)
                        printf("%d ", M1[i][j]);
                    printf("\n");
                }

                printf("\nMatriz de dimension: %dx%d\n", m2, n2);
                for(long i = 0; i < m2; i++){
                    for(long j = 0; j < n2; j++)
                        printf("%d ", M2[i][j]);
                    printf("\n");
                }

                printf("\n");

                printf("\n=======RESULTADO=======\n");
                printf("\nMatriz de dimension: %dx%d\n", m1, n2);
                
                for(long i = 1; i < cantidad; i++){
                    MPI_Send(AUX, m1*n2, MPI_LONG, i, 0, MPI_COMM_WORLD);
                    MPI_Recv(AUX, m1*n2, MPI_LONG, i, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                }
                
                for(long i = 0; i < m1; i++){
                    c = i * m1;
                    for(long j = 0; j < n2; j++){
                        printf("%d ", AUX[c]);
                        c++;
                    }
                    printf("\n");
                }
            }
            else
            {
                MPI_Recv(I, 2, MPI_LONG, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                MPI_Recv(AUX, m1*n2, MPI_LONG, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                for(long i = I[0]; i < I[1]; i++){
                    c = m1 * i;
                    for(long j = 0; j < m1; j++){
                        res = 0;
                        for(long k = 0; k < m1; k++){
                            res += M1[i][k] * M2[k][j];
                        }
                        AUX[c] = res;
                        c++;
                    }
                }
                MPI_Send(AUX, m1*n2, MPI_LONG, 0, 0, MPI_COMM_WORLD);
            }
        }
        else
        {
            if(procesador == 0)
            {
                printf("\n=======RESULTADO=======\n");
                printf("\nMatriz de dimension: %ldx%ld\n", m1, n2);
                for(long i = 0; i < m1; i++){
                    for(long j = 0; j < m1; j++){
                        res = 0;
                        for(long k = 0; k < m1; k++){
                            res += M1[i][k] * M2[k][j];
                        }
                        printf("%ld ", res);
                    }
                    printf("\n");
                }
            }
        }
    }
    else{
        printf("El numero de filas de la matriz A no coincide con el numero de columnas de la matriz B ...");
    }

    MPI_Finalize();
}