using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
	private T[,] myMatrix;

    public Matrix(int width, int height)
    {
	    Width = width;
        Height = height;
        Capacity = width * height;
        myMatrix = new T[width,height];
    }

	public Matrix(T[,] copyFrom)
	{
		myMatrix = new T[copyFrom.GetLength(0), copyFrom.GetLength(1)];
		
		for (int i = 0; i < Height; i++)
		{
			for(int j = 0; j < Width; i++)
			{
				myMatrix[j, i] = copyFrom[j, i];
			}
		}
	}

	public Matrix<T> Clone() {
		
        Matrix<T> aux = new Matrix<T>(Width, Height);

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

		for (int i = x0; i <= x1; i++)
        {
	        for (int j = y0; j <= y1; j++)
	        {
		        myMatrix[j, i] = item;
	        }
        }
    }


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
	    for (int i = 0; i < Height; i++)
	    {
		    for(int j = 0; j < Width; i++)
		    {
			    yield return myMatrix[j, i];
		    }
	    }

    }

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}
