using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Contracts;
using Robot.Implementation;
using Moq;

namespace Robot.Tests
{
    [TestClass]
    public class TableRobotUnitTestWithMoq 
    {
        
        [TestMethod]
        public void TestToString()
        {
            var mock = new Mock<IActionValidator>();

            IActionable robot = new TableRobot(mock.Object);

            var result = robot.ToString();

            Assert.AreEqual("X: -1,  Y: -1,  Facing: NORTH", result, "Test Robot.ToString()");
             
        }

        [TestMethod]
        public void TestPlace_1() 
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            var originalState = robot.ToString();

            robot.Place(5, 5, Facing.EAST);

            var newState = robot.ToString();

            Assert.AreNotEqual(originalState, newState, "Place action is successfull when validation is passed");
            Assert.AreEqual("X: 5,  Y: 5,  Facing: EAST", newState, "Place action is successfull when validation is passed");

        }

        [TestMethod]
        public void TestPlace_2()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            IActionable robot = new TableRobot(mock.Object);

            var originalState = robot.ToString();

            robot.Place(1, 1, Facing.EAST);

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Place action is failed when validation is not passed");

        }

        [TestMethod]
        public void TestMove_1()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            IActionable robot = new TableRobot(mock.Object);

            var originalState = robot.ToString();

            robot.Place(1, 1, Facing.EAST);

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Move action is failed when validation is not passed");

        }

        [TestMethod]
        public void TestMove_2()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(1, 1, Facing.EAST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 2,  Y: 1,  Facing: EAST", newState, "Move action (east) is successfull when validation is passed");

        }

        [TestMethod]
        public void TestMove_3()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(1, 1, Facing.SOUTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 1,  Y: 0,  Facing: SOUTH", newState, "Move action (south) is successfull when validation is passed");

        }

        [TestMethod]
        public void TestMove_4()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(1, 1, Facing.WEST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 1,  Facing: WEST", newState, "Move action (west) is successfull when validation is passed");

        }

        [TestMethod]
        public void TestMove_5()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(1, 1, Facing.NORTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 1,  Y: 2,  Facing: NORTH", newState, "Move action (north) is successfull when validation is passed");

        }

        [TestMethod]
        public void TestLeft_1()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            IActionable robot = new TableRobot(mock.Object);

            var originalState = robot.ToString();

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Left action failed when validation is not passed");

        }

        [TestMethod]
        public void TestLeft_2()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.NORTH);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "Left action sucessful - from north to west");

        }


        [TestMethod]
        public void TestLeft_3()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.WEST);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "Left action sucessful - from west to south");

        }

        [TestMethod]
        public void TestLeft_4()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.SOUTH);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: EAST", newState, "Left action sucessful - from south to east");

        }

        [TestMethod]
        public void TestLeft_5()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.EAST);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: NORTH", newState, "Left action sucessful - from east to north");

        }

        [TestMethod]
        public void TestRight_1()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            IActionable robot = new TableRobot(mock.Object);

            var originalState = robot.ToString();

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Right action failed when validation is not passed");

        }

        [TestMethod]
        public void TestRight_2()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);


            robot.Place(0, 0, Facing.EAST);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "Right action sucessful - from east to south");

        }

        [TestMethod]
        public void TestRight_3()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);


            robot.Place(0, 0, Facing.SOUTH);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "Right action sucessful - from south to west");

        }

        [TestMethod]
        public void TestRight_4()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);


            robot.Place(0, 0, Facing.WEST);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: NORTH", newState, "Right action sucessful - from west to north");

        }

        [TestMethod]
        public void TestRight_5()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);


            robot.Place(0, 0, Facing.NORTH);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: EAST", newState, "Right action sucessful - from north to east");

        }

        [TestMethod]
        public void TestReport_1()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            IActionable robot = new TableRobot(mock.Object);

            var report = robot.Report();

            Assert.AreEqual(string.Empty, report, "Report action failed when validation is not passed");

        }

        [TestMethod]
        public void TestReport_2()
        {
            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            IActionable robot = new TableRobot(mock.Object);

            robot.Place(1, 1, Facing.WEST);

            var report = robot.Report();

            Assert.AreEqual("X: 1,  Y: 1,  Facing: WEST", report, "Report action successful when validation is passed");

        }

        [TestMethod]

        public void TestCanAction_1()
        {

            var mock = new Mock<IActionValidator>();
            IActionable robot = new TableRobot(mock.Object);

            Assert.AreEqual(true, robot.CanAction(ActionType.PLACE), "Place action can always be taken.");

        }



        [TestMethod]

        public void TestCanAction_2()
        {

            var mock = new Mock<IActionValidator>();
            IActionable robot = new TableRobot(mock.Object);

            Assert.AreEqual(false, robot.CanAction(ActionType.LEFT), "Left action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_3()
        {

            var mock = new Mock<IActionValidator>();
            IActionable robot = new TableRobot(mock.Object);

            Assert.AreEqual(false, robot.CanAction(ActionType.MOVE), "Move action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_4()
        {

            var mock = new Mock<IActionValidator>();
            IActionable robot = new TableRobot(mock.Object);

            Assert.AreEqual(false, robot.CanAction(ActionType.RIGHT), "Right action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_5()
        {

            var mock = new Mock<IActionValidator>();
            IActionable robot = new TableRobot(mock.Object);

            Assert.AreEqual(false, robot.CanAction(ActionType.REPORT), "Report action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_6()
        {

            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.LEFT), "Left action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_7()
        {

            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.MOVE), "Move action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_8()
        {

            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.RIGHT), "Right action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_9()
        {

            var mock = new Mock<IActionValidator>();
            mock.Setup(m => m.Validate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            IActionable robot = new TableRobot(mock.Object);

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.REPORT), "Report action can be taken after the robot gets placed onto the table.");

        }
    }
}
