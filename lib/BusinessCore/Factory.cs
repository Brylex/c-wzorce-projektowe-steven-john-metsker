using System;
using System.Collections;
namespace BusinessCore
{  
    /// <summary>
    /// Klasa wykorzystywana w wielu przyk³adach bazuj¹cych na za³o¿eniu,
    /// ¿e istnieje jeden centralny obiekt reprezentuj¹cy fabrykê Oozinoz.
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
        // do przyk³adu z pras¹ gwiazdow¹ Aster, nieimplementowana
        public void CollectPaste() 
        {
        }

        /// <summary>
        /// Zwraca przyk³adow¹ listê aktywnych maszyn, pobieran¹ przez
        /// aplikacjê ShowConcurrentWhile i inne przyk³ady.
        /// </summary>
        /// <returns>przyk³adow¹ listê aktywnych maszyn</returns>
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
