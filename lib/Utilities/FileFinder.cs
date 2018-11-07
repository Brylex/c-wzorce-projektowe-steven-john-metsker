using System;
using System.Drawing;
using System.IO;
using System.Reflection;
namespace Utilities
{
    /// <summary>
    /// Klasa dostarczaj¹ca metody statyczne do lokalizacji plików wzglêdem
    /// podkatalogu bin, w którym uruchamiana jest ta jednostka kompilacji.
    /// </summary>
    public class FileFinder
    {
        /// <summary>
        /// Tworzy i zwraca nazwê dla pliku w s¹siednim katalogu. Zmienna
        /// œrodowiskowa OOZINOZ zawiera œcie¿kê katalogu nadrzêdnego dla
        /// podkatalogów lib, app, images i pozosta³ych. Jeœli brak tej zmiennej,
        /// metoda wylicza katalog na podstawie lokalizacji bie¿¹cej jednostki
        /// kompilacji. To na ogó³ skutkuje, ale nie zadzia³a w przypadku 
        /// aplikacji kopiuj¹cych pliki DLL do ró¿nych katalogów, co czyni¹
        /// niektóre œrodowiska testuj¹ce.
        /// </summary>
        /// <param name="dirName">nazwa s¹siedniego katalogu</param>
        /// <param name="fileName">nazwa pliku</param>
        /// <returns>œcie¿kê s¹siedniego pliku</returns>
        public static String GetFileName(String dirName, String fileName)
        {
            String path;
            // Czy da siê odnaleŸæ plik korzystaj¹c ze zmiennej œrodowiskowej OOZINOZ?
            String oozinozBase = Environment.GetEnvironmentVariable("OOZINOZ");
            if (oozinozBase != null) 
            {
                path = Path.Combine(Path.Combine(oozinozBase, dirName), fileName);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            // A mo¿e wzglêdem podkatalogu bin?
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
            // No dobra, to mo¿e pod katalogiem g³ównym?
            path = Path.Combine(Path.Combine(@"\oozinoz", dirName), fileName);
            if (File.Exists(path))
            {
                return path;
            }
            // Guzik
            throw new Exception("FileFinder.GetFileName() nie mo¿e znaleŸæ " + fileName + " w katalogu " + dirName);

        }
    }
}
