using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_6_anonymous_functions
{
    delegate int IntOperation (int value);

    class Program
    {
        static void Main(string[] args)
        {
            int[] sample = { 1, 2, 3, 5, (int)(Math.Pow(Math.E, 2) + 1) };

            Console.Out.WriteLine("Исходный массив:");
            print(sample);

            Console.Out.WriteLine("После обработки статическим методом:");
            print(map(sample, Pow));

            IntOperation Ln = delegate(int value)
            {
                return (int)Math.Log(value);
            };

            Console.Out.WriteLine("После обработки анонимным методом:");
            print(map(sample, Ln));

            Console.Out.WriteLine("После обработки лямбда-выражением:");
            print(map(sample, (int value) => {
                int a = 0, b = 1;
                for (int i = 0; i < value; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return a;
            }));

            Console.In.Read();
        }

        static int[] map(int[] array, IntOperation callback)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++ )
            {
                result[i] = callback(array[i]);
            }
            return result;
        }

        static void print(int[] array) {
            Console.Out.WriteLine("[{0}]", String.Join(", ", array));
        }

        static int Pow(int Base) {
            return (int)Math.Pow(Base, 2);
        }
    }
}
