using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PIT_TK_Petrov_122_1var;
using static PIT_TK_Petrov_122_1var.MainWindow;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //ПОЗИТИВНЫЕ
        [TestMethod]
        public void TestGrade_Excellent()
        {
            int total;
            string grade = GradingLogic.CalculateGrade(10, 50, 10, 0, out total);
            Assert.AreEqual("5 (отлично)", grade);
            Assert.AreEqual(70, total);
        }

        [TestMethod]
        public void TestGrade_Good()
        {
            int total;
            string grade = GradingLogic.CalculateGrade(5, 20, 10, 5, out total);
            Assert.AreEqual("4 (хорошо)", grade);
            Assert.AreEqual(40, total);
        }

        [TestMethod]
        public void TestGrade_Satisfactory()
        {
            int total;
            string grade = GradingLogic.CalculateGrade(5, 10, 3, 2, out total);
            Assert.AreEqual("3 (удовлетворительно)", grade);
            Assert.AreEqual(20, total);
        }

        [TestMethod]
        public void TestGrade_Unsatisfactory()
        {
            int total;
            string grade = GradingLogic.CalculateGrade(0, 5, 5, 1, out total);
            Assert.AreEqual("2 (неудовлетворительно)", grade);
            Assert.AreEqual(11, total);
        }
        //НЕГАТИВНЫЕ
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGrade_OutOfRange_High()
        {
            int total;
            GradingLogic.CalculateGrade(11, 60, 40, 15, out total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGrade_OutOfRange_Negative()
        {
            int total;
            GradingLogic.CalculateGrade(-1, -10, -10, -5, out total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGrade_OutOfRange_Task1()
        {
            int total;
            GradingLogic.CalculateGrade(11, 20, 10, 5, out total);  
        }
    }
}
