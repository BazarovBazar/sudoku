using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sudoku : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int a = 0;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

   
    protected void ButtonStart_Click(object sender, EventArgs e)
    {
        CSudoku sudokuObject = new CSudoku();

        if (Label1.Text != "")
            Label1.Text = "";


        ConstantNames.SudokuArray = sudokuObject.GenerateNewSudoku();

        int selectedLavel = Convert.ToInt32( DropDownListOfLavels.SelectedValue );//выбор уровня  сложности

        int[,] DeletedSudokuArray = sudokuObject.DeleteCellsFromSudoku(ConstantNames.SudokuArray, selectedLavel); 

        for (int i = 1; i <= 9; i++)//i идентификатор строки (1,9)
        {
            for (int j = 1; j <= 9; j++)
            {
                int ValueToTextBox = DeletedSudokuArray[i - 1, j - 1];

                string controllName = "cell" + i.ToString() + j.ToString();

                TextBox textBox = (TextBox)FindControl(controllName);

                if (ValueToTextBox != 0)
                {
                    textBox.Text = ValueToTextBox.ToString();//считываем значения в textBox
                }
                else
                {
                    textBox.Text = "";
                }

            }
        }

    }

    private bool isNumber(string text)
    {
        //проверка текста что он является числом
        for (int i = 0; i < text.Length; i++)
        {
            if (!char.IsDigit(text, i))
            {
                return false;
            }
        }
        return true;
    }

    
    /// <summary>
    /// метод проверяет является ли текст в textBox числом.
    /// и является ли введенное число верным.
    /// если в ячейку введено неверное число то функция возвращает false.
    /// в функции используется глобальная переменная SudokuArray
    /// </summary>
    /// <param name="textBox"></param>
    /// <returns></returns>
    private bool CheckCell(TextBox textBox, int lineNumber, int columnNumber)
    {
        string cellText = textBox.Text;

        //проверка текста что он является числом
        if (!isNumber(cellText))
        {
            cell11.Text = "";// если текст не является числом, то стираем его и выходим из метода c возвратом истины
            return true;
        }
        //если текст являеся числом, то сравниваем его со значением в массиве. значения должны совпасть
        int NumberInCell = Convert.ToInt32(cellText);

        if (ConstantNames.SudokuArray[lineNumber, columnNumber] != NumberInCell)//Если число неправильное
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// проверка текста в текстБокс
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    private bool checkTextInTextBox(TextBox cell)
    {
        char lineNumber = cell.ID.ElementAt(4);//уменьшить на 1
        char columnNumber = cell.ID.ElementAt(5);// уменьшить на 

        string slineNumber = lineNumber.ToString();
        string scolumnNumber = columnNumber.ToString();

        int _lineNumber = Convert.ToInt32(slineNumber );
        int _columnNumber = Convert.ToInt32(scolumnNumber);

        if (!CheckCell(cell, _lineNumber - 1, _columnNumber - 1))//метод проверяет является ли текст в textBox числом.
        {
            //проигрыш 
            Label1.Text = "Вы проиграли!!!Нажмите старт чтобы начать заново";
            return false;
        }

        return true;
    }
    
    protected void cell_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = sender as TextBox;
        checkTextInTextBox(textBox);
        if( !isAnyCellIsEmpty( ) )
        {
            Label1.Text = "Поздравляю!!! вы выиграли!!! Нажмите старт, чтобы начать заново";
        }

    }
    private bool isAnyCellIsEmpty()
    {

        for(int i=1;i<=9;i++)
        {
            for(int j=1;j<=9;j++)
            {
                string cellID = "cell" + i.ToString() + j.ToString();
                

                TextBox textBox = (TextBox)FindControl(cellID);
                if (textBox.Text == "")
                    return true;//нашлась одна неотгаданная ячейка
            }
        }
        return false;//пустых ячеек нет. Вы выиграли
    }

    protected void DropDownListOfLavels_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
}
