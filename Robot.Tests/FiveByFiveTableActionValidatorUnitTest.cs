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
        public void TestValidate_1()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.Validate(-1, 0), "x is outside the left edge of the table");
        }

        [TestMethod]
        public void TestValidate_2()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.Validate(5, 0), "x is outside the right edge of the table");

        }

        [TestMethod]
        public void TestValidate_3()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.Validate(0, -1), "y is outside the bottom edge of the table");
        }

        [TestMethod]
        public void TestValidate_4()
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.Validate(0, 5), "y is outside the top edge of the table");
        }

        [TestMethod]
        public void TestValidate_5() 
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.Validate(0, 0), "inside table - left bottom corner");
        }

        [TestMethod]
        public void TestValidate_6() 
        {
            IActionValidator validator = new FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.Validate(4, 4), "inside table - top right corner");
        }
    }
}
