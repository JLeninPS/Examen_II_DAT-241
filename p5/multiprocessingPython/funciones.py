import cv2
import scipy.sparse as sp
import numpy
from multiprocessing import Pool
# from multiprocessing import Process

# global A, B

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

def multiplicar(a: int, b:int, A: list[list[int]], B: list[list[int]]) -> list[list[int]]:
    m = len(A)#Numero Filas
    n = len(B[0])#Numero Columnas
    M: list[list[int]] = [["0" for j in range(n)] for i in range(m)]

    for i in range(a, b):
        for j in range(m):
            res: int = 0
            for k in range(m):
                res += A[i][k] * B[k][j]
            M[i][j] = str(res)
    
        f = open("./multiprocessingPython/datos.out", "a")
        f.write(" ".join(M[i]) + "\n")
        f.close() 

    return M
    

def multiplicarMatrices(A: list[list[int]], B: list[list[int]], P: int) -> None:
    m1: int = len(A)#Numero de filas de A
    n2: int = len(B[0])#Numero de columnas de B

    I = [0]*2#intervalo 

    if m1 == n2: #El numero de filas de la matriz A debe coincidir con el numero de columnas de la matriz B.
        P = P if P < m1 else m1
        a: int = 0
        b: int = 0
        c: int = m1 // P #Numero de intervalos
      
        f = open("./multiprocessingPython/datos.out", "w")
        f.write("\n=======RESULTADO=======\n")
        f.write(f"\nMatriz de dimension: {m1}x{n2}\n\n")
        f.close()      
        intervalos: list[int] = [(c * i, c*i + c, A, B) for i in range(P - 1)]
        intervalos.append((intervalos[-1][1], m1, A, B))
        pool: object = Pool(P)
        M: list[list[int]] = pool.starmap(multiplicar, intervalos)
        pool.close()
        pool.join()


def main(P: int, ruta1: str, ruta2: str) -> None:

    #En el metodo imread(ruta, 0) quitamos el flag = 0
    #para evitar problemas con el metodo coo_matrix(imagen[:,1])
    imagen1: numpy.ndarray = cv2.imread(ruta1)
    imagen2: numpy.ndarray = cv2.imread(ruta2) 
    matrizSparse1: numpy.ndarray = sp.coo_matrix(imagen1[:, :, 1]).toarray()#.todense()
    matrizSparse2: numpy.ndarray = sp.coo_matrix(imagen2[:, :, 1]).toarray()#.todense()

    print(f"imagen1: {imagen1.shape}")
    print(f"imagen2: {imagen2.shape}")

    #No puede pasarse como argumetno imagen1 a pesar que ambos 
    #pertenecen a la clase numpy.ndarray
    A: list[list[int]] = generarMatriz(matrizSparse1)
    B: list[list[int]] = generarMatriz(matrizSparse2)

    # A = [[1,2,3,4], [5,6,7,8],[9,10,11,12],[13,14,15,16]]
    # B = [[1,2,3,4], [5,6,7,8],[9,10,11,12],[13,14,15,16]]
    multiplicarMatrices(A, B, P)
    # for i in A:
    #     print(i)