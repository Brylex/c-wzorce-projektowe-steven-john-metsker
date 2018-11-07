using System;
namespace Machines
{
    /// <summary>
    /// Modeluje w�zek narz�dziowy.
    /// </summary>
    public class ToolCart : VisualizationItem
    {
        protected Engineer _responsible;

        /// <summary>
        /// Konstrukcja w�zka narz�dziowego wraz z zapisaniem in�yniera
        /// odpowiedzialnego za narz�dzia na tym w�zku.
        /// </summary>
        /// <param name="e">in�ynier odpowiedzialny</param>
        public ToolCart(Engineer e)
        {
            this._responsible = e;
        }
        /// <summary>
        /// In�ynier odpowiedzialny za narz�dzia na tym w�zku.
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
