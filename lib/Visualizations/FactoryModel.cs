using System;
using System.Drawing;
using System.Collections;

namespace Visualizations
{
    /// <summary>
    /// Model fabryki. W tej chwili zawiera on jedynie lokalizacje maszyn,
    /// ale obs�uguje operacj� cofni�cia poprzez odtwarzanie zapami�tanego
    /// przesz�ego stanu przy ka�dej zmianie konfiguracji fabryki.
    /// </summary>
    public class FactoryModel
    {
        private Stack _mementos;   
        public event AddHandler AddEvent; 
        public event DragHandler DragEvent; 
        public event RebuildHandler RebuildEvent; 
        public static readonly Point DEFAULT_LOCATION = new Point(10, 10);

        /// <summary>
        /// Tworzy nowy model fabryki.
        /// </summary>
        public FactoryModel()
        {
            // na pocz�tku lista lokalizacji maszyn jest pusta
            _mementos = new Stack();
            _mementos.Push(new ArrayList());
        }
        /// <summary>
        /// Dodaje maszyn� do modelu. Maszyna jest ustawiana w lokalizacji
        /// domy�lnej.
        /// </summary>
        public void AddMachine()
        {
            // umieszcza now� maszyn� przed pozosta�ymi (najp�ycej)
            IList newLocs = new ArrayList();
            Point newP = DEFAULT_LOCATION;
            newLocs.Add(newP);
            foreach (Point p in (IList)_mementos.Peek())
            {
                newLocs.Add(new Point(p.X, p.Y));
            }
            _mementos.Push(newLocs);
            if (AddEvent != null) AddEvent(newP);
        }

        /// <summary>
        /// Przesuwa maszyn� z jednego miejsca na drugie. Skutkiem ubocznym
        /// tej operacji jest to, �e nowa lokalizacja zostanie umieszczona
        /// na pierwszym miejscu listy lokalizacji bie��cego modelu, co pomaga
        /// aplikacji ustala� wzajemn� g��boko�� ikon. R�wnie� klikni�cie maszyny
        /// spowoduje umieszczenie jej na pocz�tku listy, a tym samym na przedzie
        /// panelu symulacji.
        /// </summary>
        /// <param name="oldP">stara lokalizacja maszyny</param>
        /// <param name="newP">nowa lokalizacja maszyny</param>
        public void Drag(Point oldP, Point newP) 
        {
            // umieszcza now� lokalizacj� na pocz�tku listy
            IList newLocs = new ArrayList(); 
            newLocs.Add(newP);
            // tworzy now� list�, kopiuj�c wszystkie maszyny poza przeci�gan�
            bool foundDragee = false;
            foreach (Point p in (IList)_mementos.Peek())
            {
                if ( !foundDragee && p.Equals(oldP)) 
                {
                    foundDragee = true;
                }
                else
                {
                    newLocs.Add(new Point(p.X, p.Y)); 
                }
            }
            _mementos.Push(newLocs);
            if (DragEvent != null) DragEvent(oldP, newP);
        }
 
        /// <summary>
        /// Zmienia model fabryki na poprzedni� wersj�.
        /// </summary>
        public void Pop()
        {
            if (_mementos.Count > 1) 
            {
                _mementos.Pop(); // zdj�cie bie��cego stanu ze stosu
                if (RebuildEvent != null) RebuildEvent();
            }
        }
        /// <summary>
        /// Dodaje now� konfiguracj�.
        /// </summary>
        /// <param name="list">lista punkt�w (obiekt�w Point) odpowiadaj�cych lokalizacjom maszyn</param>
        public void Push(IList list)
        {
            _mementos.Push(list);
            if (RebuildEvent != null) RebuildEvent();
        }
        /// <summary>
        /// Zwraca bie��cy zbi�r lokalizacji maszyn.
        /// </summary>
        public IList Locations
        {
            get
            {
                return (IList)_mementos.Peek();
            }
        }

        /// <summary>
        /// Zwraca liczb� zapisanych konfiguracji. Pomaga to aplikacji
        /// ustali�, czy ma oferowa� funkcj� cofni�cia.
        /// </summary>
        public int MementoCount
        {
            get 
            {
                return _mementos.Count;
            }
        }

    }
}