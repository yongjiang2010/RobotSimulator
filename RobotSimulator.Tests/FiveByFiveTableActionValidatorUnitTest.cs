using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class FiveByFiveTableActionValidatorUnitTest 
    {
        [TestMethod]
        public void TestIsValidate_1()
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(-1, 0), "x is outside the left edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_2()
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(5, 0), "x is outside the right edge of the table");

        }

        [TestMethod]
        public void TestIsValidate_3()
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(0, -1), "y is outside the bottom edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_4()
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsFalse(validator.IsValidate(0, 5), "y is outside the top edge of the table");
        }

        [TestMethod]
        public void TestIsValidate_5() 
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.IsValidate(0, 0), "inside table - left bottom corner");
        }

        [TestMethod]
        public void TestIsValidate_6() 
        {
            RobotContracts.IActionValidator validator = new RobotImplementation.FiveByFiveTableActionValidator();
            Assert.IsTrue(validator.IsValidate(4, 4), "inside table - top right corner");
        }
    }
}
