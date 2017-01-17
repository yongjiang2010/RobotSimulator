using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Contracts;
using Robot.Implementation;

namespace Robot.Tests
{
    [TestClass]
    public class FiveByFiveTableActionValidatorUnitTest 
    {
        [TestMethod]
        public void TestIsValidate_1()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(-1, 0), "x is outside the left edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_2()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(5, 0), "x is outside the right edge of the table");

        }

        [TestMethod]
        public void TestIsValidate_3()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(0, -1), "y is outside the bottom edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_4()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(0, 5), "y is outside the top edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_5() 
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.IsValidate(0, 0), "inside table - left bottom corner");
        }

        [TestMethod]
        public void TestIsValidate_6() 
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.IsValidate(4, 4), "inside table - top right corner");
        }
    }
}
