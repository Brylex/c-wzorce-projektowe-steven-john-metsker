using System;
using System.Drawing;
using System.Collections;

namespace Visualizations
{
    /// <summary>
    /// Model fabryki. W tej chwili zawiera on jedynie lokalizacje maszyn,
    /// ale obs³uguje operacjê cofniêcia poprzez odtwarzanie zapamiêtanego
    /// przesz³ego stanu przy ka¿dej zmianie konfiguracji fabryki.
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
            // na pocz¹tku lista lokalizacji maszyn jest pusta
            _mementos = new Stack();
            _mementos.Push(new ArrayList());
        }
        /// <summary>
        /// Dodaje maszynê do modelu. Maszyna jest ustawiana w lokalizacji
        /// domyœlnej.
        /// </summary>
        public void AddMachine()
        {
            // umieszcza now¹ maszynê przed pozosta³ymi (najp³ycej)
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
        /// Przesuwa maszynê z jednego miejsca na drugie. Skutkiem ubocznym
        /// tej operacji jest to, ¿e nowa lokalizacja zostanie umieszczona
        /// na pierwszym miejscu listy lokalizacji bie¿¹cego modelu, co pomaga
        /// aplikacji ustalaæ wzajemn¹ g³êbokoœæ ikon. Równie¿ klikniêcie maszyny
        /// spowoduje umieszczenie jej na pocz¹tku listy, a tym samym na przedzie
        /// panelu symulacji.
        /// </summary>
        /// <param name="oldP">stara lokalizacja maszyny</param>
        /// <param name="newP">nowa lokalizacja maszyny</param>
        public void Drag(Point oldP, Point newP) 
        {
            // umieszcza now¹ lokalizacjê na pocz¹tku listy
            IList newLocs = new ArrayList(); 
            newLocs.Add(newP);
            // tworzy now¹ listê, kopiuj¹c wszystkie maszyny poza przeci¹gan¹
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
        /// Zmienia model fabryki na poprzedni¹ wersjê.
        /// </summary>
        public void Pop()
        {
            if (_mementos.Count > 1) 
            {
                _mementos.Pop(); // zdjêcie bie¿¹cego stanu ze stosu
                if (RebuildEvent != null) RebuildEvent();
            }
        }
        /// <summary>
        /// Dodaje now¹ konfiguracjê.
        /// </summary>
        /// <param name="list">lista punktów (obiektów Point) odpowiadaj¹cych lokalizacjom maszyn</param>
        public void Push(IList list)
        {
            _mementos.Push(list);
            if (RebuildEvent != null) RebuildEvent();
        }
        /// <summary>
        /// Zwraca bie¿¹cy zbiór lokalizacji maszyn.
        /// </summary>
        public IList Locations
        {
            get
            {
                return (IList)_mementos.Peek();
            }
        }

        /// <summary>
        /// Zwraca liczbê zapisanych konfiguracji. Pomaga to aplikacji
        /// ustaliæ, czy ma oferowaæ funkcjê cofniêcia.
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