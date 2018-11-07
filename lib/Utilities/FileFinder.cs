using System;
using System.Drawing;
using System.IO;
using System.Reflection;
namespace Utilities
{
    /// <summary>
    /// Klasa dostarczaj�ca metody statyczne do lokalizacji plik�w wzgl�dem
    /// podkatalogu bin, w kt�rym uruchamiana jest ta jednostka kompilacji.
    /// </summary>
    public class FileFinder
    {
        /// <summary>
        /// Tworzy i zwraca nazw� dla pliku w s�siednim katalogu. Zmienna
        /// �rodowiskowa OOZINOZ zawiera �cie�k� katalogu nadrz�dnego dla
        /// podkatalog�w lib, app, images i pozosta�ych. Je�li brak tej zmiennej,
        /// metoda wylicza katalog na podstawie lokalizacji bie��cej jednostki
        /// kompilacji. To na og� skutkuje, ale nie zadzia�a w przypadku 
        /// aplikacji kopiuj�cych pliki DLL do r�nych katalog�w, co czyni�
        /// niekt�re �rodowiska testuj�ce.
        /// </summary>
        /// <param name="dirName">nazwa s�siedniego katalogu</param>
        /// <param name="fileName">nazwa pliku</param>
        /// <returns>�cie�k� s�siedniego pliku</returns>
        public static String GetFileName(String dirName, String fileName)
        {
            String path;
            // Czy da si� odnale�� plik korzystaj�c ze zmiennej �rodowiskowej OOZINOZ?
            String oozinozBase = Environment.GetEnvironmentVariable("OOZINOZ");
            if (oozinozBase != null) 
            {
                path = Path.Combine(Path.Combine(oozinozBase, dirName), fileName);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            // A mo�e wzgl�dem podkatalogu bin?
            Assembly a = Assembly.GetAssembly(typeof(FileFinder));
            DirectoryInfo thisDir = Directory.GetParent(a.Location);
            DirectoryInfo parentDir = Directory.GetParent(thisDir.FullName);
            path = Path.Combine(
                parentDir.FullName, 
                dirName + Path.DirectorySeparatorChar + fileName);
            if (File.Exists(path))
            {
                return path;
            }
            // No dobra, to mo�e pod katalogiem g��wnym?
            path = Path.Combine(Path.Combine(@"\oozinoz", dirName), fileName);
            if (File.Exists(path))
            {
                return path;
            }
            // Guzik
            throw new Exception("FileFinder.GetFileName() nie mo�e znale�� " + fileName + " w katalogu " + dirName);

        }
    }
}
