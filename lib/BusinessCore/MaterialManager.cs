using System;

namespace BusinessCore
{
    /// <summary>
    /// Za�lepka dla klasy uruchamianej na prasie gwiazdowej Aster,
    /// maj�ca w za�o�eniu ��czy� wszystkie systemy Oozinoz sk�aduj�ce
    /// informacje o materia�ach.
    /// </summary>
    public class MaterialManager 
    {
        // wymuszenie u�ycia singletona
        private MaterialManager()
        {
        }

        /// <summary>
        /// Metoda nie jest implementowana, ale s�u�y pokazaniu roli 
        /// metody zwracaj�cej singleton MaterialManager.
        /// </summary>
        /// <returns>singleton mened�era materia��w</returns>
        public static MaterialManager GetManager()
        {
            return null;
        }

        /// <summary>
        /// Metoda nieimplementowana. Gdyby by�a zaimplementowana,
        /// informowa�aby systemy Oozinoz, �e forma dostarczona z prasy
        /// gwiazdowej jest niekompletnie przetworzona.
        /// </summary>
        /// <param name="id"></param>
        public void SetMoldIncomplete(int id)
        {
        }
    }
}
