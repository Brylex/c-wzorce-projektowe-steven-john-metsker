using System;

namespace BusinessCore
{
    /// <summary>
    /// Zaœlepka dla klasy uruchamianej na prasie gwiazdowej Aster,
    /// maj¹ca w za³o¿eniu ³¹czyæ wszystkie systemy Oozinoz sk³aduj¹ce
    /// informacje o materia³ach.
    /// </summary>
    public class MaterialManager 
    {
        // wymuszenie u¿ycia singletona
        private MaterialManager()
        {
        }

        /// <summary>
        /// Metoda nie jest implementowana, ale s³u¿y pokazaniu roli 
        /// metody zwracaj¹cej singleton MaterialManager.
        /// </summary>
        /// <returns>singleton mened¿era materia³ów</returns>
        public static MaterialManager GetManager()
        {
            return null;
        }

        /// <summary>
        /// Metoda nieimplementowana. Gdyby by³a zaimplementowana,
        /// informowa³aby systemy Oozinoz, ¿e forma dostarczona z prasy
        /// gwiazdowej jest niekompletnie przetworzona.
        /// </summary>
        /// <param name="id"></param>
        public void SetMoldIncomplete(int id)
        {
        }
    }
}
