using Advanced.Delegates;
using Advanced.Lambda;
using System;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {


        }

        static void UsingLambda()
        {
            var books = new BookRepository().GetBooks();

            // using a predicate
            var cheapBooks = books.FindAll(IsCheaperThan10);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            // using a lambda instead
            cheapBooks = books.FindAll(book => book.Price < 10);

            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title);
        }

        // predicate method
        static bool IsCheaperThan10(Book book)
        {
            return book.Price < 10;
        }

        static void BasicLambda()
        {
            Console.WriteLine(Square(5));

            // with a lambda
            // args => expression
            // number => number * number;

            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));

            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(10));
        }

        static int Square(int number)
        {
            return number * number;
        }

        static void UsingDelegates()
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");

        }

        static void UsingGenerics()
        {
            var number = new Generics.Nullable<int>();
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());
        }
    }
}
