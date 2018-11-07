using System;
using NUnit.Framework; 
using Fireworks;
using Simulation;

namespace Testing
{
    /// <summary>
    /// Test pakietu Simulation i obs³uguj¹cych go klas Fireworks.
    /// </summary>
    [TestFixture]
    public class SkyrocketTest 
    {
        private static double SPECIFIC_IMPULSE = 620; // niutony/Kg
        private static double FUEL_DENSITY = 1800; // Kg/m**3

        /// <summary>
        /// Test na liniowy spadek masy od masy pocz¹tkowej do 0 w czasie
        /// spalania paliwa.
        /// </summary>
        [Test]
        public void TestPhysicalRocket() 
        {
            double burnArea = .0030;
            double burnDepth = .06;
            double burnVolume = burnArea * burnDepth;
            double fuelMass = burnVolume * FUEL_DENSITY;
            double totalMass = fuelMass * 1.1;
            double burnRate = .020;

            PhysicalRocket r = new PhysicalRocket(burnArea, burnRate, fuelMass, totalMass);

            double bt = burnDepth / burnRate;
            double tol = 0.01;
            Assertion.AssertEquals("sprawdzenie czasu spalania", bt, r.GetBurnTime(), tol);

            Assertion.AssertEquals("masa pocz¹tkowa", totalMass, r.GetMass(0), tol);
            Assertion.AssertEquals("masa wypalona", totalMass - fuelMass, r.GetMass(bt), tol);
            Assertion.AssertEquals("po³owa masy", totalMass - fuelMass * .5, r.GetMass(bt/2), tol);
            Assertion.AssertEquals("ci¹g", SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, r.GetThrust(bt/2), tol);
        }           
        /// <summary>
        /// Test na liniowy spadek masy od masy pocz¹tkowej do 0 w czasie
        /// spalania paliwa.
        /// </summary>
        [Test]
        public void TestOozinozSkyocket() 
        {
            double burnArea = .0030;
            double burnDepth = .06;
            double burnVolume = burnArea * burnDepth;
            double fuelMass = burnVolume * FUEL_DENSITY;
            double totalMass = fuelMass * 1.1;
            double burnRate = .020;

            PhysicalRocket pr = new PhysicalRocket(burnArea, burnRate, fuelMass, totalMass);

            OozinozSkyrocket or = new OozinozSkyrocket(pr);

            double tol = 0.01;

            or.SetSimTime(0);    
            Assertion.AssertEquals("masa pocz¹tkowa", totalMass, or.GetMass(), tol);
            Assertion.AssertEquals("ci¹g", SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, or.GetThrust(), tol);
            
            double bt = burnDepth / burnRate;
            or.SetSimTime(bt * 1.01); 
            Assertion.AssertEquals("masa koñcowa", totalMass - fuelMass, or.GetMass(), tol);
            Assertion.AssertEquals("ci¹g", 0, or.GetThrust(), tol);
        }      
    }
}
