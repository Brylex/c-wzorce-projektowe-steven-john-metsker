namespace Processes
{
    /// <summary>
    /// Klasa u¿ywana w æwiczeniu na kontrolê dostêpu z rozdzia³u 7.
    /// </summary>
    public class Process 
    { 
        internal string _name = ""; 
    }
}

namespace Materials
{
    /// <summary>
    /// Klasa u¿ywana w æwiczeniu na kontrolê dostêpu z rozdzia³u 7.
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
