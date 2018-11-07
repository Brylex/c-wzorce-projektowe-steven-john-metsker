using System;
namespace Machines
{
    /// <summary>
    /// Modeluje wózek narzêdziowy.
    /// </summary>
    public class ToolCart : VisualizationItem
    {
        protected Engineer _responsible;

        /// <summary>
        /// Konstrukcja wózka narzêdziowego wraz z zapisaniem in¿yniera
        /// odpowiedzialnego za narzêdzia na tym wózku.
        /// </summary>
        /// <param name="e">in¿ynier odpowiedzialny</param>
        public ToolCart(Engineer e)
        {
            this._responsible = e;
        }
        /// <summary>
        /// In¿ynier odpowiedzialny za narzêdzia na tym wózku.
        /// </summary>
        public Engineer Responsible
        {
            get 
            {
                return _responsible;
            }
            set 
            {
                this._responsible = value;
            }
        }
    }
}
