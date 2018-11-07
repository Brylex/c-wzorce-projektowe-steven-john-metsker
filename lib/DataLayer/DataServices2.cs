using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;

/// Klasa utworzona wy³¹cznie w celu sprawdzenia u¿ycia interfejsu zamiast
/// delegacji BorrowReader.

namespace DataLayer
{
    /// <summary>
    /// Udostêpnia podstawowe us³ugi dostêpu do bazy Oozinoz. Przekszta³cenie
    /// pokazuje sposób zast¹pienia delegacji interfejsem.
    /// </summary>
    public class DataServices2
    {
        /// <summary>
        /// Tworzy obiekt czytaj¹cy na podstawie dostarczonego zapytania SQL,
        /// wykonuje metodê BorrowReader dostarczonego obiektu IBorrower 
        /// i zamyka obiekt czytaj¹cy.
        /// </summary>
        /// <param name="sql">Wykonywane zapytanie SQL.</param>
        /// <param name="borrower">Obiekt implementuj¹cy IBorrower.</param>
        /// <returns>Wartoœæ zwracana przez dostarczon¹ metodê.</returns>
        public static object LendReader2(string sql, IBorrower borrower) 
        {
            using (OleDbConnection conn = DataServices.CreateConnection())
            {
                conn.Open(); 
                OleDbCommand c = new OleDbCommand(sql, conn);  
                OleDbDataReader r = c.ExecuteReader();
                return borrower.BorrowReader(r);
            }     
        }
    }
}
