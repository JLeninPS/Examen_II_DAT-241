import cv2
import scipy.sparse as sp
import numpy
import funciones
#nomina = salario

# ruta1: str = "spiderman.png"
# ruta2: str = "blueRay.png"
ruta1: str = "img_30px.png"
ruta2: str = "img_30px.png"

#En el metodo imread(ruta, 0) quitamos el flag = 0
#para evitar problemas con el metodo coo_matrix(imagen[:,1])
imagen1: numpy.ndarray = cv2.imread(ruta1)
imagen2: numpy.ndarray = cv2.imread(ruta2) 
matrizSparse1: numpy.ndarray = sp.coo_matrix(imagen1[:, :, 1]).toarray()#.todense()
matrizSparse2: numpy.ndarray = sp.coo_matrix(imagen2[:, :, 1]).toarray()#.todense()


print(f"imagen1: {imagen1.shape}")
print(f"imagen2: {imagen2.shape}")

# A = np.array(matrizSparse1)
# B = np.array(matrizSparse2)
# C = np.dot(A, B)

# print(type(matrizSparse1))

#No puede pasarse como argumetno imagen1 a pesar que ambos 
#pertenecen a la clase numpy.ndarray
A: list[list[int]] = funciones.generarMatriz(matrizSparse1)
B: list[list[int]] = funciones.generarMatriz(matrizSparse2)

# A=[[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]
# B=[[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]

C: list[list[int]] = funciones.multiplicarMatrices(A, B)

f = open("datos.out", "w")

for i in C:
    f.write(" ".join(i) + "\n")

f.close()



# cv2.imshow(ruta, imagen)
# # Wait for the user to press a key
# cv2.waitKey(0)
# # Close all windows
# cv2.destroyAllWindows()