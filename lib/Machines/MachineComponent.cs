using System;
using System.Collections;

namespace Machines
{ 
    /// <summary>
    /// Obiekty tej klasy stanowi¹ pojedyncze maszyny lub kompozyty maszyn.
    /// </summary>
    public abstract class MachineComponent : VisualizationItem
    {
        protected int _id;
        protected string _name;
        private MachineComponent _parent;
        private Engineer _responsible;
        /// <summary>
        /// Komponent maszyny mo¿e mieæ swojego in¿yniera odpowiedzialnego.
        /// </summary>
        public Engineer Responsible
        {
            get
            {
                if (_responsible != null)
                {
                    return _responsible;
                }
                if (_parent != null)
                {
                    return _parent.Responsible;
                }
                return null;
            }
            set
            {
                this._responsible = value;
            }
        }
        /// <summary>
        /// Niektóre grupy maszyn nale¿¹ do innych grup, na przyk³ad maszyna
        /// mo¿e nale¿eæ do sektora, a sektor do fabryki. Przynale¿noœæ jest
        /// tu równoznaczna posiadaniu rodzica w strukturze maszyn.
        /// </summary>
        public MachineComponent Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                this._parent = value;
            }
        }
        /// <summary>
        /// Unikalny identyfikator grupy maszyn.
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// Tworzy maszynê lub grupê maszyn.
        /// </summary>
        /// <param name="id">Unikalny identyfikator maszyny lub grupy</param>
        public MachineComponent(int id) 
        {
            _id = id;
        }
        /// <summary>
        /// Tworzy maszynê lub grupê maszyn i nadaje jej nazwê.
        /// </summary>
        /// <param name="id">Unikalny identyfikator maszyny lub grupy</param>
        /// <param name="name">Nazwa maszyny lub grupy</param>
        public MachineComponent(int id, string name): this(id)
        {
            _name = name;
        }
        /// <summary>
        /// Obs³uga zewnêtrznych goœci dodaj¹cych nowe operacje do hierarchii.
        /// Opis w rozdziale Visitor.
        /// </summary>
        /// <param name="v">goœæ</param>
        public abstract void Accept(IMachineVisitor v);
        /// <summary>
        /// Zwraca liczbê maszyn w liœciach bie¿¹cego kompozytu.
        /// </summary>
        /// <returns>liczbê maszyn w liœciach bie¿¹cego kompozytu</returns>
        public abstract int GetMachineCount();
        /// <summary>
        /// Zwraca true jeœli bie¿¹cy komponent znajduje siê nad grafem 
        /// acyklicznym, w którym ¿aden wêze³ nie ma dwóch rodziców (dwóch
        /// odwo³añ do siebie).
        /// </summary>
        /// <returns>true jeœli bie¿¹cy komponent znajduje siê nad grafem 
        /// acyklicznym, w którym ¿aden wêze³ nie ma dwóch rodziców
        /// </returns>
        public bool IsTree()
        {
            return IsTree(new Hashtable());
        }
        /// <summary>
        /// Klasy potomne implementuj¹ metodê w celu obs³u¿enia algorytmu isTree().
        /// </summary>
        /// <param name="s">Zbiór odwiedzonych wêz³ów</param>
        /// <returns>true jeœli obiekt jest drzewem</returns>
        public abstract bool IsTree(Hashtable visited);
        /// <summary>
        /// Zwraca true jeœli z biznesowego punktu widzenia bie¿¹cy komponent
        /// i dostarczony obiekt odwo³uj¹ siê do tej samej maszyny.
        /// </summary>
        /// <param name="o">Porównywany obiekt</param>
        /// <returns>true jeœli bie¿¹cy obiekt i dostarczony obiekt 
        /// odwo³uj¹ siê do tej samej maszyny</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (!(o is MachineComponent))
            {
                return false;
            }                                                    
            MachineComponent mc = (MachineComponent) o;
            return _id == mc.ID;
        }
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
        /// <summary>
        /// Zwraca tekstowy opis komponentu.
        /// </summary>
        /// <returns>tekstowy opis komponentu</returns>
        public override String ToString()
        {
            if (_name != null)
            {
                return _name;
            }
            return GetType().Name + ":" + ID.ToString("0000");
        }
        /// <summary>
        /// W bie¿¹cym grafie znajdŸ maszynê o zadanym identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator szukanej maszyny</param>
        /// <returns>maszynê o ¿¹danym identyfikatorze</returns>
        public abstract MachineComponent Find(int id);
        
        /// <summary>
        /// W bie¿¹cym grafie znajdŸ maszynê o podanej nazwie.
        /// </summary>
        /// <param name="id">nazwa szukanej maszyny</param>
        /// <returns>maszynê o szukanej nazwie</returns>
        public abstract MachineComponent Find(String name);

    }
}
