import numpy
def generarMatriz(A: numpy.ndarray) -> list[list[int]]:
    m = len(A)#Numero Filas
    n = len(A[0])#Numero Columnas
    M: list[list[int]] = [[0 for j in range(n)] for i in range(m)]
  
    for i in range(len(A)):
        for j in range(len(A[i])):
            if(A[i][j] == 255):
                M[i][j] = 0
            else:
                M[i][j] = 1
    return M

def multiplicarMatrices(A: list[list[int]], B: list[list[int]]) -> list[list[int]]:
    m = len(A)#Numero Filas
    n = len(A[0])#Numero Columnas
    M: list[list[int]] = [[0 for j in range(n)] for i in range(m)]
    for i in range(m):
        for j in range(m):
            res: int = 0
            for k in range(m):
                res += A[i][k] * B[k][j]
            M[i][j] = str(res)
    
    return M