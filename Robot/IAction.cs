using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLib
{
    public interface IAction
    {
        void Place(int x, int y, string facing);

        void Move();

        void Left();

        void Right();

        void Report();
    }
}
