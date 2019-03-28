using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTab
{
    public class Program    
    {
        public class KeyAndValue
        {
            public readonly int Key;
            public object Value;
            public KeyAndValue(int key, object value)
            {
                Key = key;
                Value = value;
            }
        }

        public class HashTable
        {
            List<KeyAndValue>[] Pairs;

            /// <summary>
            /// Конструктор контейнера
            /// summary>
            /// size">Размер хэ-таблицы

            public HashTable(int size) => Pairs = new List<KeyAndValue>[size];

            ///
            /// Метод складывающий пару ключь-значение в таблицу
            ///
            /// key">
            /// value">

            public void PutPair(object key, object value)
            {
                var hashCodeOfKey = key.GetHashCode();
                var index = Math.Abs(hashCodeOfKey) % Pairs.Length;
                if (Pairs[index] != null)
                {
                    var element = Pairs[index].FirstOrDefault(x => x.Key == hashCodeOfKey);

                    if (element != null)
                        element.Value = value;
                    else
                        Pairs[index].Add(new KeyAndValue(hashCodeOfKey, value));
                }
                else
                {
                    Pairs[index] = new List<KeyAndValue> { new KeyAndValue(hashCodeOfKey, value) };
                }
            }

         
            /// <summary>
            /// Поиск значения по ключу
            /// summary>
            /// key">Ключь
            /// <returns>Значение, null если ключ отсутствуетreturns>

            public object GetValueByKey(object key)
            {
                try
                {
                    var hashCodeOfKey = key.GetHashCode();
                    var value = Pairs[Math.Abs(hashCodeOfKey) % Pairs.Length];
                    return value.Find(x => x.Key == hashCodeOfKey).Value;
                }
                catch
                {
                    return null;
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
