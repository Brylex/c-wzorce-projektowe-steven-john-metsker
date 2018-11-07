using System;

namespace Machines
{
    /// <summary>
    ///  Klasa modeluj�ca narz�dzia w fabryce Oozinoz. Narz�dzia s� podobne
    ///  do maszyn, ale w przeciwie�stwie do nich przemieszczaj� si� na w�zkach.
    /// </summary>
    public class Tool : VisualizationItem
    {
        protected ToolCart _toolCart;

        /// <summary>
        /// W�zek, do kt�rego przypisane jest bie��ce narz�dzie.
        /// </summary>
        public ToolCart ToolCart            
        {
            get
            {
                return _toolCart;
            }         
            set
            {
                _toolCart = value;
            }
        }

        /// <summary>
        /// In�ynier odpowiedzialny za zawarto�� w�zka bie��cego narz�dzia.
        /// </summary>
        public Engineer Responsible
        {
            get
            {
                return _toolCart.Responsible;
            }
        }
        
    }
}