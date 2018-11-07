using System;

namespace Machines
{
    /// <summary>
    ///  Klasa modeluj¹ca narzêdzia w fabryce Oozinoz. Narzêdzia s¹ podobne
    ///  do maszyn, ale w przeciwieñstwie do nich przemieszczaj¹ siê na wózkach.
    /// </summary>
    public class Tool : VisualizationItem
    {
        protected ToolCart _toolCart;

        /// <summary>
        /// Wózek, do którego przypisane jest bie¿¹ce narzêdzie.
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
        /// In¿ynier odpowiedzialny za zawartoœæ wózka bie¿¹cego narzêdzia.
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