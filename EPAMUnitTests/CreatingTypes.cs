using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMUnitTests
{
    public class CreatingTypes
    {
        //Реализовать алгоритм FindNthRoot, позволяющий вычислять корень** n**-ой степени(n ∈ N )
        //из вещественного числа** а** методом Ньютона с заданной точностью.
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if (double.IsInfinity(number) || double.IsNaN(number))
            {
                throw new ArgumentException("Number is not a finite value", nameof(number));
            }

            if (number < 0.0 && (power % 2 == 0))
            {
                throw new ArgumentException("Unable to calculate even root for negative number.", $"{nameof(number)}, {nameof(power)}");
            }

            if (power < 1)
            {
                throw new ArgumentOutOfRangeException("Power must be natural number.", nameof(power));
            }

            if (accuracy < 1e-15)
            {
                throw new ArgumentOutOfRangeException("Accuracy cannot be less than 1.0e-15.", nameof(accuracy));
            }

            if (power == 1 || number == 0.0 || number == 1.0)
            {
                return number;
            }

            double currentIterationResult = 0.0;
            double previousIterationResult = Math.Sign(number);

            while (true)
            {
                double divisor = Math.Pow(previousIterationResult, power - 1);

                if (double.IsInfinity(divisor))
                {
                    throw new ArithmeticException($"The method cannot calculate root with these arguments: {number}, {power}.");
                }

                currentIterationResult = (((power - 1) * previousIterationResult) + (number / divisor)) / power;

                if (!double.IsInfinity(currentIterationResult))
                {
                    if (Math.Abs(currentIterationResult - previousIterationResult) < accuracy / 10)
                    {
                        return Math.Round(currentIterationResult, GetZeroNumbers(accuracy) - 1);
                    }

                    previousIterationResult = currentIterationResult;
                }
                else
                {
                    previousIterationResult *= 2;
                }
            }
        }

        public static int GetZeroNumbers(double number)
        {
            int result = 0;

            while (number < 10)
            {
                number *= 10;
                result++;
            }

            return result;
        }

        //Реализовать метод "пузырьковой" сортировки для целочисленного массива(не использовать методы класса System.Array) 
        //таким образом, чтобы была возможность упорядочить строки матрицы
        //- в порядке возрастания(убывания) сумм элементов строк матрицы;
        //- в порядке возрастания(убывания) максимальных элементов строк матрицы;
        //- в порядке возрастания(убывания) минимальных элементов строк матрицы.

        public static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] buff = arr1;
            arr1 = arr2;
            arr2 = buff;
        }

        public static int Min(int[] array)
        {
            int min = int.MaxValue;
            foreach (int item in array)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static int Max(int[] array)
        {
            int max = int.MinValue;
            foreach (int item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        public static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int element in array)
            {
                sum += element;
            }
            return sum;
        }

        public static void SortBySumOfTheElements(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Sum(array[i]) < Sum(array[i + 1]))
                {
                    Swap(ref array[i], ref array[i + 1]);
                }
            }
        }

        public static void SortByMaximumOfTheElements(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Max(array[i]) < Max(array[i + 1]))
                {
                    Swap(ref array[i], ref array[i + 1]);
                }

            }
        }

        public static void SortByMinimumOfTheElements(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {

                if (Min(array[i]) < Min(array[i + 1]))
                {
                    Swap(ref array[i], ref array[i + 1]);
                }

            }
        }
    }
}
