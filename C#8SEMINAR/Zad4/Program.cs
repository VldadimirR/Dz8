/* Задайте двумерный массив из целых чисел.
Напишите программу, которая удалит строку и столбец, на
пересечении которых расположен наименьший элемент
массива. */
int rows = new Random().Next(1, 10);
int columns = new Random().Next(1, 10);

int [,] array = GetArray(rows, columns, 0, 20);
PrintArray(array);
Console.WriteLine();

int [] minimumIndex = MinValue(array);
Console.WriteLine($"{minimumIndex[0]}, {minimumIndex[1]}");
Console.WriteLine();

int[,] resultArray = DeleteArray(array, minimumIndex);
PrintArray(resultArray);


int [,] GetArray(int rows, int columns, int min, int max)
{
    int [,] result = new int [rows,columns];
    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < columns; j++)
        {
            result[i,j] = new Random().Next(min, max);
        }
    }
    return result;
}

void PrintArray(int [,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[] MinValue(int[,] array)
{
    int min = array[0,0];
    int minIndexI = 0;
    int minIndexJ = 0;
    for(int i = 0; i < array.GetLength(0); i++)
     {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i,j] < min)
            {
               min = array[i,j];
               minIndexI = i;
               minIndexJ = j; 
            }
        }
     } 
     int[] result = new int [2];
     result [0] = minIndexI;
     result [1] = minIndexJ;
     return result;
}

int[,] DeleteArray(int [,] array, int [] index)
{
    int [,] result = new int [array.GetLength(0) - 1, array.GetLength(1) - 1];
    int minI = index[0];
    int minJ = index[1];
     for(int i = 0; i < array.GetLength(0) - 1; i++)
     {
        for(int j = 0; j < array.GetLength(1) - 1; j++)
        {
            if(i < minI && j < minJ)
            {
               result[i,j] = array[i,j];
            }
            else
            {
                if(i < minI)
                {
                    result[i,j] = array[i,j+1];
                }
                else if(j < minJ)
                {
                    result[i,j] = array[i+1,j];
                }
                else
                {
                    result[i,j] = array[i+1,j+1];//главное не запутаться в условиях
                }
            }
        }
     } 
     return result;
}