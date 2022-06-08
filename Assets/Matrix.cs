using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
    //IMPLEMENTAR: ESTRUCTURA INTERNA- DONDE GUARDO LOS DATOS?
    private T[,] myMatrix;

    public Matrix(int width, int height)
    {
        //IMPLEMENTAR: constructor
        this.Width = width;
        this.Height = height;
        myMatrix = new T[width,height];
    }

	public Matrix(T[,] copyFrom)
    {
        //IMPLEMENTAR: crea una version de Matrix a partir de una matriz básica de C#
        myMatrix = copyFrom;
        this.Width = myMatrix.GetLength(0);
        this.Height = myMatrix.GetLength(1);
    }

	public Matrix<T> Clone() {
        Matrix<T> aux = new Matrix<T>(Width, Height);
        //IMPLEMENTAR

        for (int i = 0; i < Height; i++)
        {
	        for(int j = 0; j < Width; i++)
	        {
		        aux[j, i] = myMatrix[j, i];
	        }
        }
        
        return aux;
    }

	public void SetRangeTo(int x0, int y0, int x1, int y1, T item) {
        //IMPLEMENTAR: iguala todo el rango pasado por parámetro a item

        for (int i = x0; i <= x1; i++)
        {
	        for (int j = y0; j <= y1; j++)
	        {
		        myMatrix[j, i] = item;
	        }
        }
    }

    //Todos los parametros son INCLUYENTES
    public List<T> GetRange(int x0, int y0, int x1, int y1) {
        List<T> l = new List<T>();
        for (int i = x0; i <= x1; i++)
        {
	        for (int j = y0; j <= y1; j++)
	        {
		        l.Add(myMatrix[j,i]);
	        }
        }
        return l;
	}

    //Para poder igualar valores en la matrix a algo
    public T this[int x, int y] {
		get
		{
			return myMatrix[x, y];
		}
		set {
            myMatrix[x,y] = value;
		}
	}

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Capacity { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
	    return default; //(IEnumerator)myMatrix;
    }

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}
