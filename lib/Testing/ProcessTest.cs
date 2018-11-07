using System;
using Processes;
using NUnit.Framework;

namespace Testing
{
    /// <summary>
    /// Test hierarchii ProcessComponent, zw³aszcza w kwestii modelowania
    /// procesów cyklicznych.
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
        /// Zwraca ma³y przep³yw procesów pokazuj¹cy kompozyt niebêd¹cy
        /// drzewem (ani przy okazji cyklem). W tym przep³ywie A zawiera C i B,
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
        /// Zwraca ma³y przep³yw procesów pokazuj¹cy kompozyt niebêd¹cy
        /// drzewem. W tym przep³ywie A zawiera B, B zawiera C, a C zawiera A.
        /// </summary>
        /// <returns>ma³y przep³yw procesów pokazuj¹cy kompozyt niebêd¹cy drzewem</returns>
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
        /// Test liczenia etapów cyklu bez etapów.
        /// </summary>
        public void TestCycle()
        {
            Assertion.AssertEquals(0, Cycle().GetStepCount());
        }
        /// <summary>
        /// Test liczenia etapów dla jednego etapu i jednej sekwencji (pustej).
        /// </summary>
        public void TestOne()
        {
            ProcessStep uno = new ProcessStep("jeden");
            Assertion.AssertEquals(1, uno.GetStepCount());
            ProcessSequence nil = new ProcessSequence("nic");
            Assertion.AssertEquals(0, nil.GetStepCount());
        }
        /// <summary>
        /// Test procesu powtarzanego raz: "umyæ, sp³ukaæ, powtórzyæ".
        /// </summary>
        public void TestShampoo()
        {
            ProcessStep shampoo = new ProcessStep("umyæ");
            ProcessStep rinse = new ProcessStep("sp³ukaæ");
            ProcessSequence once = new ProcessSequence("powtórzyæ");
            once.Add(shampoo);
            once.Add(rinse);
            ProcessSequence instructions =
                new ProcessSequence("instrukcje");
            instructions.Add(once);
            instructions.Add(once);
            Assertion.AssertEquals(2, instructions.GetStepCount());
        }
        /// <summary>
        /// Test liczenia etapów dla procesu produkcji petardy powietrznej.
        /// </summary>
        public void TestShell()
        {
            Assertion.AssertEquals(4, ShellProcess.Make().GetStepCount());
        }
        /// <summary>
        /// Test liczenia etapów dla ma³ego, skierowanego grafu acyklicznego
        /// niebêd¹cego drzewem.
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
        /// Test zwyk³ego drzewka.
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
