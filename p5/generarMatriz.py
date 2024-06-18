import cv2
import scipy.sparse as sp
import sys
#nomina = salario

# ruta1: str = "./img/img_30px.png"
# ruta2: str = "./img/img_30px.png"

ruta1: str = "./img/img30x40.png"
ruta2: str = "./img/img50x30.png"

# ruta1: str = "./img/spiderman.png"
# ruta2: str = "./img/blueRay.png"

imagen1: object = cv2.imread(ruta1)
imagen2: object = cv2.imread(ruta2)
matrizSparse1: list[list] = sp.coo_matrix(imagen1[:, :, 1]).toarray()
matrizSparse2: list[list] = sp.coo_matrix(imagen2[:, :, 1]).toarray()

nomArchivo1: str = ruta1
n = 1
f = open("./datos.in", "w")
f.write(f"{imagen1.shape[0]//n} {imagen1.shape[1]//n}\n\n")
for i in range(len(matrizSparse1) // n):
    for j in range(len(matrizSparse1[i]) // n):
        if(matrizSparse1[i][j] == 255):
            f.write("0 ")
        else:
            f.write("1 ")
    f.write("\n")

f.write("\n")

f.write(f"{imagen2.shape[0]//n} {imagen2.shape[1]//n}\n\n")
for i in range(len(matrizSparse2)//n):
    for j in range(len(matrizSparse2[i])//n):
        if(matrizSparse2[i][j] == 255):
            f.write("0 ")
        else:
            f.write("1 ")
    f.write("\n")

f.close()