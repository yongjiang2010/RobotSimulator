using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotImplementation
{
    public class FiveByFiveTableActionValidator : RobotContracts.IActionValidator
    {

        const int MIN_X = 0;
        const int MAX_X = 4;
        const int MIN_Y = 0;
        const int MAX_Y = 4; 


        bool RobotContracts.IActionValidator.IsValidate(int x, int y)
        {

            return x >= MIN_X && x <= MAX_X && y >= MIN_Y && y <= MAX_Y;
        }
    }
}
