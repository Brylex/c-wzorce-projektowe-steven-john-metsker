using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Reprezentuje alternacjê lub sekwencjê etapów procesu.
    /// </summary>
    public abstract class ProcessComposite  : ProcessComponent
    {
        protected IList _subprocesses;
        /// <summary>
        /// W³aœciwoœæ zwracaj¹ca potomków kompozytu.
        /// </summary>
        public IList Children
        {
            get 
            {
                return _subprocesses;
            }
        }
        /// <summary>
        /// Tworzy kompozyt procesu o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa kompozytu procesu</param>
        public ProcessComposite(String name) : this (name, new ArrayList())
        {
        }
        /// <summary>
        /// Tworzy kompozyt o zadanej nazwie, zawieraj¹cy zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa kompozytu</param>
        /// <param name="subprocesses">podprocesy kompozytu</param>
        public ProcessComposite(
            String name, params ProcessComponent[] subprocesses) : base (name)
        {
            _subprocesses = new ArrayList();
            foreach (Object o in subprocesses) 
            {
                _subprocesses.Add(o);
            }         
        }
        /// <summary>
        /// Tworzy kompozyt o zadanej nazwie, zawieraj¹cy zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa kompozytu</param>
        /// <param name="subprocesses">podprocesy kompozytu</param>
        public ProcessComposite(String name, IList subprocesses) : base(name)
        {
            _subprocesses = subprocesses;
        }
        /// <summary>
        /// Dodaje zadany komponent jako potomka.
        /// </summary>
        /// <param name="c">dodawany komponent</param>
        public void Add(ProcessComponent c)
        {
            _subprocesses.Add(c);
        }
        /// <summary>
        /// Zwraca enumerator dla tego kompozytu.
        /// </summary>
        /// <param name="visited">zbiór wêz³ów ju¿ odwiedzonych w ramach bie¿¹cego przejœcia</param>
        /// <returns>enumerator dla tego kompozytu</returns>
        public override ComponentEnumerator GetEnumerator(Set visited)
        {
            return new CompositeEnumerator(this, _subprocesses, visited);
        }
        /// <summary>
        /// Zwraca liczbê etapów (liœci) w drzewie reprezentowanym
        /// przez ten kompozyt.
        /// </summary>
        /// <param name="visited">zbiór wêz³ów ju¿ odwiedzonych w ramach bie¿¹cego przejœcia</param>
        /// <returns>liczbê etapów (liœci) w drzewie reprezentowanym
        /// przez ten kompozyt.
        /// </returns>
        public override int GetStepCount(Hashtable visited)
        {
            visited.Add(Name, this);
            int count = 0;
            foreach (ProcessComponent pc in _subprocesses)
            {
                if (!visited.Contains(pc.Name))
                {
                    count += pc.GetStepCount(visited);
                }
            }
            return count;
        }
    }
}
