import cv2
from matplotlib import pyplot as plt

# ruta1: str = "img/img1.png"
# ruta2: str = "img/img2.png"
ruta1: str = "imgD.png"
ruta2: str = "imgDBorder.png"
ruta2: str = "imgM.png"

imagen1: object = cv2.imread(ruta1, 0)
imagen1: object = cv2.resize(imagen1, (500, 750))
imagen2: object = cv2.imread(ruta2, 0)
imagen2: object = cv2.resize(imagen2, (500, 750))

suma: object = cv2.addWeighted(imagen1, 0.5, imagen2, 0.5, 0)
plt.imshow(suma)
plt.title("SUMA")
plt.show()

resta: object = cv2.subtract(imagen2, imagen1)
plt.imshow(resta)
plt.title("RESTA")
plt.show()