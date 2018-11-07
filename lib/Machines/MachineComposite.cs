using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Reprezentuje zbiór maszyn: liniê produkcyjn¹, sektor lub fabrykê.
    /// </summary>
    public class MachineComposite : MachineComponent 
    {
        protected IList _components = new ArrayList();
        /// <summary>
        /// Obs³uga wzorca Visitor.
        /// </summary>
        /// <param name="v">goœæ</param>
        public override void Accept(IMachineVisitor v) 
        {
            v.Visit(this);
        }
        /// <summary>
        /// Dodaje podany komponent jako potomka.
        /// </summary>
        /// <param name="component">dodawany komponent</param>
        public void Add(MachineComponent component)
        {
            _components.Add(component);
        }
        /// <summary>
        /// Zwraca liczbê maszyn (liœci) w drzewie reprezentowanym przez
        /// bie¿¹cy kompozyt.
        /// </summary>
        /// <returns></returns>
        public override int GetMachineCount()
        {
            int count = 0;
            foreach (MachineComponent mc in _components)
            {
                count += mc.GetMachineCount();
            }
            return count;
        }
        /// <summary>
        /// Tworzy kompozyt o zadanym identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator kompozytu</param>
        public MachineComposite(int id) : base (id)
        {
        }
        /// <summary>
        /// Tworzy kompozyt o zadanym identyfikatorze i nazwie.
        /// </summary>
        /// <param name="id">identyfikator kompozytu</param>
        /// <param name="name">nazwa kompozytu</param>
        public MachineComposite(int id, string name) : base (id, name)
        {
        }
        /// <summary>
        /// W³aœciwoœæ zwracaj¹ca potomków kompozytu.
        /// </summary>
        public IList Children
        {
            get 
            {
                return _components;
            }
        }
        /// <summary>
        /// Dodaje podane komponenty jako potomków.
        /// </summary>
        /// <param name="children">dodawane komponenty</param>
        public void Add(MachineComponent[] children)
        {
            for (int i = 0; i < children.Length; i++)
            {
                _components.Add(children[i]);
            }
        } 
        /// <summary>
        /// Zwraca true jeœli bie¿¹cy kompozyt jest drzewem.
        /// </summary>
        /// <param name="visited">zbiór odwiedzonych wêz³ów</param>
        /// <returns>true jeœli bie¿¹cy kompozyt jest drzewem</returns>
        public override bool IsTree(Hashtable visited)
        {
            visited.Add(this.ID, this);
            foreach (MachineComponent mc in _components)
            {
                if (visited.Contains(mc.ID) || !mc.IsTree(visited))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Zwraca komponent w grafie maszyn, którego identyfikator 
        /// odpowiada podanemu.
        /// </summary>
        /// <param name="id">szukany identyfikator</param>
        /// <returns>komponent w grafie maszyn, którego identyfikator odpowiada podanemu</returns>
        public override MachineComponent Find(int id) 
        {
            if (_id == id) 
            {
                return this;
            }
            foreach (MachineComponent child in _components)
            {
                MachineComponent mc = child.Find(id);
                if (mc != null) 
                {
                    return mc;
                }
            }
            return null;
        }
        /// <summary>
        /// Zwraca komponent w grafie maszyn, którego nazwa odpowiada podanej.
        /// </summary>
        /// <param name="id">szukana nazwa</param>
        /// <returns>komponent w grafie maszyn, którego nazwa odpowiada podanej</returns>
        public override MachineComponent Find(String name) 
        {
            if (name.Equals(ToString()))
            {
                return this;
            }
            foreach (MachineComponent child in _components)
            {
                MachineComponent mc = child.Find(name);
                if (mc != null) 
                {
                    return mc;
                }
            }
            return null;
        }
    }
}
