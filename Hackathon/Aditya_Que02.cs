using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon
{
    internal class Aditya_Que02
    {
        static List<string> SortTitles(List<string> books)
        {
            var bookInfo = new List<(string author, string title)>();

            foreach (var str in books)
            {
                var parts = str.Split(" by ");
                string title = parts[0].Trim('"');
                string author = parts[1].Split("and")[0];

                bookInfo.Add((author, title));
            }
            return sort(bookInfo);
        }

        private static List<string> sort(List<(string author, string title)> bookInfo)
        {
            for (int i = 0; i < bookInfo.Count - 1; i++)
            {
                for (int j = 0; j < bookInfo.Count - i - 1; j++)
                {
                    bool shouldSwap = true;
                    if (string.Compare(bookInfo[j].author, bookInfo[j + 1].author) < 0)
                    {
                        shouldSwap = false;
                    }
                    else if (bookInfo[j].author == bookInfo[j + 1].author &&
                             string.Compare(bookInfo[j].title, bookInfo[j + 1].title) < 0)
                    {
                        shouldSwap = false;
                    }

                    if (shouldSwap)
                    {
                        var temp = bookInfo[j];
                        bookInfo[j] = bookInfo[j + 1];
                        bookInfo[j + 1] = temp;
                    }
                }
            }
            List<string> sortedTitles = new List<string>();
            foreach (var book in bookInfo)
            {
                sortedTitles.Add(book.title);
            }

            return sortedTitles;
        }
        static void Main()
        {
            Console.Write("How many books do you want to enter? ");
            int n = int.Parse(Console.ReadLine());
            var books = new List<string>();
            Console.WriteLine("Enter each book in the format: \"Title\" by Author");
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                books.Add(input);
            }
            var sortedTitles = SortTitles(books);
            foreach (var title in sortedTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}

