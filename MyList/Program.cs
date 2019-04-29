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

                for (int i = 0; i < Count; i++)
                {
                    if (Equals(_tArray[i], item) && i < Count - 1)
                    {
                        _tArray[i] = _tArray[i + 1];
                        _tArray[i + 1] = item;
                    }

                    newArray[i] = _tArray[i];
                    _tArray = newArray;
                }
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


            PrintArray(myIntList);

            myIntList.Remove(5);

            PrintArray(myIntList);
            

            Console.ReadLine();
        }

        private static void PrintArray<T>(MyList<T> array)
        {
            for (var i = 0; i < array.Count; i++)
                Console.WriteLine(array[i]);
        }
    }
}
