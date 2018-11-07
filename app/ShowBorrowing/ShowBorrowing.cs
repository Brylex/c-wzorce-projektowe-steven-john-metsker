using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja wykorzystania delegacji BorrowReader i metody
/// lendReader() z klasy DataServices.
/// </summary>
public class ShowBorrowing
{
    public static void Main()
    {
        string sel = "SELECT * FROM ROCKET";
        DataServices.LendReader(sel, new BorrowReader(GetNames));
    }
    private static Object GetNames(IDataReader reader)
    {
        while (reader.Read()) 
        {
            Console.WriteLine(reader["Name"]);
        }
        return null;
    }
}