using System;
using System.Collections;
namespace BusinessCore
{  
    /// <summary>
    /// Klasa wykorzystywana w wielu przyk�adach bazuj�cych na za�o�eniu,
    /// �e istnieje jeden centralny obiekt reprezentuj�cy fabryk� Oozinoz.
    /// </summary>
    public class Factory 
    {
        private static Factory _factory; 
        private static Object _classLock = typeof(Factory);
        private long _wipMoves;
        private Factory()
        {
            _wipMoves = 0;
        }
        public static Factory GetFactory()
        {
            lock (_classLock)
            {
                if (_factory == null)
                {
                    _factory = new Factory();
                }
                return _factory;
            }
        }
        public void RecordWipMove()
        {
            lock (_classLock)
            {
                _wipMoves++;
            }
        }
        // do przyk�adu z pras� gwiazdow� Aster, nieimplementowana
        public void CollectPaste() 
        {
        }

        /// <summary>
        /// Zwraca przyk�adow� list� aktywnych maszyn, pobieran� przez
        /// aplikacj� ShowConcurrentWhile i inne przyk�ady.
        /// </summary>
        /// <returns>przyk�adow� list� aktywnych maszyn</returns>
        public static ArrayList UpMachineNames()
        {
            return new ArrayList(
                new String[] {
                                 "Mixer:1201",
                                 "ShellAssembler:1301",
                                 "StarPress:1401",
                                 "UnloadBuffer:1501" } );
        }
    }
}
