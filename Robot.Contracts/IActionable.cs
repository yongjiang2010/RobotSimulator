namespace Robot.Contracts
{
    public interface IActionable
    {
        void Place(int x, int y, Facing facing);

        void Move();

        void Left();

        void Right();

        string Report();

        bool CanAction(ActionType actionType);
    }
}
