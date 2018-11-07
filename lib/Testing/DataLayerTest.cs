using System;
using System.Data;
using System.Data.OleDb;
using NUnit.Framework;
using Fireworks;
using DataLayer;

namespace Testing
{
    /// <summary>
    /// Testy NUnit dla warstwy danych.
    /// </summary>
    [TestFixture]
    public class DataLayerTest 
    {
        /// <summary>
        /// Sprawdzenie, czy baza danych istnieje.
        /// </summary>
        public void TestDatabaseAccess() 
        {
            string select = "SELECT * FROM Rocket";
            OleDbDataAdapter adapter = DataServices.CreateAdapter(select);
            adapter.Fill(new DataSet(), "Rocket");
            adapter.Dispose();
        }
        /// <summary>
        /// Sprawdzenie, czy obiekt czytaj�cy jest zamykany po wypo�yczeniu.
        /// </summary>
        public void TestReaderCloses() 
        { 
            string sel = "SELECT * FROM ROCKET";
            // 
            OleDbDataReader r = (OleDbDataReader) 
                DataServices.LendReader(sel, new BorrowReader(useReader));
            Assertion.Assert(r.IsClosed);
        }  
        // Robi cokolwiek z obiektem czytaj�cym i zwraca go. Na og� nie
        // mia�oby to sensu, ale potrzebujemy sprawdzi� obiekt.
        private static Object useReader(IDataReader reader)
        {
            reader.Read(); 
            return reader;
        }
        /// <summary>
        /// Test wykonywany przy wywo�aniach metod Find.
        /// </summary>
        public void TestFinding()
        {
            DataServices.FindAll(typeof(Rocket));
            DataServices.Find(typeof(Rocket), "Orbit");
        }
    }
}
