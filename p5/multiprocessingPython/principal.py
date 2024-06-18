import sys
import multiprocessing
from funciones import main

if __name__ == '__main__':

    PROCESADORES: int = multiprocessing.cpu_count()
    sys.stdout.write("\nUsted cuenta con " + str(PROCESADORES) + " Procesadores.")  
    sys.stdout.write("\n¿Cuantos desea usar?: ")
   
    P: int = int(sys.stdin.readline())
    #Validando uso de procesadores
    P = P if (P < PROCESADORES and P > 0) else PROCESADORES  
    
    # ruta1: str = "./img/spiderman.png"
    # ruta2: str = "./img/blueRay.png"
    # ruta1: str = "./img/img_30px.png"
    # ruta2: str = "./img/img_30px.png"
    ruta1: str = "./img/img30x40.png"
    ruta2: str = "./img/img50x30.png"

    main(P, ruta1, ruta2)


