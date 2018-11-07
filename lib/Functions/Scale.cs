using System;
namespace Functions
{
    /// <summary>
    /// Funkcja Scale reprezentuje interpolacj� liniow�. Na przyk�ad zakresowi 
    /// od 0 do 100 stopni Celsjusza odpowiada zakres od 32 do 212 stopni
    /// Fahrenheita. Je�li mamy obiekt c typu Frapper zwracaj�cy temperatur�
    /// w stopniach Celsjusza jako funkcj� czasu, mo�emy wyliczy� temperatur�
    /// w stopniach Fahrenheita za pomoc�:
    /// Frapper f = new Scale(
    ///      new Constant(0), c, new Constant(100), 
    ///      new Constant(32), new Constant(212));
    /// </summary>
    public class Scale : Frapper 
    {
        /// <summary>
        /// Konstrukcja skali przebiegaj�cej od pocz�tku do ko�ca w miar�
        /// przebiegu czasu od 0 do 1.
        /// </summary>
        /// <param name="from">warto�� pocz�tku skali</param>
        /// <param name="to">warto�� ko�ca skali</param>
        public Scale(double from, double to) : this(new Constant(from), new Constant(to))
        {           
        }
        /// <summary>
        /// Konstrukcja skali przebiegaj�cej od pocz�tku do ko�ca w miar�
        /// przebiegu czasu od 0 do 1.
        /// </summary>
        /// <param name="f1">funkcja dla pocz�tku skali</param>
        /// <param name="f2">funkcja dla ko�ca skali</param>
        public Scale(Frapper f1, Frapper f2) : 
            this(new Constant(0), new T(), new Constant(1), f1, f2)
        {            
        }

        /// <summary>
        /// Konstrukcja skali "a" przebiegaj�cej od pocz�tku "aFrom" do ko�ca "aTo" 
        /// w miar� przebiegu funkcji "b" w zakresie od "bFrom" do "bTo". 
        /// </summary>
        /// <param name="aFrom">warto�� pocz�tkowa skali "a" (najcz�ciej sta�a)</param>
        /// <param name="a">funkcja "a", najcz�ciej zmienna w czasie</param>
        /// <param name="aTo">warto�� ko�cowa skali "a"</param>
        /// <param name="bFrom">warto�� pocz�tkowa skali "b"</param>
        /// <param name="bTo">warto�� ko�cowa skali "b"</param>
        public Scale(
            Frapper aFrom, Frapper a, Frapper aTo, Frapper bFrom, Frapper bTo) :
            base(new Frapper[] { aFrom, a, aTo, bFrom, bTo })
        {            
        }
        /// <summary>
        /// Konstrukcja skali "a" przebiegaj�cej od pocz�tku "aFrom" do ko�ca "aTo" 
        /// w miar� przebiegu funkcji "b" w zakresie od "bFrom" do "bTo". 
        /// </summary>
        /// <param name="aFrom">warto�� pocz�tkowa skali "a" (najcz�ciej sta�a)</param>
        /// <param name="a">funkcja "a", najcz�ciej zmienna w czasie</param>
        /// <param name="aTo">warto�� ko�cowa skali "a"</param>
        /// <param name="bFrom">warto�� pocz�tkowa skali "b"</param>
        /// <param name="bTo">warto�� ko�cowa skali "b"</param>
        public Scale(double aFrom, Frapper a, double aTo, double bFrom, double bTo) :
            this(new Constant(aFrom), a, new Constant(aTo), new Constant(bFrom), new Constant(bTo))
        {
        }
        /// <summary>
        /// Zwraca "b" jako funkcj� liniow� przebiegaj�c� od "bFrom" do "bTo"
        /// w miar� przebiegu "a" od "aFrom" do "aTo".
        /// </summary>
        /// <param name="t">znormalizowana warto�� czasu z przedzia�u od 0 do 1</param>
        /// <returns></returns>
        public override double F(double t)
        {
            double aFrom = _sources[0].F(t);
            double a     = _sources[1].F(t);
            double aTo   = _sources[2].F(t);
            double bFrom = _sources[3].F(t);
            double bTo   = _sources[4].F(t);
            double denom = aTo - aFrom;
            if (denom == 0)
            {
                return (bTo + bFrom) / 2;
            }
            else
            {
                return (a - aFrom) / denom * (bTo - bFrom) + bFrom;
            }
        }
    }
}
