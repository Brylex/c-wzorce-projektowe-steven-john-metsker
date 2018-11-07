using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;
using Utilities;

namespace DataLayer
{
    /// <summary>
    /// Delegacja definiuj¹ca interfejs dla metod otrzymuj¹cych (po¿yczaj¹cych)
    /// obiekt czytaj¹cy z bazy danych. Obiekt wypo¿yczaj¹cy mo¿e wywo³ywaæ
    /// delegacjê, tworz¹c obiekt czytaj¹cy przed wywo³aniem i zwalniaj¹c zasoby
    /// tego obiektu po zakoñczeniu wywo³ania.
    /// </summary>
    public delegate object BorrowReader(IDataReader reader);
    /// <summary>
    /// Dostarcza podstawowe us³ugi dostêpu do bazy danych Oozinoz.
    /// </summary>
    public class DataServices
    {
        /// <summary>
        /// Utworzenie obiektu czytaj¹cego na podstawie podanego zapytania SQL,
        /// a nastêpnie wykonanie dostarczonej delegacji (metody po¿yczaj¹cej
        /// obiekt czytaj¹cy) i zamkniêcie obiektu czytaj¹cego.
        /// </summary>
        /// <param name="sql">Wykonywanie zapytanie SQL.</param>
        /// <param name="method">Wywo³ywana metoda korzystaj¹ca z obiektu czytaj¹cego.</param>
        /// <returns>Wartoœæ zwracana przez dostarczon¹ metodê.</returns>
        public static object LendReader(string sql, BorrowReader borrower) 
        {
            using (OleDbConnection conn = CreateConnection())
            {
                conn.Open(); 
                OleDbCommand c = new OleDbCommand(sql, conn);  
                OleDbDataReader r = c.ExecuteReader();
                return borrower(r);
            }     
        }
        /// <summary>
        /// Utworzenie i zwrócenie po³¹czenia z baz¹ danych Access Oozinoz.
        /// </summary>
        /// <returns>po³¹czenie</returns>
        public static OleDbConnection CreateConnection()
        { 
            String dbName = FileFinder.GetFileName("db", "oozinoz.mdb");
            OleDbConnection c = new OleDbConnection();
            c.ConnectionString = 
                "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + dbName;
            return c;
        }
        /// <summary>
        /// Utworzenie i zwrócenie adaptera bazy danych dla dostarczonego
        /// zapytania SQL.
        /// </summary>
        /// <param name="select">Wykonywane zapytanie SQL</param>
        /// <returns>Adapter</returns>
        public static OleDbDataAdapter CreateAdapter(string select) 
        {   
            return new OleDbDataAdapter(select, CreateConnection());  
        }        
        /// <summary>
        /// Utworzenie i zwrócenie obiektu DataTable, sk³aduj¹cego wyniki
        /// zwrócone przez podane zapytanie SQL.
        /// </summary>
        /// <param name="select">Zapytanie SQL</param>
        /// <returns>Obiekt DataTable</returns>
        public static DataTable CreateTable(string select) 
        {   
            return (DataTable) LendReader(select, new BorrowReader(CreateTable));
        } 
        // Tworzy obiekt DataTable z zadanego obieku czytaj¹cego
        internal static object CreateTable(IDataReader reader) 
        {
            DataTable table = new DataTable(); 
            for (int i = 0; i < reader.FieldCount; i++) 
            { 
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }   
            while (reader.Read()) 
            {
                DataRow dr = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++) 
                {
                    dr[i] = reader.GetValue(i);
                }     
                table.Rows.Add(dr);
            }
            return table;
        }
        /// <summary>
        /// Zwraca instancjê podanego typu, wype³nion¹ danymi z bazy Oozinoz.
        /// </summary>
        /// <param name="t">Typ tworzonego obiektu</param>
        /// <param name="name">Nazwa obiektu szukanego w bazie</param>
        /// <returns>Gotowy obiekt</returns>
        public static Object Find(Type t, string name)         
        {
            string sel = "SELECT * FROM " + t.Name + " WHERE NAME = '" + name + "'";
            return LendReader(sel, new BorrowReader(new ObjectLoader(t).LoadObject));
        } 
        /// <summary>
        /// Wyszukuje w bazie wszystkie obiekty danego typu.
        /// </summary>
        /// <param name="t">Typ tworzonego obiektu</param>
        /// <returns>Listê obiektów odpowiadaj¹cych rekordom w tabeli w bazie,
        /// dla których nazwa odpowiada podanemu typowi.
        /// </returns>
        public static IList FindAll(Type t)         
        {
            string sel = "SELECT * FROM " + t.Name;
            return (IList) LendReader(sel, new BorrowReader(new ObjectLoader(t).LoadAll));
        } 
        //
        // Instancje tej klasy sk³aduj¹ typ obiektu do utworzenia 
        // i zape³nienia danymi z obiektu czytaj¹cego z bazy
        //
        internal class ObjectLoader
        {
            private Type _type;
            //
            // Tworzy obiekt ObjectLoader dla danego typu.
            //
            public ObjectLoader(Type t)
            {
                this._type = t;
            }
            //
            // Odczytanie nastêpnego rekordu z obiektu czytaj¹cego i wczytanie
            // danych do pojedynczego obiektu.
            //
            internal Object LoadObject(IDataReader reader)
            {
                if (reader.Read()) 
                { 
                    return LoadFromCurrent(reader);
                }
                return null;
            }
            //
            // Tworzy listê obiektów odpowiadaj¹cych kolejnym rekordom
            // w bazie danych.
            //
            internal Object LoadAll(IDataReader reader)
            {
                ArrayList list = new ArrayList();
                while (reader.Read()) 
                {
                    list.Add(LoadFromCurrent(reader));
                }
                return list;
            }
            //
            // Tworzy i ³aduje pojedynczy obiekt z bie¿¹cego rekordu 
            // w dostarczonym obiekcie czytaj¹cym.
            //
            internal Object LoadFromCurrent(IDataReader reader) 
            {
                ConstructorInfo c = _type.GetConstructor(new Type[]{});
                Object o = c.Invoke(new Object[]{});
                foreach (PropertyInfo p in _type.GetProperties()) 
                {
                    MethodInfo m = p.GetSetMethod();
                    try 
                    {
                        m.Invoke(o, new Object[]{reader[p.Name]});
                    }
                    catch (System.IndexOutOfRangeException) {}
                }
                return o;
            }
        }
    }
}
