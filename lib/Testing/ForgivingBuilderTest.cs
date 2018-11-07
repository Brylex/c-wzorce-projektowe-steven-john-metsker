using System;
using NUnit.Framework;
using Reservations;

namespace Testing
{
    /// <summary>
    /// Test na prawid³owe dzia³anie pob³a¿liwego obiektu buduj¹cego.
    /// </summary>
    [TestFixture]
    public class ForgivingBuilderTest
    {
        /// <summary>
        /// Test reakcji na zbyt nisk¹ cenê od osoby.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestLowDollars()
        {
            String s =
                "Date, November 5, Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 1.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// powinien zwróciæ wyj¹tek
        }
        /// <summary>
        /// Test reakcji na zbyt ma³¹ liczbê widzów.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestLowHeadCount()
        {
            String s =
                "Date, November 5, Headcount, 2, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // powinien zwróciæ wyj¹tek
        }
        /// <summary>
        /// Test reakcji na brak miasta.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoCity()
        {
            String s =
                "Date, November 5, Headcount, 250, "
                + "DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// powinien zwróciæ wyj¹tek
        }
        /// <summary>
        /// Test reakcji na brak daty.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoDate()
        {
            String s =
                "Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// powinien zwróciæ wyj¹tek
        }
        /// <summary>
        /// Test dzia³ania dla przypadku, gdy jest iloœæ widzów, ale nie ma
        /// ceny od osoby. Cena od osoby powinna byæ ustawiona na wartoœæ
        /// gwarantuj¹c¹ minimalny przychód.
        /// </summary>
        public void TestNoDollar() 
        {
            String s =
                "Date, November 5, Headcount, 250, City, Springfield, "
                + "  HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(250, r.Headcount);
            Assertion.Assert(r.Headcount * r.DollarsPerHead >= ReservationBuilder.MINTOTAL);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(false, r.HasSite);
        }
        /// <summary>
        /// Test dzia³ania dla przypadku, gdy nie ma iloœci widzów, ale jest
        /// cena od osoby. Iloœæ widzów powinna byæ co najmniej równa minimalnej
        /// i na tyle du¿a, by gwarantowaæ minimalny przychód z pokazu.        
        /// </summary>
        public void TestNoHeadcount()  
        {
            String s =
                "Date, November 5,   City, Springfield, "
                + "DollarsPerHead, 9.95, HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.Assert(r.Headcount >= ReservationBuilder.MINHEAD);
            Assertion.Assert(r.Headcount * r.DollarsPerHead >= ReservationBuilder.MINTOTAL);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(9.95, (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite); 
        }
        /// <summary>
        /// Test dzia³ania dla przypadku, gdy nie ma iloœci widzów i nie ma
        /// ceny od osoby. Iloœæ widzów powinna byæ ustawiona na minimaln¹,
        /// a cena od osoby powinna byæ równa minimalnemu przychodowi podzielonemu
        /// przez iloœæ widzów.
        /// </summary>
        public void TestNoHeadcountNoDollar() 
        {
            String s =
                "Date, November 5,   City, Springfield, "
                + "  HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(ReservationBuilder.MINHEAD, r.Headcount);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals((double)(ReservationBuilder.MINTOTAL/r.Headcount), (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite);
        }
        /// <summary>
        /// Test zwyk³ej rezerwacji.
        /// </summary>
        public void TestNormal() 
        {
            String s =
                "Date, November 5, Headcount, 250, City, Springfield, "
                + "DollarsPerHead, 9.95, HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(250, r.Headcount);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(9.95, (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite);
        }
    }
}
