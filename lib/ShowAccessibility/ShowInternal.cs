namespace Processes
{
    /// <summary>
    /// Klasa u�ywana w �wiczeniu na kontrol� dost�pu z rozdzia�u 7.
    /// </summary>
    public class Process 
    { 
        internal string _name = ""; 
    }
}

namespace Materials
{
    /// <summary>
    /// Klasa u�ywana w �wiczeniu na kontrol� dost�pu z rozdzia�u 7.
    /// </summary>
    public class Bin   
    {
        private string _current;
        public void setCurrentStep(Processes.Process p)
        {
            _current = p._name;
        }
    }
}
