import cv2
import scipy.sparse as sp
import sys
#nomina = salario

ruta: str = "img_30px.png"

imagen: object = cv2.imread(ruta)
matrizDensa: list[list] = sp.coo_matrix(imagen[:, :, 1]).toarray()

m: int = imagen.shape[0]#Filas
n: int = imagen.shape[1]#Columnas
matriz: list[list[int]] = [[0 for i in range(m)] for j in range(n)]
# print(matriz)
l: int = 0
for  i in range(m):
    for j in range(n):
        color = matrizDensa[i][j]
        if color != 255:
            matriz[i][j] = 1
            l += 1

mSparse: list[list[int]] =  [[0 for i in range(l)] for j in range(3)]
pos: int = 0
for i in range(m):
    for j in range(n):
        if matriz[i][j] == 1:
            mSparse[0][pos] = str(i)
            mSparse[1][pos] = str(j)
            mSparse[2][pos] = "1"
            pos += 1

print("x\ty\tval")
for i in range(l):
    print(f'{mSparse[0][i]}\t{mSparse[1][i]}\t{mSparse[2][i]}')
# for fila in mSparse:
#     print(" ".join(fila))