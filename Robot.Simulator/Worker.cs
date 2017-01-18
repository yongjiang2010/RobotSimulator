using Robot.Contracts;
using System;

namespace Robot.Simulator
{
    public class Worker
    {
        IActionable _robot;

        public Worker(IActionable robot)
        {
            _robot = robot;
        }

        public void Run()
        {

            Console.WriteLine("Robot Simulator started ...");

            Console.WriteLine();

            Console.WriteLine("Here are the instructions:");

            Console.WriteLine("=========================================");

            Console.WriteLine("COMMAND    ACTION");

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Demo       Run demo");

            Console.WriteLine("Place      Place the robot");

            Console.WriteLine("Move       Move the robot");

            Console.WriteLine("Left       Left rotate the robot");

            Console.WriteLine("Right      Right rotate the robot");

            Console.WriteLine("Exit       Exit the simulater");

            Console.WriteLine("Report     Find out where the robot is");

            Console.WriteLine("=========================================");

            Console.WriteLine();

            string input = Console.ReadLine();

            while (!input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {

                switch (input.ToLower())
                {

                    case "demo":

                        RunDemo();
                        break;

                    case "place":

                        PlaceRobot();
                        break;

                    case "move":

                        MoveRobot();

                        break;

                    case "left":

                        LeftRotateRobot();

                        break;

                    case "right":

                        RightRotateRobot();

                        break;

                    case "report":

                        ReportRobot();

                        break;

                    default:

                        Console.WriteLine("Unknown command. Please use a valid command from the instructions");

                        break;

                }

                input = Console.ReadLine();

            }

        }

        private void RunDemo()
        {
            Console.WriteLine("Demo started ...");
            _robot.Place(0, 0, Facing.EAST);
            ReportRobot();

            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            LeftRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            LeftRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            LeftRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            RightRotateRobot();
            RightRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            RightRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            RightRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            RightRotateRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();
            MoveRobot();

            Console.WriteLine("Demo finished ...");

        }

        private void PlaceRobot() {

            if (_robot.CanAction(ActionType.PLACE))
            {
                Console.WriteLine("What is the x position? \nType a number between 0 and 4 or type anything else to cancel the place command.");
                string input = Console.ReadLine();
                int x;
                bool result = Int32.TryParse(input, out x);
                bool quit = !(result && x > -1 && x < 5);
                if (!quit)
                {
                    Console.WriteLine("What is the y position? \nType a number between 0 and 4 or type anything else to cancel the place command.");
                    input = Console.ReadLine();
                    int y;
                    result = Int32.TryParse(input, out y);
                    quit = !(result && y > -1 && y < 5);
                    if (!quit)
                    {
                        Console.WriteLine("What is the facing? \nType 0 for north, 1 for east, 2 for south, 3 for west or anything else to cancel the place command.");
                        input = Console.ReadLine();
                        int facing;
                        result = Int32.TryParse(input, out facing);
                        quit = !(result && facing > -1 && facing < 4);
                        if (!quit)
                        {
                            _robot.Place(x, y, (Facing)facing);
                            Console.WriteLine("Robot has been successfully placed to " + _robot.Report());
                        }
                    }
                    
                }
                if (quit)
                {
                    Console.WriteLine("Place command quit by the user.\n");
                }
            }
            else
            {
                Console.WriteLine("Place action cannot be taken.");
            }
        }

        private void MoveRobot() {
            if (_robot.CanAction(ActionType.MOVE))
            {
                _robot.Move();
                Console.WriteLine("Robot has been successfully moved to " + _robot.Report());
            }
            else
            {
                Console.WriteLine("Move action cannot be taken before the robot gets placed onto the table.");
            }
        }

        private void LeftRotateRobot() {
            if (_robot.CanAction(ActionType.LEFT))
            {
                _robot.Left();
                Console.WriteLine("Robot has been successfully left rotated to " + _robot.Report());
            }
            else
            {
                Console.WriteLine("Left action cannot be taken before the robot gets placed onto the table.");
            }
        }

        private void RightRotateRobot() {

            if (_robot.CanAction(ActionType.RIGHT))
            {
                _robot.Right();
                Console.WriteLine("Robot has been successfully right rotated to " + _robot.Report());
            }
            else
            {
                Console.WriteLine("Right action cannot be taken before the robot gets placed onto the table.");
            }
        }

        private void ReportRobot() {
            if (_robot.CanAction(ActionType.REPORT))
            {
                Console.WriteLine("Robot is currently at " + _robot.Report());
            }
            else
            {
                Console.WriteLine("Report action cannot be taken before the robot gets placed onto the table.");
            }
        }

    }
}
