using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMUnitTests
{
    //Расширить функциональную возможность типа System.Double, реализовав возможность
    //получения строкового представления вещественного числа в формате IEEE 754

    public static class DoubleExtensions
    {
        private const int BYTELENGTH = 8;
        private const int DOUBLEBYTELENGTH = BYTELENGTH * 8;

        public static string ToByteString(this double number)
        {
            StringBuilder byteString = new StringBuilder();
            StringBuilder temple = new StringBuilder();
            Converter converter = new Converter();
            converter.DoubleView = number;
            long pointer = converter.LongView;

            for (int i = 0; i < DOUBLEBYTELENGTH; i++, pointer >>= 1)
            {
                if ((pointer & 1) == 1)
                {
                    byteString.Insert(0, "1");
                }
                else
                {
                    byteString.Insert(0, "0");
                }
            }

            return byteString.ToString();
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 64)]
        struct Converter
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            private long longView;
            [System.Runtime.InteropServices.FieldOffset(0)]
            private double doubleView;

            public long LongView
            {
                get => this.longView;
            }

            public double DoubleView
            {
                set => this.doubleView = value;
            }
        }
    }

    //Реализовать для null-able типов, дополнительную возможность определения - является ссылка null или нет

    public static class NullExtensions
    {
        public static bool getNullReference(this Object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида
    //для двух, трех и т.д.целых чисел. Методы класса помимо вычисления НОД должны 
    //предоставлять дополнительную возможность определения значение времени, необходимое 
    //для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм 
    //Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел 

    public static class GCDSearch
    {
        public static long SearchByEuclid(long a, long b)
        {
            while (a != 0)
            {
                long temp = a;
                a = b % a;
                b = temp;
            }

            return Math.Abs(b);
        }

        public static long SearchByEuclid(out long time, long a, long b) => GCD(SearchByEuclid, a, b, out time);

        public static long SearchByEuclid(long a, long b, long c) => GCD(SearchByEuclid, a, b, c);

        public static long SearchByEuclid(out long time, long a, long b, long c) => GCD(SearchByEuclid, a, b, c, out time);

        public static long SearchByEuclid(params long[] nums) => GCD(SearchByStein, nums);

        public static long SearchByEuclid(out long time, params long[] nums) => GCD(SearchByStein, out time, nums);


        public static long SearchByStein(long a, long b)
        {
            long? gcd = null;

            if (a == 0)
                gcd = b;
            else if (b == 0)
                gcd = a;
            else if (a == b)
                gcd = a;
            else if (a == 1 || b == 1)
                gcd = 1;

            if (gcd != null)
                return Math.Abs((long)gcd);

            if ((a & 1) == 0)
                gcd = ((b & 1) == 0)
                    ? SearchByStein(a >> 1, b >> 1) << 1
                    : SearchByStein(a >> 1, b);
            else
                gcd = ((b & 1) == 0)
                    ? SearchByStein(a, b >> 1)
                    : SearchByStein(b, a > b ? a - b : b - a);

            return Math.Abs((long)gcd);
        }

        public static long SearchByStein(out long time, long a, long b) => GCD(SearchByStein, a, b, out time);

        public static long SearchByStein(long a, long b, long c) => GCD(SearchByStein, a, b, c);

        public static long SearchByStein(out long time, long a, long b, long c) =>
            GCD(SearchByStein, a, b, c, out time);

        public static long SearchByStein(params long[] nums) => GCD(SearchByStein, nums);

        public static long SearchByStein(out long time, params long[] nums) => GCD(SearchByStein, out time, nums);

        private static void CheckInputArray(long[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length < 2)
                throw new ArgumentException();
        }

        private static long GCD(Func<long, long, long> gcdFunc, long a, long b, out long time)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(a, b);

            time = sw.ElapsedTicks;

            return gcd;
        }


        private static long GCD(Func<long, long, long> gcdFunc, long a, long b, long c) => gcdFunc(gcdFunc(a, b), c);

        private static long GCD(Func<long, long, long, long> gcdFunc, long a, long b, long c, out long time)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(a, b, c);

            time = sw.ElapsedTicks;

            return gcd;
        }


        private static long GCD(Func<long, long, long> gcdFunc, params long[] nums)
        {
            CheckInputArray(nums);

            long gcd = gcdFunc(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = gcdFunc(gcd, nums[i]);
            }

            return gcd;
        }

        private static long GCD(Func<long[], long> gcdFunc, out long time, params long[] nums)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(nums);

            time = sw.ElapsedTicks;

            return gcd;
        }
    }
}
