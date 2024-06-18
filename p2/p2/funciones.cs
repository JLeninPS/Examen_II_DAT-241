using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2
{
    internal class funciones
    {
        public static int[, ] matrizSparse(Bitmap bmp)
        {
            int m, n, l, pos;
            Color color = new Color();

            m = bmp.Height;//Filas
            n = bmp.Width;//Columnas
            int[,] matriz = new int[m, n];
            l = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    color = bmp.GetPixel(i, j);
                    if (color.R == 0 && color.G == 0 && color.B == 0)
                    {
                        matriz[i, j] = 1;
                        l++;
                    }

                }
            }
            int[,] mSparse = new int[3, l];
            pos = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matriz[i, j] == 1)
                    {
                        mSparse[0, pos] = i;
                        mSparse[1, pos] = j;
                        mSparse[2, pos] = 1;
                        pos++;
                    }
                }
            }

            return mSparse;
        }

        public static int[,] sumarMatricesSparse(Bitmap bmp1, Bitmap bmp2)
        {
            int[,] mSparse1 = funciones.matrizSparse(bmp1);
            int[,] mSparse2 = funciones.matrizSparse(bmp2);
            int l1 = mSparse1.GetLength(1);
            int l2 = mSparse2.GetLength(1);
            int l3 = l1 + l2;

            int[,] mSparse3 = new int[3, l3];

            for (int i = 0; i < l1; i++)
            {
                mSparse3[0, i] = mSparse1[0, i];
                mSparse3[1, i] = mSparse1[1, i];
                mSparse3[2, i] = mSparse1[2, i];
            }

            int x, y, val, flag = 0;
            int pos = l1;
            for (int i = 0; i < l2; i++)
            {
                x = mSparse2[0, i];
                y = mSparse2[1, i];
                val = mSparse2[2, i];
                for (int j = 0; j < l1; j++)
                {
                    if (x == mSparse1[0, j] && y == mSparse1[1, j])
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    mSparse3[0, pos] = x;
                    mSparse3[1, pos] = y;
                    mSparse3[2, pos] = val;
                    pos++;
                }
                else
                    flag = 0;
            }

            return mSparse3;
        }
    }
}
