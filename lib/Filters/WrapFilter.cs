using System;
using System.Text;
namespace Filters
{
    /// <summary>
    /// Obiekt WrapFilter usuwa nadmiarowe bia�e znaki i przenosi tekst
    /// we wskazanym miejscu, z dodatkow� mo�liwo�ci� wy�rodkowania.
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
        /// Konstrukcja filtra przenosz�cego pisany tekst we wskazanym miejscu.
        /// </summary>
        /// <param name="writer">filtr docelowy</param>
        /// <param name="width">szeroko�� przeniesienia</param>
        public WrapFilter(ISimpleWriter writer, int width) : base (writer)
        {
            this._width = width;
        }
        /// <summary>
        /// Znacznik okre�laj�cy, czy tekst ma by� wy�rodkowany.
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
        /// Opr�nienie i zamkni�cie strumienia.
        /// </summary>
        public override void Close() 
        {
            Flush();
            base.Close();
        }
        /// <summary>
        /// Wypisuje wszelkie znaki przetrzymywane w buforze w oczekiwaniu 
        /// na pe�en wiersz.
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
        /// wy�rodkowuj�c ka�dy wiersz.
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
        /// Dopisuje bufor s�owa do buforu wiersza, chyba �e przez to wiersz
        /// sta�by si� zbyt d�ugi. W takim przypadku wypisuje bufor wiersza
        /// i zast�puje jego zawarto�� tre�ci� bufora s�owa.
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
        /// Dopisuje przekazany znak do bie��cego bufora s�owa, chyba �e jest
        /// to znak bia�y, oznaczaj�cy koniec s�owa. Napotkanie znaku bia�ego
        /// powoduje dopisanie s�owa do bufora wiersza.
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
