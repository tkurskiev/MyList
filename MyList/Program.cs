using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        private class MyList<T> : IDisposable
        {
            #region Private Members

            private T[] _tArray = new T[0] { };

            #endregion

            #region Public Methods

            public void Add(T newItem)
            {
                Count += 1;

                var newArray = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    if (i == Count - 1)
                    {
                        newArray[i] = newItem;

                        _tArray = newArray;

                        break;
                    }

                    newArray[i] = _tArray[i];
                }
            }

            public void Remove(T item)
            {
                Count -= 1;

                var newArray = new T[Count];

                for (var i = 0; i < Count; i++)
                {
                    if (Equals(_tArray[i], item) && i < Count)
                    {
                        _tArray[i] = _tArray[i + 1];
                        _tArray[i + 1] = item;
                    }

                    newArray[i] = _tArray[i];
                }

                _tArray = newArray;
            }

            public void Dispose()
            {
                _tArray = null;
            }

            #endregion

            #region Public Properties

            public int Count { get; private set; } = 0;

            public T this[int i]
            {
                get => _tArray[i];
                set => _tArray[i] = value;
            }

            #endregion
        }

        static void Main(string[] args)
        {
            var myIntList = new MyList<int>();

            myIntList.Add(5);
            myIntList.Add(10);
            myIntList[myIntList.Count - 1] = 22;
            myIntList.Add(120);
            myIntList.Add(55);


            PrintArray(myIntList);

            myIntList.Remove(120);

            Console.WriteLine();
            PrintArray(myIntList);

            #region Commented out

            /*

            Console.WriteLine(Environment.NewLine + "-------*Random strings*-------\n");

            Console.WriteLine($"{(int)'z'}");

            var rand = new Random();

            var newList = new MyList<string>();

            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var randomNumber = rand.Next(0, 30);
                    var newString = string.Empty;

                    for (int j = 0; j < randomNumber; j++)
                        newString += $"{(char)rand.Next(65, 90)}" + $"{(char)rand.Next(96, 122)}";

                    newList.Add(newString);
                }

                PrintArray(newList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }            

            */

            #endregion

            Console.ReadLine();

        }

        private static void PrintArray<T>(MyList<T> array)
        {
            for (var i = 0; i < array.Count; i++)
            {
                if (i == array.Count - 1)
                {
                    Console.WriteLine($"And the last one (MyList[{i}]): {array[i]}");
                    continue;
                }

                Console.WriteLine($"MyList[{i}] = {array[i]}");
            }
        }
    }
}
