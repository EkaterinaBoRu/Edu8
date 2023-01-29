/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/

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

void streamlineNumberInRow(int[,] arr2)
{
    int temp = 0;
    for (int i=0; i< arr2.GetLength(0); i++)
    {
        for (int k=0; k< arr2.GetLength(1)-1; k++)
        {
            for (int j=0; j< arr2.GetLength(1)-1-k; j++)
            {
                if (arr2[i,j]< arr2[i,j+1])
                {
                    temp  = arr2[i,j];
                    arr2[i,j] = arr2[i, j+1];
                    arr2[i, j+1] = temp;
                }
             } 
        }
    }
}

int row = getUserData("Введите колличество строк в массиве");
int col = getUserData("Введите колличество столбцов в массиве");

int[,] array = generate2DArray(row, col, 0, 5);

print2DArray(array);
streamlineNumberInRow(array);
Console.WriteLine();
print2DArray(array);

//print2DArray(new_array);
