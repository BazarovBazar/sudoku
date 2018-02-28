using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Sudoku
/// </summary>
public class CSudoku
{
    public CSudoku()
    {
        //
        // TODO: добавьте логику конструктора
        //
    }

    /// <summary>
    /// сдвиг в матрице. для получения базовой сетки
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="ShiftValue"></param>
    /// <returns></returns>
    private int[,] GenerateBaseSudoku(int[,] inputArray)// входные параметры массив и параметр сдвига в массиве
    {
        int[,] resArray = new int[9,9];
        CArraySorter arraySorter = new CArraySorter();//сортировщик
        int[] tempArray = new int[9];

        //========работаем с первым районом по вертикали==========

        for(int j = 0; j < 9; j++)
        {
            tempArray[j] = inputArray[0,j];// копируем первую строку входного массива 
        }

        for (int j = 0; j < 9; j++)
        {
            resArray[0,j] = tempArray[j];// вставляем первую строку в выходной массив
        }

        for (int i = 0; i < 3; i++)
        {
            tempArray = arraySorter.ShiftArray(tempArray, 9);//делаем три раза сдвиг на один влево
        }

        for (int j = 0; j < 9; j++)
        {
            resArray[1, j] = tempArray[j];// вставляем вторую строку в выходной массив
        }

        for (int i = 0; i < 3; i++)
        {
            tempArray = arraySorter.ShiftArray(tempArray, 9);//делаем три раза сдвиг на один влево
        }

        for (int j = 0; j < 9; j++)
        {
            resArray[2, j] = tempArray[j];// вставляем третью строку в выходной массив
        }

        //теперь получаем второй район по вертикали
        // его получаем сдвигом первого района на одну позицию влево

        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[0, j];// копируем первую строку первого района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[3, j] = tempArray[j];// вставляем четвертую строку в выходной массив
        }


        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[1, j];// копируем вторую строку первого района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[4, j] = tempArray[j];// вставляем пятую строку в выходной массив
        }


        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[2, j];// копируем третью строку первого района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[5, j] = tempArray[j];// вставляем шестую строку в выходной массив
        }


        //теперь получаем третий район по вертикали
        // его получаем сдвигом второго района на одну позицию влево

        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[0 + 3,j];// копируем первую строку второго района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[6, j] = tempArray[j];// вставляем седьмую строку в выходной массив
        }


        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[1 + 3, j];// копируем вторую строку второго района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[7, j] = tempArray[j];// вставляем восьмую строку в выходной массив
        }


        for (int j = 0; j < 9; j++)
        {
            tempArray[j] = resArray[2 + 3, j];// копируем третью строку второго района по вертикали 
        }
        tempArray = arraySorter.ShiftArray(tempArray, 9);// сдвигаем на одну позицию влево
        for (int j = 0; j < 9; j++)
        {
            resArray[8, j] = tempArray[j];// вставляем девятую строку в выходной массив
        }


        return resArray;
    }

    
    /// <summary>
    /// транспонирование матрицы
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="ShiftValue"></param>
    /// <returns></returns>
    private int[,] TransposeArraySudoku(int[,] inputArray)// входные параметры массив и параметр сдвига в массиве
    {
        int[,] resArray = new int[9, 9];


        for (int i = 0; i < 9; i++)//i идентификатор строки (1,9)
        {
            for (int j = 0; j < 9; j++)
            {
               //Вот собственно операция транспонирования. строки меняются со столбцами
                resArray[i, j] = inputArray[j,i];

                resArray[j, i] = inputArray[i,j];
            }
        }

        return resArray;
    }

    /// <summary>
    /// Обмен двух столбцов
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="ColumnNumber1"></param>
    /// <param name="ColumnNumber2"></param>
    /// <returns></returns>
    private int[,] ExchangeColumns(int[,] inputArray, int ColumnNumber1, int ColumnNumber2)
    {
        int[,] resArray = new int[9, 9];

        for(int i=0;i<9;i++)
        {
            for(int j=0;j<9;j++)
            {
                resArray[i, j] = inputArray[i,j];//сначала копируем массив inputArray
            }
        }

        for (int i = 0; i < 9; i++)//i идентификатор строки (1,9)/ проход по всем строкам
        {          
                //Вот собственно операция обмена столбцов
                resArray[i, ColumnNumber1] = inputArray[i, ColumnNumber2];
                resArray[i, ColumnNumber2] = inputArray[i, ColumnNumber1];           
        }

        return resArray;
    }

    /// <summary>
    /// Обмен двух строк
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="ColumnNumber1"></param>
    /// <param name="ColumnNumber2"></param>
    /// <returns></returns>
    private int[,] ExchangeLines(int[,] inputArray, int LineNumber1, int LineNumber2)
    {
        int[,] resArray = new int[9, 9];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                resArray[i, j] = inputArray[i, j];//сначала копируем массив inputArray
            }
        }

        for (int i = 0; i < 9; i++)//i идентификатор строки (1,9)/ проход по всем номерам столбцов
        {
            //Вот собственно операция обмена строк
            resArray[LineNumber1, i] = inputArray[LineNumber2, i];
            resArray[LineNumber2, i] = inputArray[LineNumber1, i];
        }

        return resArray;
    }

    /// <summary>
    /// обмен двух столбцов в пределах одного региона
    /// </summary>
    /// <param name="intputArray"></param>
    /// <param name="numberOfRegion"></param>
    /// <returns></returns>
    private int[,] ExchangeColumnsInRegion(int[,] inputArray, int numberOfRegion)
    {
        int[,] resArray = new int[9, 9];

        Random random = new Random();

        int randomNumber1 = random.Next(0,3);
        int randomNumber2 = random.Next(0,3);
        while(randomNumber1 == randomNumber2)
        {
            randomNumber2 = random.Next(0,3);
        }


        int ColumnNumber1 = (numberOfRegion - 1) * 3 + randomNumber1;
        int ColumnNumber2 = (numberOfRegion - 1) * 3 + randomNumber2;

        resArray = ExchangeColumns(inputArray, ColumnNumber1, ColumnNumber2);

        return resArray;

    }

    /// <summary>
    /// обмен строк в одном регионе
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="numberOfRegion номер региона от 1 до 3"></param>
    /// <returns></returns>

    private int[,] ExchangeLinesInRegion(int[,] inputArray, int numberOfRegion)
    {
        int[,] resArray = new int[9, 9];

        Random random = new Random();

        int randomNumber1 = random.Next(0, 3);
        int randomNumber2 = random.Next(0, 3);
        while (randomNumber1 == randomNumber2)
        {
            randomNumber2 = random.Next(0, 3);
        }


        int LineNumber1 = (numberOfRegion - 1) * 3 + randomNumber1;
        int LineNumber2 = (numberOfRegion - 1) * 3 + randomNumber2;

        resArray = ExchangeLines(inputArray, LineNumber1, LineNumber2);

        return resArray;

    }

    /// <summary>
    /// обмен двух вертикальных регионов в массиве
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="numberOfRegion номер региона от 1 до 3"></param>
    /// <returns></returns>

    private int[,] ExchangeTwoRegionsInVerticalLine(int[,] inputArray, int numberOfRegion1, int numberOfRegion2)
    {
        int[,] resArray = new int[9, 9];

        resArray = CopyArray(inputArray);

        for (int j = 0; j <= 2; j++)
        {
            int ColumnNumber1 = (numberOfRegion1 - 1) * 3 + j;
            int ColumnNumber2 = (numberOfRegion2 - 1) * 3 + j;

            //        resArray = ExchangeLines(inputArray, LineNumber1, LineNumber2);

            resArray = ExchangeColumns(resArray, ColumnNumber1, ColumnNumber2);
        }

        return resArray;

    }

    private int[,] CopyArray(int[,] inputArray)
    {
        int[,] resArray = new int[9, 9];

        for(int i=0;i<9;i++)
        {
            for(int j=0; j<9;j++)
            {
                resArray[i, j] = inputArray[i,j];
            }
        }
        return resArray;
    }
    /// <summary>
    /// обмен двух горизонтальных регионов в массиве
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="numberOfRegion номер региона от 1 до 3"></param>
    /// <returns></returns>

    private int[,] ExchangeTwoRegionsInHorizontalLine(int[,] inputArray, int numberOfRegion1, int numberOfRegion2)
    {
        int[,] resArray = new int[9, 9];

        resArray = CopyArray(inputArray);

        for (int j = 0; j <= 2; j++)//проход по трем строкам
        {
            int LineNumber1 = (numberOfRegion1 - 1) * 3 + j;
            int LineNumber2 = (numberOfRegion2 - 1) * 3 + j;

            //        resArray = ExchangeLines(inputArray, LineNumber1, LineNumber2);

            resArray = ExchangeLines(resArray, LineNumber1, LineNumber2);
        }

        return resArray;
    }



    /// <summary>
    /// обмен двух вертикальных регионов в массиве
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="numberOfRegion номер региона от 1 до 3"></param>
    /// <returns></returns>



    public int[,] GenerateNewSudoku()
    {

        int[,] SudokuArray = new int[9, 9];

        for (int i = 0; i < 9; i++)//i идентификатор строки (1,9)
        {
            for (int j = 0; j < 9; j++)
            {
                SudokuArray[i, j] = j + 1; 
            }
        }

         SudokuArray = GenerateBaseSudoku(SudokuArray);//Базовая таблица готова

                 Random random = new Random();
                 int maxRandom = 1000;//максимальное произвольное число
                 int minRandom = 600;//минимальное произвольное число
                 int randomNumber = random.Next(minRandom, maxRandom);


                for (int k = 0; k < randomNumber; k++)// делаем обмен столбцов, строк randomNumber раз
                {
                    for (int i = 1; i <= 3; i++)//меняем столбцы в трех регионах. i это номер региона
                    {
                        
                        SudokuArray = ExchangeColumnsInRegion(SudokuArray, i);
                        SudokuArray = TransposeArraySudoku(SudokuArray);
                        SudokuArray = ExchangeLinesInRegion(SudokuArray, i);
                        SudokuArray = ExchangeColumnsInRegion(SudokuArray, i);
                        SudokuArray = ExchangeLinesInRegion(SudokuArray, i);  
                    }


                     //делаем обмен вертикальных регионов. и обмен горизонтальных регионов. Номера регионов произвольные.
                    for (int i = 0; i < 100;i++)
                    {

                        int NumberOfRegion1 = random.Next(1, 4);
                        int NumberOfRegion2 = random.Next(1, 4);
                        while (NumberOfRegion2 == NumberOfRegion1)
                        {
                             NumberOfRegion2 = random.Next(1, 4);
                        }

                        SudokuArray = ExchangeTwoRegionsInVerticalLine(SudokuArray, NumberOfRegion1, NumberOfRegion2);//вертикальных регионов
                        SudokuArray = ExchangeTwoRegionsInHorizontalLine(SudokuArray, NumberOfRegion1, NumberOfRegion2);//горизонтальных регионов
                    }
                }        
        
        return SudokuArray;
    }
    /// <summary>
    /// Удаление ячеек для составления судоку
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="GameLavel"></param>
    /// <returns></returns>
    public int[,] DeleteCellsFromSudoku(int[,] inputArray, int GameLavel)
    {
        int[,] resArray = new int[9,9];

        for (int i = 0; i < 9; i++)//i идентификатор строки (1,9)
        {
            for (int j = 0; j < 9; j++)
            {
                resArray[i, j] = inputArray[i,j];// копируем массив
            }
        }

        int CountToDelete = 0;

        if(GameLavel == 1)
        {
            CountToDelete = 32;
        }
        if(GameLavel == 2)
        {
            CountToDelete = 42;
        }
        if (GameLavel == 3)
        {
            CountToDelete = 48;
        }

        for (int k = 0; k < CountToDelete; k++)
        {
            bool flag = true;

            while (flag)
            {
                Random random = new Random();//выбираем произвольную ячейку и обнуляем ее
                int i = random.Next(0, 9);
                int j = random.Next(0, 9);

                if (resArray[i, j] == 0)
                {
                    flag = true;//искать новую ячейку
                }
                else {
                    resArray[i, j] = 0;
                    flag = false;
                }
            }
                
        }
        return resArray;
    }

    public int SaveSudokuToDataBase()
    {

        return 0;
    }

}