using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja wykorzystania delegacji BorrowReader i metody
/// lendReader() z klasy DataServices.
/// </summary>
public class ShowBorrowing2 : IBorrower
{
    public static void Main()
    {
        string sel = "SELECT * FROM ROCKET";
        DataServices2.LendReader2(sel, new ShowBorrowing2());
    }
    public object BorrowReader(IDataReader reader)
    {
        while (reader.Read()) 
        {
            Console.WriteLine(reader["Name"]);
        }
        return null;
    }
}