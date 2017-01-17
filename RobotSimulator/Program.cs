using RobotContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker worker = new Robot.Bootstrap.Component().Resolve<Worker>();

            worker.Run();
           
        }
    }

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
