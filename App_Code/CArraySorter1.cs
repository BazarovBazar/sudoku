using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для CArraySorter1
/// </summary>
public class CArraySorter
{
    public CArraySorter()
    {
        //
        // TODO: добавьте логику конструктора
        //
    }
    public int[] ShiftArray(int[] _inputArray, int sizeOfArray)
    {
        int[] resArray = new int[sizeOfArray];

        int firstElement = _inputArray[0];//запоминаем первый элемент для вставки в конец 

        for(int i=0; i < sizeOfArray - 1; i++)
        {
            resArray[i] = _inputArray[i + 1];//делаем сдвиг массива на одну позицию влево
        }
        resArray[sizeOfArray-1] = firstElement;//вставляем первый элемент в конец

        return resArray;
    }
}