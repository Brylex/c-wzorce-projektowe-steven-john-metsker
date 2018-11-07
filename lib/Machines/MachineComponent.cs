using System;
using System.Collections;

namespace Machines
{ 
    /// <summary>
    /// Obiekty tej klasy stanowi� pojedyncze maszyny lub kompozyty maszyn.
    /// </summary>
    public abstract class MachineComponent : VisualizationItem
    {
        protected int _id;
        protected string _name;
        private MachineComponent _parent;
        private Engineer _responsible;
        /// <summary>
        /// Komponent maszyny mo�e mie� swojego in�yniera odpowiedzialnego.
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
        /// Niekt�re grupy maszyn nale�� do innych grup, na przyk�ad maszyna
        /// mo�e nale�e� do sektora, a sektor do fabryki. Przynale�no�� jest
        /// tu r�wnoznaczna posiadaniu rodzica w strukturze maszyn.
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
        /// Tworzy maszyn� lub grup� maszyn.
        /// </summary>
        /// <param name="id">Unikalny identyfikator maszyny lub grupy</param>
        public MachineComponent(int id) 
        {
            _id = id;
        }
        /// <summary>
        /// Tworzy maszyn� lub grup� maszyn i nadaje jej nazw�.
        /// </summary>
        /// <param name="id">Unikalny identyfikator maszyny lub grupy</param>
        /// <param name="name">Nazwa maszyny lub grupy</param>
        public MachineComponent(int id, string name): this(id)
        {
            _name = name;
        }
        /// <summary>
        /// Obs�uga zewn�trznych go�ci dodaj�cych nowe operacje do hierarchii.
        /// Opis w rozdziale Visitor.
        /// </summary>
        /// <param name="v">go��</param>
        public abstract void Accept(IMachineVisitor v);
        /// <summary>
        /// Zwraca liczb� maszyn w li�ciach bie��cego kompozytu.
        /// </summary>
        /// <returns>liczb� maszyn w li�ciach bie��cego kompozytu</returns>
        public abstract int GetMachineCount();
        /// <summary>
        /// Zwraca true je�li bie��cy komponent znajduje si� nad grafem 
        /// acyklicznym, w kt�rym �aden w�ze� nie ma dw�ch rodzic�w (dw�ch
        /// odwo�a� do siebie).
        /// </summary>
        /// <returns>true je�li bie��cy komponent znajduje si� nad grafem 
        /// acyklicznym, w kt�rym �aden w�ze� nie ma dw�ch rodzic�w
        /// </returns>
        public bool IsTree()
        {
            return IsTree(new Hashtable());
        }
        /// <summary>
        /// Klasy potomne implementuj� metod� w celu obs�u�enia algorytmu isTree().
        /// </summary>
        /// <param name="s">Zbi�r odwiedzonych w�z��w</param>
        /// <returns>true je�li obiekt jest drzewem</returns>
        public abstract bool IsTree(Hashtable visited);
        /// <summary>
        /// Zwraca true je�li z biznesowego punktu widzenia bie��cy komponent
        /// i dostarczony obiekt odwo�uj� si� do tej samej maszyny.
        /// </summary>
        /// <param name="o">Por�wnywany obiekt</param>
        /// <returns>true je�li bie��cy obiekt i dostarczony obiekt 
        /// odwo�uj� si� do tej samej maszyny</returns>
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
        /// W bie��cym grafie znajd� maszyn� o zadanym identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator szukanej maszyny</param>
        /// <returns>maszyn� o ��danym identyfikatorze</returns>
        public abstract MachineComponent Find(int id);
        
        /// <summary>
        /// W bie��cym grafie znajd� maszyn� o podanej nazwie.
        /// </summary>
        /// <param name="id">nazwa szukanej maszyny</param>
        /// <returns>maszyn� o szukanej nazwie</returns>
        public abstract MachineComponent Find(String name);

    }
}
