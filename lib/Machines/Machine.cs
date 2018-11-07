using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Klasa modeluj�ca maszyn�.
    /// </summary>
    public class Machine : MachineComponent
    { 
        private MachinePlanner _planner;
        private TubMediator _mediator = TubMediator.SINGLETON;
        protected Queue _bins = new Queue();
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public Machine(int id) : base (id)
        {
        }      
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze i nazwie.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        /// <param name="name">nazwa maszyny</param>
        public Machine(int id, string name) : base (id, name)
        {
        }        
        /// <summary>
        /// Obs�uga wzorca Visitor.
        /// </summary>
        /// <param name="v">go��</param>
        public override void Accept(IMachineVisitor v) 
        {
            v.Visit(this);
        }
        /// <summary>
        /// Zwraca ilo�� maszyn w tej maszynie, a mianowicie 1.
        /// </summary>
        /// <returns>jeden, gdy� maszyna zawiera tylko siebie</returns>
        public override int GetMachineCount()
        {
            return 1;
        }

        /// <summary>
        /// Zwraca true, gdy� pojedyncze maszyny zawsze s� drzewami.
        /// </summary>
        /// <param name="visited">Zbi�r odwiedzonych wierzcho�k�w</param>
        /// <returns>true, gdy� pojedyncze maszyny zawsze s� drzewami</returns>
        public override bool IsTree(Hashtable visited)
        {
            visited.Add(ID, this);
            return true;
        }
        /// <summary>
        /// Umieszcza pojemnik przy danej maszynie (i �adnej innej).
        /// </summary>
        /// <param name="t">pojemnik</param>
        public void AddTub(Tub t) 
        {
            _mediator.Set(t, this);
        }
        /// <summary>
        /// Zwraca list� pojemnik�w przy bie��cej maszynie.
        /// </summary>
        /// <returns>list� pojemnik�w</returns>
        public IList GetTubs()
        {
            return _mediator.GetTubs(this);
        }

        /// <summary>
        /// Umieszcza podany pojemnik na ta�mie wej�ciowej bie��cej maszyny.
        /// </summary>
        /// <param name="b">pojemnik</param>
        public void Load(Bin b) 
        {
            _bins.Enqueue(b);
        }

        /// <summary>
        /// Usuwa pierwszy pojemnik na ta�mie wyj�ciowej maszyny.
        /// </summary>
        /// <returns>pierwszy pojemnik na ta�mie wyj�ciowej maszyny</returns>
        public Bin Unload()
        {
            if (_bins.Count == 0) 
            {
                return null;
            }
            return (Bin)_bins.Dequeue();
        }
        /// <summary>
        /// Zwraca obiekt planuj�cy dla tej maszyny.
        /// </summary>
        /// <returns>obiekt planuj�cy dla tej maszyny</returns>
        public virtual MachinePlanner CreatePlanner() 
        {
            return new BasicPlanner(this);
        }
        /// <summary>
        /// Pobiera obiekt planuj�cy dla tej maszyny.
        /// </summary>
        /// <returns>obiekt planuj�cy dla tej maszyny</returns>
        public MachinePlanner GetPlanner() 
        {
            if (_planner == null) 
            {
                _planner = CreatePlanner();
            }
            return _planner;
        }
        
        /// <summary>
        /// Zwraca bie��c� maszyn�, je�li zgadza si� jej identyfikator.
        /// </summary>
        /// <param name="id">szukany identyfikator</param>
        /// <returns>bie��c� maszyn�, je�li zgadza si� jej identyfikator</returns>
        public override MachineComponent Find(int id)
        {
            if (_id == id) 
            {
                return this;
            }
            return null;
        }
        /// <summary>
        /// Zwraca bie��c� maszyn�, je�li zgadza si� jej nazwa.
        /// </summary>
        /// <param name="id">szukana nazwa</param>
        /// <returns>bie��c� maszyn�, je�li zgadza si� jej nazwa</returns>
        public override MachineComponent Find(String name)
        {
            if (name.Equals(ToString())) 
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Zwraca true je�li maszyna ma jakiekolwiek materia�y na ta�mie 
        /// wej�ciowej, wyj�ciowej lub w obszarze roboczym.
        /// </summary>
        /// <returns>true je�li maszyna ma jakiekolwiek materia�y</returns>
        public bool HasMaterial()
        {
            return _bins.Count > 0;
        }

        /// <summary>
        /// Implementacja tej metody wi�za�aby si� z interakcj� z fizyczn�
        /// maszyn� w celu jej uruchomienia.
        /// </summary>
        public void StartUp()
        {
        }

        /// <summary>
        /// Implementacja tej metody wi�za�aby si� z interakcj� z fizyczn�
        /// maszyn� w celu jej wy��czenia.
        /// </summary>
        public void ShutDown()
        {
        }
    }
}
