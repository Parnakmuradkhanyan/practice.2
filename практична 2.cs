using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Практична_робота___3_Мурадханян
{
    class Program
    {
        static void Excercise_1()
        {
            /*В одновимірному масиві, що складається з дійсних елементів, обчислити: суму елементів масиву з непарними номерами; суму елементів масиву, розташованих між першим  і останнім від’ємними елементами.
Стиснути масив, видаливши з нього всі елементи, модуль яких не перевищує 1. Елементи, що звільнилися в кінці масиву, заповнити нулями.*/

            Console.Write("Введіть кількість елементів масиву: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            Console.WriteLine("Введiть елементи масиву: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Елемент № " + i);
                string text = Console.ReadLine();
                arr[i] = double.Parse(text);
            }

            Console.WriteLine("Масив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            // обчислення суми елементів масиву з непарними номерами
            double sum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sum1 += arr[i];
                }
            }
            Console.WriteLine("Сума елементів масиву з непарними номерами: " + sum1);

            // обчислення суми елементів масиву, розташованих між першим і останнім від’ємними елементами
            double sum2 = 0;
            int firstNegativeIndex = -1;
            int lastNegativeIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    if (firstNegativeIndex == -1)
                    {
                        firstNegativeIndex = i;
                    }
                    lastNegativeIndex = i;
                }
            }
            if (firstNegativeIndex != -1 && lastNegativeIndex != -1)
            {
                for (int i = firstNegativeIndex + 1; i < lastNegativeIndex; i++)
                {
                    sum2 += arr[i];
                }
            }
            Console.WriteLine("Сума елементів масиву між першим і останнім від’ємними елементами: " + sum2);

            // стиснення масиву, видаляючи елементи, модуль яких не перевищує 1
            int newSize = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > 1)
                {
                    arr[newSize] = arr[i];
                    newSize++;
                }
            }
            // заповнення нулями вільного місця в кінці масиву
            for (int i = newSize; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            // виведення нового масиву
            Console.WriteLine("Стиснутий масив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

        }

        static void Excercise_2_1()
        {
            /*Створити числовий масив, у якому міститься 30 елементів. Відсортувати елементи масиву за допомгою методу з лецкції*/
            int[] arr = new int[30];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 101);
            }

            Console.WriteLine("Масив до бульбашкового сортування:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            int wvar = arr[0];
            for (int i = 1; i < 30; i++)
            {
                for (var j = 0; j < 29; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        wvar = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = wvar;
                    }
                }
            };
            Console.WriteLine("\n" + "\n" + "Масив пiсля сортування: ");
            foreach (int m in arr) Console.Write(m + " ");
            System.Console.ReadLine();
        }

        static void Excercise_2_2()
        {
            /*Створити числовий масив, у якому міститься 30 елементів. Відсортувати елементи масиву за допомгою методу самостійного опрацювання*/
            int[] arr = new int[30];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 101);
            }

            Console.WriteLine("Невідсортований масив:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Відсортований масив:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp2;
            return i + 1;
        }



        static void Excercise_3()
        {
            /*Дано одномірний масив. Вивести довжину і початкові індекси всіх неперервних послідовностей чисел, які утворюють спадну послідовність.*/
            int[] array = new int[100];


            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-50, 51);
            }


            Console.WriteLine("Масив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0,3}", array[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();


            int start = -1, length = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    if (start == -1) start = i - 1;
                    length++;
                }
                else
                {
                    if (start != -1) Console.WriteLine("Початковий індекс: {0}, Довжина: {1}", start, length + 1);
                    start = -1;
                    length = 0;
                }
            }
            if (start != -1) Console.WriteLine("Початковий індекс: {0}, Довжина: {1}", start, length + 1);

        }

        static void Excercise_4_1()
        {
            /*Дано двовимірний масив. Заповнити матрицю nxn випадковими числами та виконати наступні дії. Матриця містить як додатні, так і від’ємні елементи. Визначити в заданій матриці субматрицю з максимальною сумою елементів.*/
            Console.WriteLine("Введіть розсірність масиву, тобот (nxn): ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(-50, 51);
                }
            }


            Console.WriteLine("Двовимірна матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }


            int maxSum = int.MinValue;
            int maxSumTop = 0;
            int maxSumLeft = 0;
            int maxSumBottom = 0;
            int maxSumRight = 0;

            for (int top = 0; top < n; top++)
            {
                for (int bottom = top; bottom < n; bottom++)
                {
                    for (int left = 0; left < n; left++)
                    {
                        for (int right = left; right < n; right++)
                        {
                            int sum = 0;
                            for (int i = top; i <= bottom; i++)
                            {
                                for (int j = left; j <= right; j++)
                                {
                                    sum += matrix[i, j];
                                }
                            }

                            if (sum > maxSum)
                            {
                                maxSum = sum;
                                maxSumTop = top;
                                maxSumLeft = left;
                                maxSumBottom = bottom;
                                maxSumRight = right;
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Субматриця з максимальною сумою елементів:");
            for (int i = maxSumTop; i <= maxSumBottom; i++)
            {
                for (int j = maxSumLeft; j <= maxSumRight; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сума елементів субматриці: " + maxSum);
        }

        static void Excercise_4_2()
        {
            /*В програмі оголошено східчастий масив  цілих чисел, які мають різну довжину рядків. 
                int [] [] jagged = new int[4][];
                jagged [0] = new int[6];
                jagged [1] = new int[2];
                jagged [2] = new int[4];
                jagged [3] = new int[11];
                Необхідно: 
                Вивести довжину і початкові індекси всіх неперервних послідовностей чисел кожного рядка, які утворюють спадну послідовність.*/

            int[][] jagged = new int[4][];
            jagged[0] = new int[6];
            jagged[1] = new int[2];
            jagged[2] = new int[4];
            jagged[3] = new int[11];

            Random rand = new Random();
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = rand.Next(-50, 51);
                }
            }

            Console.WriteLine("Матриця:");

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write("Рядок {0}: ", i);

                int[] row = jagged[i];
                int maxLength = 0;
                int startIndex = 0;
                int currentLength = 0;

                for (int j = 0; j < row.Length - 1; j++)
                {
                    if (row[j] > row[j + 1])
                    {
                        currentLength++;

                        if (currentLength == 1)
                        {
                            startIndex = j;
                        }

                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                        }
                    }
                    else
                    {
                        currentLength = 0;
                    }
                }

                if (maxLength > 0)
                {
                    Console.WriteLine("Довжина: {0}, Початковий індекс: {1}", maxLength + 1, startIndex - maxLength);
                }
                else
                {
                    Console.WriteLine("Нема спадної послідовності.");
                }
            }
        }

        /*
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int start = -1;
            int length = 0;

            for (int j = 0; j < cols; j++)
            {
                if (j == 0 || arr[i, j] < arr[i, j - 1])
                {

                    start = j;
                    length = 1;
                }
                else
                {
                    length++;
                }

                if (length > 1 && (j == cols - 1 || arr[i, j] > arr[i, j + 1]))
                {

                    Console.WriteLine($"Рядок: {i}, Початковий індекс: {start}, Довжина: {length}");
                    start = -1;
                    length = 0;
                }
            }
        }
    }*/

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Практична робота № 3 Мурадханян Парнак ФІТ 1-5 ІПЗ Варіант 14");
            Console.WriteLine("Введіть номер завдання: ");
            int exNum;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out exNum)) { break; }
            }
            switch (exNum)
            {
                case 1:
                    Excercise_1();
                    break;
                case 2:
                    Console.WriteLine("Задвання 2.1:");
                    Console.WriteLine("Сортування масиву за допомогою методу бульбашкового сортування з лекції");
                    Excercise_2_1();
                    Console.WriteLine(" ");
                    Console.WriteLine("Завдання 2.2:");
                    Console.WriteLine("Сортування масиву за допомогою методу швидкого сортування за самостійним сортуванням");
                    Excercise_2_2();
                    break;
                case 3:
                    Excercise_3();
                    break;
                case 4:
                    Console.WriteLine("Задвання 4.1:");
                    Excercise_4_1();
                    Console.WriteLine(" ");
                    Console.WriteLine("Завдання 4.2:");
                    Excercise_4_2();
                    break;
                case 5:
                    Console.WriteLine("Такого не задавали :))");
                    break;
                default:
                    Console.WriteLine("Завдання з таким номером не існує!!!");
                    break;

            }
            Console.ReadKey();
        }

    }
}