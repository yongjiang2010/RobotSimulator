using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotContracts
{
    public interface IActionable
    {
        void Place(int x, int y, Facing facing);

        void Move();

        void Left();

        void Right();

        string Report();
    }
}
