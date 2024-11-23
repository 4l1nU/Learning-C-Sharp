using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Exceptions.Program;

namespace Exceptions
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            OrderByEx1();
        }

        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void OrderByEx1()
        {
            Pet[] pets = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            foreach (Pet pet in query)
            {
                Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
            }
        }

        /*
         This code produces the following output:

         Whiskers - 1
         Boots - 4
         Barley - 8
        */

        private class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
        {
            IEnumerable<TSource> sortedEnumerable;

            public OrderedEnumerable(IEnumerable<TSource> source)
            {
                var sourceList = source.ToList();
                sourceList.Sort();
                sortedEnumerable = sourceList;
            }

            public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        /*public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector)
        {
            var defaultComparer = Comparer<TKey>.Default;
            foreach (var item1 in source)
            {
                TSource smallest = item1;
                foreach (var item2 in source)
                {
                    if (defaultComparer.Compare(keySelector(smallest), keySelector(item2)) > 0)
                    {
                        smallest = item2;
                    }
                }

                yield return smallest;
            }

        }*/

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            var keys = new HashSet<TKey>(comparer);
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (!keys.Add(key))
                {
                    continue;
                }

                var keyElements = new List<TElement>();
                foreach (var element in source)
                {
                    if (!keys.Add(keySelector(element)))
                    {
                        keyElements.Add(elementSelector(element));
                    }
                }

                yield return resultSelector(key, keyElements);
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
   this IEnumerable<TSource> first,
   IEnumerable<TSource> second,
   IEqualityComparer<TSource> comparer)
        {
            var uniqueItems = new HashSet<TSource>(comparer);
            foreach (var item in second)
            {
                uniqueItems.Add(item);
            }

            foreach (var item in first)
            {
                if (uniqueItems.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            var uniqueItems = new HashSet<TSource>(comparer);
            foreach (var item in first)
            {
                if (!uniqueItems.Add(item))
                {
                    yield return item;
                }
            }

            foreach (var item in second)
            {
                if (!uniqueItems.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            var uniqueItems = new HashSet<TSource>(comparer);
            foreach (var item in first)
            {
                if (uniqueItems.Add(item))
                {
                    yield return item;
                }
            }

            foreach (var item in second)
            {
                if (uniqueItems.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
       this IEnumerable<TSource> source,
       IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> uniqueItems = new HashSet<TSource>(comparer);
            foreach (TSource item in source)
            {
                if (uniqueItems.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer,
    IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector,
    Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner, TResult> resultSelector)
        {
            foreach (var outerItem in outer)
            {
                foreach (var innerItem in inner)
                {
                    if (outerKeySelector(outerItem).Equals(innerKeySelector(innerItem)))
                    {
                        yield return resultSelector(outerItem, innerItem);
                    }
                }
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
    this IEnumerable<TSource> source,
    TAccumulate seed,
    Func<TAccumulate, TSource, TAccumulate> func)
        {
            foreach (var item in source)
            {
                seed = func(seed, item);
            }

            return seed;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
    this IEnumerable<TFirst> first,
    IEnumerable<TSecond> second,
    Func<TFirst, TSecond, TResult> resultSelector)
        {
            var secondEnumerator = second.GetEnumerator();
            foreach (var item in first)
            {
                if (!secondEnumerator.MoveNext())
                {
                    yield break;
                }

                yield return resultSelector(item, secondEnumerator.Current);
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    Func<TSource, TElement> elementSelector)
        {
            var dicionary = new Dictionary<TKey, TElement>();
            foreach (var item in source)
            {
                dicionary.Add(keySelector(item), elementSelector(item));
            }

            return dicionary;
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }


        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var sourceItem in source)
            {
                foreach (var selectorItem in selector(sourceItem))
                {
                    yield return selectorItem;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /* GetAverage(new int[] { 1, 2, 3});
             GetAverage(new object[] { 1, 2, 3 , 4, 5, "a" });
             PrintElement(new int[] { 1 }, 2);
             InvalidCastEx();*/
        private static void GetAverage<T>(T[] array)
        {
            int average = 0;
            try
            {
                foreach (var element in array)
                {
                    average += Convert.ToInt32(element);
                }

                average /= array.Length;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("GetAverage");
            }
        }

        private static void InvalidCastEx()
        {
            var array = new List<object> { 2, 3, "abc" };
            int sum = 0;
            try
            {
                for (int i = 0; i < array.Count; i++)
                {
                    sum += (int)array[i];
                }
            }

            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.GetType());
                Console.WriteLine(sum);
            }
            finally
            {
                Console.WriteLine("InvalidCastEx");
            }

        }

        private static void PrintElement<T>(T[] array, int index)
        {
            try
            {
                Console.WriteLine(array[index]);
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Nu exista acest element");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Acestea sunt toate elementele din array");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());
            }
            finally
            {
                Console.WriteLine("PrintElement");
            }
        }
    }
}
