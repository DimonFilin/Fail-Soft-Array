using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fail_Soft_Array
{
    class FailSoftArray
    {
        int[] a; //базовый массив
        public int Length; // длинна массива
        public bool ErrFlag; //результат последней операции

        //Конструкторы массива
        public FailSoftArray() : this(5)
        {
            Console.WriteLine("Вы не ввели размерность, потому пусть будет 5");
        }
        public FailSoftArray(int size)
        {
            a = new int[size];
            Length = size;
        }

        //Индексатор для класса FailSoftArray
        public int this[int index]
        {
            get
            {
                if (ok(index))
                {
                    ErrFlag = false;
                    return a[index];
                }
                else
                {
                    ErrFlag = true;
                    return 0;
                }
            }
            set
            {
                if (ok(index))
                {
                    a[index] = value;
                    ErrFlag = false;
                }
                else
                {
                    ErrFlag = true;
                }
            }
        }

        //возвращает true если индекс в границах, иначе false
        private bool ok(int index)
        {
            if (index >= 0 & index < Length)
                return true;
            else return false;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            FailSoftArray fs = new FailSoftArray();
            int x;
            // Выявить скрытые сбои.
            Console.WriteLine("Скрытый сбой.");
            for (int i = 0; i < (fs.Length * 2); i++)
                fs[i] = i * 10;
            for (int i = 0; i < (fs.Length * 2); i++)
            {
                x = fs[i];
                if (x != -1) Console.Write(x + " ");
            }
            Console.WriteLine();
            // А теперь показать сбои.
            Console.WriteLine("\nСбой с уведомлением об ошибках.");
            for (int i = -1; i < (fs.Length * 2); i++)
            {
                fs[i] = i * 10;
                if (fs.ErrFlag)
                    Console.WriteLine("fs[" + i + "] вне границ");
            }
            for (int i = -1; i < (fs.Length * 2); i++)
            {
                x = fs[i];
                if (!fs.ErrFlag) Console.Write(x + " ");
                else
                    Console.WriteLine("fs[" + i + "] вне границ");
            }
        }
    }
}
