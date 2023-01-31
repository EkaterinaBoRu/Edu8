/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

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


int[] searchSummRow(int[,] arr, int maxnumber)
{
    int summ = 0;
    int[] arr2 = new int[maxnumber];
    
    for (int i=0; i< arr.GetLength(0); i++)
    {
        for (int j=0; j< arr.GetLength(1); j++)
        {
           summ = summ + arr[i,j];
        }
        arr2[i] = summ;
        Console.WriteLine($"Сумма чисел в строке {i}: {arr2[i]}");
        summ = 0;
    }
    return arr2;
}

int searchMin(int[] arr2)
{
    int summ = arr2[0];
    for (int i=0; i< arr2.Length; i++)
    {
        if (arr2[i]< summ) summ = arr2[i];

    }
    return summ;
}

int searchIndex(int summ, int[] arr2)
{
    int search_index = -1;
    for (int i=0; i< arr2.Length; i++)
    {
        if (arr2[i] == summ)
        {
            search_index = i;
        }
        
    }
    return search_index;
}

int row = getUserData("Введите колличество строк в массиве");
int col = getUserData("Введите колличество столбцов в массиве");

int[,] array = generate2DArray(row, col, 0, 5);

print2DArray(array);

int[] arr2 = searchSummRow(array, row);

int summ = searchMin(arr2);
int result = searchIndex(summ, arr2);
Console.WriteLine();
Console.WriteLine($"В строке {result} минимальная сумма чисел {summ}");
