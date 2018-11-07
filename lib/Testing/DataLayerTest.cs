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
        /// Sprawdzenie, czy obiekt czytaj¹cy jest zamykany po wypo¿yczeniu.
        /// </summary>
        public void TestReaderCloses() 
        { 
            string sel = "SELECT * FROM ROCKET";
            // 
            OleDbDataReader r = (OleDbDataReader) 
                DataServices.LendReader(sel, new BorrowReader(useReader));
            Assertion.Assert(r.IsClosed);
        }  
        // Robi cokolwiek z obiektem czytaj¹cym i zwraca go. Na ogó³ nie
        // mia³oby to sensu, ale potrzebujemy sprawdziæ obiekt.
        private static Object useReader(IDataReader reader)
        {
            reader.Read(); 
            return reader;
        }
        /// <summary>
        /// Test wykonywany przy wywo³aniach metod Find.
        /// </summary>
        public void TestFinding()
        {
            DataServices.FindAll(typeof(Rocket));
            DataServices.Find(typeof(Rocket), "Orbit");
        }
    }
}
