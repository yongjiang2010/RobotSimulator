using System;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker worker = new Robot.Bootstrap.Component().Resolve<Worker>();
            if (worker != null)
            {
                try
                {
                    worker.Run();
                }
                catch (Exception ex)
                {
                    ReportError("Oops, error occurred: " + ex.Message + "/nPress enter to exit the application");
                }

            }
            else
            {
                ReportError("Oops, robot found. Press enter to exit the application");
            }
        }

        private static void ReportError(string message)
        {
            Console.WriteLine(message);
            Console.Read();
        }

    }

   
}
