using System;
using System.Text;
namespace Filters
{
    /// <summary>
    /// Obiekt WrapFilter usuwa nadmiarowe bia³e znaki i przenosi tekst
    /// we wskazanym miejscu, z dodatkow¹ mo¿liwoœci¹ wyœrodkowania.
    /// </summary>
    public class WrapFilter : OozinozFilter 
    {
        protected int _width;
        protected StringBuilder lineBuf = new StringBuilder();
        protected StringBuilder wordBuf = new StringBuilder();
        protected bool _center = false;
        protected bool _inWhite = false;
        protected bool _needBlank = false;

        /// <summary>
        /// Konstrukcja filtra przenosz¹cego pisany tekst we wskazanym miejscu.
        /// </summary>
        /// <param name="writer">filtr docelowy</param>
        /// <param name="width">szerokoœæ przeniesienia</param>
        public WrapFilter(ISimpleWriter writer, int width) : base (writer)
        {
            this._width = width;
        }
        /// <summary>
        /// Znacznik okreœlaj¹cy, czy tekst ma byæ wyœrodkowany.
        /// </summary>
        public bool Center
        {
            get 
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }
        /// <summary>
        /// Opró¿nienie i zamkniêcie strumienia.
        /// </summary>
        public override void Close() 
        {
            Flush();
            base.Close();
        }
        /// <summary>
        /// Wypisuje wszelkie znaki przetrzymywane w buforze w oczekiwaniu 
        /// na pe³en wiersz.
        /// </summary>
        public void Flush()
        {
            if (wordBuf.Length > 0)
            {
                PostWord();
            }
            if (lineBuf.Length > 0)
            {
                PostLine();
            }
        }
        /// <summary>
        /// Wypisuje wszelkie znaki w buforze wiersza, w razie potrzeby
        /// wyœrodkowuj¹c ka¿dy wiersz.
        /// </summary>
        protected void PostLine()  
        {
            if (Center)
            {
                for (int i = 0; i < (_width - lineBuf.Length) / 2; i++)
                {
                    _writer.Write(' ');
                }
            }
            _writer.Write(lineBuf.ToString());
            _writer.WriteLine();
        }
        /// <summary>
        /// Dopisuje bufor s³owa do buforu wiersza, chyba ¿e przez to wiersz
        /// sta³by siê zbyt d³ugi. W takim przypadku wypisuje bufor wiersza
        /// i zastêpuje jego zawartoœæ treœci¹ bufora s³owa.
        /// </summary>
        protected void PostWord()  
        {
            if (lineBuf.Length + 1 + wordBuf.Length > _width && (lineBuf.Length > 0))
            {
                PostLine();
                lineBuf = wordBuf;
                wordBuf = new StringBuilder();
            }
            else
            {
                if (_needBlank)
                {
                    lineBuf.Append(" ");
                }
                lineBuf.Append(wordBuf);
                _needBlank = true;
                wordBuf = new StringBuilder();
            }
        }
        /// <summary>
        /// Dopisuje przekazany znak do bie¿¹cego bufora s³owa, chyba ¿e jest
        /// to znak bia³y, oznaczaj¹cy koniec s³owa. Napotkanie znaku bia³ego
        /// powoduje dopisanie s³owa do bufora wiersza.
        /// </summary>
        /// <param name="c">zapisywany znak</param>
        public override void Write(char c)  
        {
            if (Char.IsWhiteSpace(c))
            {
                if (!_inWhite)
                {
                    PostWord();
                }
                _inWhite = true;
            }
            else
            {
                wordBuf.Append(c);
                _inWhite = false;
            }
        }
    }
}
