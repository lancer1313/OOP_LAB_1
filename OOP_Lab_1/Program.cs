
namespace OOP_Lab_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 1, 21ВП2, Левин-Семичев");
            Library library = new Library("MyLibrary", "This is my Library", 700, 30, "My type", true, 4.5);
            Console.WriteLine(library);

            library.TryChangeProperty("Rating", 3.6);
            library.PrintProperty("Rating");
            library.PrintInHex("BooksNumber");

            string? input = Console.ReadLine();
            if (library.TryChangeProperty("Type", input))
            {
                library.PrintProperty("Type");
            }
            else
            {
                Console.WriteLine("Не удалось изменить значение");
            }

            library.WithWiFi = false;
            library.Description = "New description";

            Console.WriteLine(library.WithWiFi);
            Console.WriteLine(library.Description);

        }
    }
}