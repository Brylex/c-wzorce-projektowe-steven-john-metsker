using System;
namespace Functions
{
    /// <summary>
    /// Funkcja Scale reprezentuje interpolacjê liniow¹. Na przyk³ad zakresowi 
    /// od 0 do 100 stopni Celsjusza odpowiada zakres od 32 do 212 stopni
    /// Fahrenheita. Jeœli mamy obiekt c typu Frapper zwracaj¹cy temperaturê
    /// w stopniach Celsjusza jako funkcjê czasu, mo¿emy wyliczyæ temperaturê
    /// w stopniach Fahrenheita za pomoc¹:
    /// Frapper f = new Scale(
    ///      new Constant(0), c, new Constant(100), 
    ///      new Constant(32), new Constant(212));
    /// </summary>
    public class Scale : Frapper 
    {
        /// <summary>
        /// Konstrukcja skali przebiegaj¹cej od pocz¹tku do koñca w miarê
        /// przebiegu czasu od 0 do 1.
        /// </summary>
        /// <param name="from">wartoœæ pocz¹tku skali</param>
        /// <param name="to">wartoœæ koñca skali</param>
        public Scale(double from, double to) : this(new Constant(from), new Constant(to))
        {           
        }
        /// <summary>
        /// Konstrukcja skali przebiegaj¹cej od pocz¹tku do koñca w miarê
        /// przebiegu czasu od 0 do 1.
        /// </summary>
        /// <param name="f1">funkcja dla pocz¹tku skali</param>
        /// <param name="f2">funkcja dla koñca skali</param>
        public Scale(Frapper f1, Frapper f2) : 
            this(new Constant(0), new T(), new Constant(1), f1, f2)
        {            
        }

        /// <summary>
        /// Konstrukcja skali "a" przebiegaj¹cej od pocz¹tku "aFrom" do koñca "aTo" 
        /// w miarê przebiegu funkcji "b" w zakresie od "bFrom" do "bTo". 
        /// </summary>
        /// <param name="aFrom">wartoœæ pocz¹tkowa skali "a" (najczêœciej sta³a)</param>
        /// <param name="a">funkcja "a", najczêœciej zmienna w czasie</param>
        /// <param name="aTo">wartoœæ koñcowa skali "a"</param>
        /// <param name="bFrom">wartoœæ pocz¹tkowa skali "b"</param>
        /// <param name="bTo">wartoœæ koñcowa skali "b"</param>
        public Scale(
            Frapper aFrom, Frapper a, Frapper aTo, Frapper bFrom, Frapper bTo) :
            base(new Frapper[] { aFrom, a, aTo, bFrom, bTo })
        {            
        }
        /// <summary>
        /// Konstrukcja skali "a" przebiegaj¹cej od pocz¹tku "aFrom" do koñca "aTo" 
        /// w miarê przebiegu funkcji "b" w zakresie od "bFrom" do "bTo". 
        /// </summary>
        /// <param name="aFrom">wartoœæ pocz¹tkowa skali "a" (najczêœciej sta³a)</param>
        /// <param name="a">funkcja "a", najczêœciej zmienna w czasie</param>
        /// <param name="aTo">wartoœæ koñcowa skali "a"</param>
        /// <param name="bFrom">wartoœæ pocz¹tkowa skali "b"</param>
        /// <param name="bTo">wartoœæ koñcowa skali "b"</param>
        public Scale(double aFrom, Frapper a, double aTo, double bFrom, double bTo) :
            this(new Constant(aFrom), a, new Constant(aTo), new Constant(bFrom), new Constant(bTo))
        {
        }
        /// <summary>
        /// Zwraca "b" jako funkcjê liniow¹ przebiegaj¹c¹ od "bFrom" do "bTo"
        /// w miarê przebiegu "a" od "aFrom" do "aTo".
        /// </summary>
        /// <param name="t">znormalizowana wartoœæ czasu z przedzia³u od 0 do 1</param>
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
