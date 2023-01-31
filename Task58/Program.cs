/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int getUserData(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(message);
    Console.ResetColor();
    int userData = int.Parse (Console.ReadLine()!);
    return userData;
}

void printInColor(string data)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(data);
    Console.ResetColor();
}

int[,] generate2DArray(int colLenght, int rowLenght, int start, int end)
{
    int[,] result = new int[colLenght, rowLenght];
    for (int i=0; i< colLenght; i++)
    {
        for (int j=0; j< rowLenght; j++)
        {
           result[i,j]= new Random().Next(start, end+1);
        }
    }
    return result;
}
void print2DArray (int[,] arr)
{
    Console.Write(" \t");
    for (int j=0; j< arr.GetLength(1); j++)
    {
        printInColor(j + "\t");
    }
    Console.WriteLine();
    for (int i=0; i< arr.GetLength(0); i++)
    {
        printInColor(i + "\t");
        for (int j=0; j< arr.GetLength(1); j++)
        {
            Console.Write(arr[i,j] + "\t");
        }
        Console.WriteLine();
    }
}
int[,] multiplicationArrays(int[,] arr_1, int[,] arr_2, int row_1, int col_2)
{
    int[,] array_mult = new int[row_1, col_2];
    for (int i=0; i< arr_1.GetLength(0); i++)
    {
        for (int j=0; j< arr_2.GetLength(1); j++)
        {
            array_mult[i,j] = 0;
            for (int k=0; k< arr_1.GetLength(1); k++)
            {
                array_mult[i,j]= array_mult[i,j] + arr_1[i,k]*arr_2[k,j];
            }
        } 
    }
    return array_mult;
}


int row_1 = getUserData("Введите колличество строк в матрице 1");
int col_1 = getUserData("Введите колличество столбцов в матрице 1");

int row_2 = getUserData("Введите колличество строк в матрице 2");
int col_2 = getUserData("Введите колличество столбцов в матрице 2");

int[,] array_1 = generate2DArray(row_1, col_1, 0, 5);
int[,] array_2 = generate2DArray(row_2, col_2, 0, 5);

print2DArray(array_1);
Console.WriteLine();
print2DArray(array_2);
Console.WriteLine();
if (array_1.GetLength(1)!= array_2.GetLength(0)) Console.WriteLine("Нельзя перемножить данные матрицы. Количество столбцов первой матрицы не равно количеству строк второй матрицы");
else
{
  int[,] result = multiplicationArrays(array_1, array_2, row_1, col_2); 
  Console.WriteLine("Итоговая матрица:");
  print2DArray(result);
} 