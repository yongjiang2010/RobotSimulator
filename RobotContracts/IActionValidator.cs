using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotContracts
{
    public interface IActionValidator
    {
        bool IsValidate(int x, int y);
    }
}
