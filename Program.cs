using System;
using System.Collections.Generic;
using System.Linq;

class BookInfo
{
    public string Name { get; set; }
    public string Writer { get; set; }
    public int PublishYear { get; set; }

    public BookInfo(string name, string writer, int year)
    {
        Name = name;
        Writer = writer;
        PublishYear = year;
    }
}
// 
class BookManager
{
    private List<BookInfo> bookList = new List<BookInfo>();

    public void InsertNewBook()
    {
        Console.Write("Nhập tên sách: ");
        string name = Console.ReadLine();
        Console.Write("Nhập tác giả: ");
        string writer = Console.ReadLine();
        Console.Write("Nhập năm xuất bản: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            bookList.Add(new BookInfo(name, writer, year));
            Console.WriteLine("Sách đã được thêm thành công!\n");
        }
        else
        {
            Console.WriteLine("Năm xuất bản không hợp lệ!\n");
        }
    }

    public void ShowAllBooks()
    {
        if (bookList.Count == 0)
        {
            Console.WriteLine("Chưa có sách nào trong hệ thống.\n");
            return;
        }
        Console.WriteLine("Danh sách sách:");
        foreach (var book in bookList)
        {
            Console.WriteLine($"Tên sách: {book.Name}, Tác giả: {book.Writer}, Năm: {book.PublishYear}");
        }
        Console.WriteLine();
    }

    public void FindBookByTitle()
    {
        Console.Write("Nhập tên sách cần tìm: ");
        string name = Console.ReadLine();
        var foundBooks = bookList.Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundBooks.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"Tên sách: {book.Name}, Tác giả: {book.Writer}, Năm: {book.PublishYear}");
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy sách!\n");
        }
    }

    public void FilterBooksByWriter()
    {
        Console.Write("Nhập tên tác giả: ");
        string writer = Console.ReadLine();
        var filteredBooks = bookList.Where(b => b.Writer.Equals(writer, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredBooks.Count > 0)
        {
            Console.WriteLine("Danh sách sách của tác giả này:");
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"Tên sách: {book.Name}, Năm: {book.PublishYear}");
            }
        }
        else
        {
            Console.WriteLine("Không có sách nào của tác giả này!\n");
        }
    }
}

class App
{
    static void Main()
    {
        BookManager manager = new BookManager();
        while (true)
        {
            Console.WriteLine("\nHe Thong Quan Ly Sach:");
            Console.WriteLine("1. Them sach moi");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Tim kiem sach theo ten");
            Console.WriteLine("4. Loc sach theo tac gia");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    manager.InsertNewBook();
                    break;
                case "2":
                    manager.ShowAllBooks();
                    break;
                case "3":
                    manager.FindBookByTitle();
                    break;
                case "4":
                    manager.FilterBooksByWriter();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!\n");
                    break;
            }
        }
    }
}
