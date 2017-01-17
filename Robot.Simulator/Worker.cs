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
            Console.WriteLine("Type exit to stop the program...");

            string str = Console.ReadLine();
            while (!str.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {


                str = Console.ReadLine();
            }
        }
    }
}
