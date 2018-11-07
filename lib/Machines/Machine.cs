using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Klasa modeluj¹ca maszynê.
    /// </summary>
    public class Machine : MachineComponent
    { 
        private MachinePlanner _planner;
        private TubMediator _mediator = TubMediator.SINGLETON;
        protected Queue _bins = new Queue();
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public Machine(int id) : base (id)
        {
        }      
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze i nazwie.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        /// <param name="name">nazwa maszyny</param>
        public Machine(int id, string name) : base (id, name)
        {
        }        
        /// <summary>
        /// Obs³uga wzorca Visitor.
        /// </summary>
        /// <param name="v">goœæ</param>
        public override void Accept(IMachineVisitor v) 
        {
            v.Visit(this);
        }
        /// <summary>
        /// Zwraca iloœæ maszyn w tej maszynie, a mianowicie 1.
        /// </summary>
        /// <returns>jeden, gdy¿ maszyna zawiera tylko siebie</returns>
        public override int GetMachineCount()
        {
            return 1;
        }

        /// <summary>
        /// Zwraca true, gdy¿ pojedyncze maszyny zawsze s¹ drzewami.
        /// </summary>
        /// <param name="visited">Zbiór odwiedzonych wierzcho³ków</param>
        /// <returns>true, gdy¿ pojedyncze maszyny zawsze s¹ drzewami</returns>
        public override bool IsTree(Hashtable visited)
        {
            visited.Add(ID, this);
            return true;
        }
        /// <summary>
        /// Umieszcza pojemnik przy danej maszynie (i ¿adnej innej).
        /// </summary>
        /// <param name="t">pojemnik</param>
        public void AddTub(Tub t) 
        {
            _mediator.Set(t, this);
        }
        /// <summary>
        /// Zwraca listê pojemników przy bie¿¹cej maszynie.
        /// </summary>
        /// <returns>listê pojemników</returns>
        public IList GetTubs()
        {
            return _mediator.GetTubs(this);
        }

        /// <summary>
        /// Umieszcza podany pojemnik na taœmie wejœciowej bie¿¹cej maszyny.
        /// </summary>
        /// <param name="b">pojemnik</param>
        public void Load(Bin b) 
        {
            _bins.Enqueue(b);
        }

        /// <summary>
        /// Usuwa pierwszy pojemnik na taœmie wyjœciowej maszyny.
        /// </summary>
        /// <returns>pierwszy pojemnik na taœmie wyjœciowej maszyny</returns>
        public Bin Unload()
        {
            if (_bins.Count == 0) 
            {
                return null;
            }
            return (Bin)_bins.Dequeue();
        }
        /// <summary>
        /// Zwraca obiekt planuj¹cy dla tej maszyny.
        /// </summary>
        /// <returns>obiekt planuj¹cy dla tej maszyny</returns>
        public virtual MachinePlanner CreatePlanner() 
        {
            return new BasicPlanner(this);
        }
        /// <summary>
        /// Pobiera obiekt planuj¹cy dla tej maszyny.
        /// </summary>
        /// <returns>obiekt planuj¹cy dla tej maszyny</returns>
        public MachinePlanner GetPlanner() 
        {
            if (_planner == null) 
            {
                _planner = CreatePlanner();
            }
            return _planner;
        }
        
        /// <summary>
        /// Zwraca bie¿¹c¹ maszynê, jeœli zgadza siê jej identyfikator.
        /// </summary>
        /// <param name="id">szukany identyfikator</param>
        /// <returns>bie¿¹c¹ maszynê, jeœli zgadza siê jej identyfikator</returns>
        public override MachineComponent Find(int id)
        {
            if (_id == id) 
            {
                return this;
            }
            return null;
        }
        /// <summary>
        /// Zwraca bie¿¹c¹ maszynê, jeœli zgadza siê jej nazwa.
        /// </summary>
        /// <param name="id">szukana nazwa</param>
        /// <returns>bie¿¹c¹ maszynê, jeœli zgadza siê jej nazwa</returns>
        public override MachineComponent Find(String name)
        {
            if (name.Equals(ToString())) 
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Zwraca true jeœli maszyna ma jakiekolwiek materia³y na taœmie 
        /// wejœciowej, wyjœciowej lub w obszarze roboczym.
        /// </summary>
        /// <returns>true jeœli maszyna ma jakiekolwiek materia³y</returns>
        public bool HasMaterial()
        {
            return _bins.Count > 0;
        }

        /// <summary>
        /// Implementacja tej metody wi¹za³aby siê z interakcj¹ z fizyczn¹
        /// maszyn¹ w celu jej uruchomienia.
        /// </summary>
        public void StartUp()
        {
        }

        /// <summary>
        /// Implementacja tej metody wi¹za³aby siê z interakcj¹ z fizyczn¹
        /// maszyn¹ w celu jej wy³¹czenia.
        /// </summary>
        public void ShutDown()
        {
        }
    }
}
