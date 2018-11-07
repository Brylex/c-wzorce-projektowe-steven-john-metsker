using System;
using Processes;
using NUnit.Framework;

namespace Testing
{
    /// <summary>
    /// Test hierarchii ProcessComponent, zw�aszcza w kwestii modelowania
    /// proces�w cyklicznych.
    /// </summary>
    [TestFixture]
    public class ProcessTest
    {
        /*
         * a
         * |\
         * | b
         * |/
         * c
         */
        /// <summary>
        /// Zwraca ma�y przep�yw proces�w pokazuj�cy kompozyt nieb�d�cy
        /// drzewem (ani przy okazji cyklem). W tym przep�ywie A zawiera C i B,
        /// a B zawiera C.
        /// </summary>
        /// <returns></returns>
        public static ProcessComponent Abc()
        {
            ProcessSequence a = new ProcessSequence("a");
            ProcessSequence b = new ProcessSequence("b");
            ProcessStep c = new ProcessStep("c");
            a.Add(c);
            a.Add(b);
            b.Add(c);
            return a;
        }
        /// <summary>
        /// Zwraca ma�y przep�yw proces�w pokazuj�cy kompozyt nieb�d�cy
        /// drzewem. W tym przep�ywie A zawiera B, B zawiera C, a C zawiera A.
        /// </summary>
        /// <returns>ma�y przep�yw proces�w pokazuj�cy kompozyt nieb�d�cy drzewem</returns>
        public static ProcessComponent Cycle()
        {
            ProcessSequence a = new ProcessSequence("a");
            ProcessSequence b = new ProcessSequence("b");
            ProcessSequence c = new ProcessSequence("c");
            a.Add(b);
            b.Add(c);
            c.Add(a);
            return a;
        }
        /// <summary>
        /// Test liczenia etap�w cyklu bez etap�w.
        /// </summary>
        public void TestCycle()
        {
            Assertion.AssertEquals(0, Cycle().GetStepCount());
        }
        /// <summary>
        /// Test liczenia etap�w dla jednego etapu i jednej sekwencji (pustej).
        /// </summary>
        public void TestOne()
        {
            ProcessStep uno = new ProcessStep("jeden");
            Assertion.AssertEquals(1, uno.GetStepCount());
            ProcessSequence nil = new ProcessSequence("nic");
            Assertion.AssertEquals(0, nil.GetStepCount());
        }
        /// <summary>
        /// Test procesu powtarzanego raz: "umy�, sp�uka�, powt�rzy�".
        /// </summary>
        public void TestShampoo()
        {
            ProcessStep shampoo = new ProcessStep("umy�");
            ProcessStep rinse = new ProcessStep("sp�uka�");
            ProcessSequence once = new ProcessSequence("powt�rzy�");
            once.Add(shampoo);
            once.Add(rinse);
            ProcessSequence instructions =
                new ProcessSequence("instrukcje");
            instructions.Add(once);
            instructions.Add(once);
            Assertion.AssertEquals(2, instructions.GetStepCount());
        }
        /// <summary>
        /// Test liczenia etap�w dla procesu produkcji petardy powietrznej.
        /// </summary>
        public void TestShell()
        {
            Assertion.AssertEquals(4, ShellProcess.Make().GetStepCount());
        }
        /// <summary>
        /// Test liczenia etap�w dla ma�ego, skierowanego grafu acyklicznego
        /// nieb�d�cego drzewem.
        /// </summary>
        public void TestStepCount()
        {
            Assertion.AssertEquals(1, Abc().GetStepCount());
        }
        /*
         *   abc
         *  /   \
         * a     bc
         *      /  \
         *     b    c
         */
        /// <summary>
        /// Test zwyk�ego drzewka.
        /// </summary>
        public void TestTree()
        {
            ProcessStep a = new ProcessStep("a");
            ProcessStep b = new ProcessStep("b");
            ProcessStep c = new ProcessStep("c");
            ProcessSequence bc = new ProcessSequence("bc"); 
            bc.Add(b);
            bc.Add(c);
            ProcessSequence abc = new ProcessSequence("abc");
            abc.Add(a);
            abc.Add(bc);
            Assertion.AssertEquals(3, abc.GetStepCount());
        }
    }
}
