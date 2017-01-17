using RobotContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotImplementation
{
    public class TableRobot : IActionable
    {

        private int _x = -1;

        private int _y = -1;

        private Facing _facing;

        public IActionValidator _actionValidator { get; set; }

        public TableRobot(IActionValidator actionValidator)
        {
            if (actionValidator == null) throw new ArgumentNullException("actionValidator missing");
            this._actionValidator = actionValidator;
        }

        public override string ToString()
        {
            return string.Format("X: {0},  Y: {1},  Facing: {2}", _x, _y, _facing);
        }

        void RobotContracts.IActionable.Place(int x, int y, RobotContracts.Facing facing)
        {
            if (_actionValidator.IsValidate(x, y))
            {
                this._x = x;
                this._y = y;
                this._facing = facing;
            }
        }

        void RobotContracts.IActionable.Move()
        {
            switch (this._facing)
            {
                case Facing.EAST:
                    if (_actionValidator.IsValidate(this._x + 1, this._y)) this._x++;
                    break;
                case Facing.NORTH:
                    if (_actionValidator.IsValidate(this._x, this._y + 1)) this._y++;
                    break;
                case Facing.SOUTH:
                    if (_actionValidator.IsValidate(this._x, this._y - 1)) this._y--;
                    break;
                case Facing.WEST:
                    if (_actionValidator.IsValidate(this._x - 1, this._y)) this._x--;
                    break;
                default: break;
            }
        }

        void RobotContracts.IActionable.Left()
        {
            if (_actionValidator.IsValidate(this._x, this._y))
            {
                switch (this._facing)
                {
                    case Facing.EAST:
                        this._facing = Facing.NORTH;
                        break;
                    case Facing.NORTH:
                        this._facing = Facing.WEST;
                        break;
                    case Facing.SOUTH:
                        this._facing = Facing.EAST;
                        break;
                    case Facing.WEST:
                        this._facing = Facing.SOUTH;
                        break;
                    default: break;
                }
            }
            
        }

        void RobotContracts.IActionable.Right()
        {
            if (_actionValidator.IsValidate(this._x, this._y))
            {
                switch (this._facing)
                {
                    case Facing.EAST:
                        this._facing = Facing.SOUTH;
                        break;
                    case Facing.NORTH:
                        this._facing = Facing.EAST;
                        break;
                    case Facing.SOUTH:
                        this._facing = Facing.WEST;
                        break;
                    case Facing.WEST:
                        this._facing = Facing.NORTH;
                        break;
                    default: break;
                }
            }
           
        }

        string RobotContracts.IActionable.Report()
        {
            if (_actionValidator.IsValidate(this._x, this._y))
            {
                return ToString();
            }
            else
            {
                return string.Empty;
            }
            
        }
    }
}
