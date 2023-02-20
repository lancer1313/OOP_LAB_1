using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_1
{
    /// <summary>
    /// Класс, реализующий библиотеку
    /// </summary>
    internal class Library
    {
        /// <summary>
        /// Свойство названия библиотеки
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Свойство описания библиотеки
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Свойство количества книг в библиотеке
        /// </summary>
        public long BooksNumber { get; set; }
        /// <summary>
        /// Свойство количества читальных залов в библиотеке
        /// </summary>
        public int ReadingRoomsCount { get; set; }
        /// <summary>
        /// Свойство типа библиотеки
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// Свойство наличия WiFi в библиотеке
        /// </summary>
        public bool WithWiFi { get; set; }
        /// <summary>
        /// Свойство рейтинга библиотеки
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Library()
        {

        }

        /// <summary>
        /// Конструктор с одним параметром
        /// </summary>
        /// <param name="name">Название библиотеки</param>
        public Library(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Конструктор с двумя праметрами
        /// </summary>
        /// <param name="name">Название библиотеки</param>
        /// <param name="type">Тип библиотеки</param>
        public Library(string name, string type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Конструктор со всеми параметрами
        /// </summary>
        /// <param name="name">Название библиотеки</param>
        /// <param name="description">Описание библиотеки</param>
        /// <param name="booksNumber">Количество книг в библиотеке</param>
        /// <param name="readingRoomsCount">Количество читальных залов в библиотеке</param>
        /// <param name="type">Тип библиотеки</param>
        /// <param name="withWiFi">Наличие WiFi</param>
        /// <param name="rating">Рейтинг библиотеки</param>
        public Library(string name, string description, long booksNumber, int readingRoomsCount, string type, bool withWiFi, double rating)
        {
            Name = name;
            Description = description;
            BooksNumber = booksNumber;
            ReadingRoomsCount = readingRoomsCount;
            Type = type;
            WithWiFi = withWiFi;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Library. Name: {Name}, Description: {Description}, BooksNumber: {BooksNumber}, ReadingRoomsCount: {ReadingRoomsCount}, Type: {Type}, " +
                $"WithWiFi: {WithWiFi}, Rating: {Rating}";
        }

        /// <summary>
        /// Меняет значение свойства
        /// </summary>
        /// <param name="propertyName">Имя свойства для замены</param>
        /// <param name="value">Новое значение свойства</param>
        /// <returns>Возвращает true, если замена произошла успешно, иначе false</returns>
        public bool TryChangeProperty(string propertyName, object value)
        {
            var property = typeof(Library).GetProperty(propertyName);
            if (property == null)
            {
                return false;
            }
            try
            {
                property.SetValue(this, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Выводит в консоль значение указанного свойства
        /// </summary>
        /// <param name="propertyName">Имя свойства для вывода</param>
        public void PrintProperty(string propertyName)
        {
            var property = typeof(Library).GetProperty(propertyName);
            if (property != null)
            {
                Console.WriteLine($"{propertyName}: {property.GetValue(this)}");
            }
            else
            {
                Console.WriteLine("Свойство не найдено");
            }
        }

        /// <summary>
        /// Выводит в консоль значение численного свойства в шестнадцатиричном формате
        /// </summary>
        /// <param name="propertyName">Имя свойства для вывода</param>
        public void PrintInHex(string propertyName)
        {
            var property = typeof(Library).GetProperty(propertyName);
            if (property == null)
            {
                Console.WriteLine("Свойство не найдено");
                return;
            }
            try
            {
                ulong value = Convert.ToUInt64(property.GetValue(this));
                Console.WriteLine(value.ToString("X"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Данное поле не является числом");
            }
        }
    }
}
