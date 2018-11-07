using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;

/// Klasa utworzona wy��cznie w celu sprawdzenia u�ycia interfejsu zamiast
/// delegacji BorrowReader.

namespace DataLayer
{
    /// <summary>
    /// Udost�pnia podstawowe us�ugi dost�pu do bazy Oozinoz. Przekszta�cenie
    /// pokazuje spos�b zast�pienia delegacji interfejsem.
    /// </summary>
    public class DataServices2
    {
        /// <summary>
        /// Tworzy obiekt czytaj�cy na podstawie dostarczonego zapytania SQL,
        /// wykonuje metod� BorrowReader dostarczonego obiektu IBorrower 
        /// i zamyka obiekt czytaj�cy.
        /// </summary>
        /// <param name="sql">Wykonywane zapytanie SQL.</param>
        /// <param name="borrower">Obiekt implementuj�cy IBorrower.</param>
        /// <returns>Warto�� zwracana przez dostarczon� metod�.</returns>
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
