using System;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker worker = new Robot.Bootstrap.Component().Resolve<Worker>();

            worker.Run(); 
           
        }
    }

   
}
