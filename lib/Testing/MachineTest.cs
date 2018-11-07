using System;
using NUnit.Framework;
using Machines;

namespace Testing
{
    /// <summary>
    /// Test hierarchii MachineComponent, a zw³aszcza poprawnoœci okreœlania,
    /// czy dany model obiektowy zawiera cykle.
    /// </summary>
    [TestFixture]
    public class MachineTest 
    {
        /// <summary>
        /// Tworzy i zwraca zwyk³e drzewko o trzech liœciach.
        /// </summary>
        /// <returns>drzewo o trzech liœciach</returns>
        /*
         *   123
         *  /   \
         * 1     23
         *      /  \
         *     2    3
         */
         public static MachineComposite Tree()
        {
            Machine m1 = new Machine(1);
            Machine m2 = new Machine(2);
            Machine m3 = new Machine(3);
            MachineComposite m23 = new MachineComposite(23);
            m23.Add(m2);
            m23.Add(m3);
            MachineComposite m123 = new MachineComposite(123);
            m123.Add(m1);
            m123.Add(m23);
            return m123;
        }
        /// <summary>
        /// Zwraca króciutki przep³yw procesów pokazuj¹cy, ¿e kompozyt nie jest
        /// drzewem. W tym przep³ywie m1 zawiera m2, m2 zawiera m3 a m3 zawiera m1.
        /// </summary>
        /// <returns>Zwraca cykl maszyn m1->m2->m3->m1</returns>
        public static MachineComponent Cycle()
        {
            MachineComposite m1 = new MachineComposite(1);
            MachineComposite m2 = new MachineComposite(2);
            MachineComposite m3 = new MachineComposite(3);
            m1.Add(m2);
            m2.Add(m3);
            m3.Add(m1);
            return m1;
        }

        /// <summary>
        /// Zwraca ma³y, przyk³adowy kompozyt niebêd¹cy drzewem. W tym 
        /// przypadku m1 zawiera m2 i m3, a m2 zawiera m3.
        /// </summary>
        /// <returns>acykliczny kompozyt m1->m2, m3; m3-> m2</returns>
       /*
        * m1
        * |\
        * | m3
        * |/
        * m2
        */
        public static MachineComponent NonTree()
        {
            MachineComposite m1 = new MachineComposite(1);
            MachineComposite m3 = new MachineComposite(3);
            Machine m2 = new Fuser(2);
            m1.Add(m2);
            m1.Add(m3);
            m3.Add(m2);
            return m1;
        }
        /// <summary>
        /// Test na liczenie liœci.
        /// </summary>
        public void TestCount() 
        {
            Assertion.AssertEquals(3, Tree().GetMachineCount());
        }
        /// <summary>
        /// Test na wykrycie, ¿e cykl nie jest drzewem.
        /// </summary>
        public void TestCycle()
        {
            Assertion.Assert(!Cycle().IsTree());
            Assertion.Assert(!NonTree().IsTree());
            Assertion.Assert(Tree().IsTree());
            Assertion.Assert(!ExampleMachine.Plant().IsTree());
        }
        /// <summary>
        /// Test na stwierdzenie, ¿e maszyna jest drzewem.
        /// </summary>
        public void TestOne()
        {
            Assertion.Assert(new Fuser(1).IsTree());
        }
    }
}
