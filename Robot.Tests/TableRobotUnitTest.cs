using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Contracts;
using Robot.Implementation;

namespace Robot.Tests
{
    [TestClass] 
    public class TableRobotUnitTest 
    {
        
        [TestMethod]
        public void TestToString()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var result = robot.ToString();

            Assert.AreEqual("X: -1,  Y: -1,  Facing: NORTH", result, "Test Robot.ToString()");
             
        }

        [TestMethod]
        public void TestPlace_1() 
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var originalState = robot.ToString(); 

            robot.Place(5, 5, Facing.EAST);

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Place action failed - outside table");

        }

        [TestMethod]
        public void TestPlace_2()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.EAST);

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: EAST", newState, "Place action successful");

        }

        [TestMethod]
        public void TestMove_1()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var originalState = robot.ToString(); 

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Move action failed - No move before robot gets placed onto the table");

        }

        [TestMethod]
        public void TestMove_2()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.EAST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 1,  Y: 0,  Facing: EAST", newState, "East move successful");

        }

        [TestMethod]
        public void TestMove_3()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(4, 0, Facing.EAST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 4,  Y: 0,  Facing: EAST", newState, "East move failed - outside table right edge");

        }

        [TestMethod]
        public void TestMove_4()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 1, Facing.SOUTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "South move successful");

        }

        [TestMethod]
        public void TestMove_5()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.SOUTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "South move failed - outside table bottom edge");

        }

        [TestMethod]
        public void TestMove_6()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(1, 0, Facing.WEST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "West move successful");

        }

        [TestMethod]
        public void TestMove_7()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.WEST);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "West move failed - outside table right edge");

        }

        [TestMethod]
        public void TestMove_8()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 1,  Facing: NORTH", newState, "North move successful");

        }

        [TestMethod]
        public void TestMove_9() 
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 4, Facing.NORTH);

            robot.Move();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 4,  Facing: NORTH", newState, "North move failed - outside table top edge");

        }

        [TestMethod]
        public void TestLeft_1()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var originalState = robot.ToString();

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Left action failed - No left rotate before robot gets placed onto the table");

        }

        [TestMethod]
        public void TestLeft_2()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.EAST);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: NORTH", newState, "Left action sucessful - from east to north");

        }

        [TestMethod]
        public void TestLeft_3()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "Left action sucessful - from north to west");

        }

        [TestMethod]
        public void TestLeft_4()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.WEST);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "Left action sucessful - from west to south");

        }

        [TestMethod]
        public void TestLeft_5()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.SOUTH);

            robot.Left();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: EAST", newState, "Left action sucessful - from south to east");

        }

        [TestMethod]
        public void TestRight_1()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var originalState = robot.ToString();

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual(originalState, newState, "Right action failed - No right rotate before robot gets placed onto the table");

        }

        [TestMethod]
        public void TestRight_2()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.EAST);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: SOUTH", newState, "Right action sucessful - from east to south");

        }

        [TestMethod]
        public void TestRight_3()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.SOUTH);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: WEST", newState, "Right action sucessful - from south to west");

        }

        [TestMethod]
        public void TestRight_4()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.WEST);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: NORTH", newState, "Right action sucessful - from west to north");

        }

        [TestMethod]
        public void TestRight_5()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            robot.Right();

            var newState = robot.ToString();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: EAST", newState, "Right action sucessful - from north to east");

        }

        [TestMethod]
        public void TestReport_1()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            var report = robot.Report();

            Assert.AreEqual(string.Empty, report, "Report action failed - No report before robot gets placed onto the table");

        }

        [TestMethod]
        public void TestReport_2()
        {
            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            var report = robot.Report();

            Assert.AreEqual("X: 0,  Y: 0,  Facing: NORTH", report, "Report action successful");

        }

        [TestMethod]

        public void TestCanAction_1()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            Assert.AreEqual(true, robot.CanAction(ActionType.PLACE), "Place action can always be taken.");

        }



        [TestMethod]

        public void TestCanAction_2()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            Assert.AreEqual(false, robot.CanAction(ActionType.LEFT), "Left action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_3()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            Assert.AreEqual(false, robot.CanAction(ActionType.MOVE), "Move action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_4()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            Assert.AreEqual(false, robot.CanAction(ActionType.RIGHT), "Right action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_5()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            Assert.AreEqual(false, robot.CanAction(ActionType.REPORT), "Report action cannot be taken before the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_6()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.LEFT), "Left action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_7()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.MOVE), "Move action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_8()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.RIGHT), "Right action can be taken after the robot gets placed onto the table.");

        }

        [TestMethod]

        public void TestCanAction_9()
        {

            IActionable robot = new TableRobot(new FiveByFiveTableActionValidator());

            robot.Place(0, 0, Facing.NORTH);

            Assert.AreEqual(true, robot.CanAction(ActionType.REPORT), "Report action can be taken after the robot gets placed onto the table.");

        }
    }
}
