using Microsoft.Practices.Unity;
namespace Robot.Bootstrap
{
    public class Component
    {
        IUnityContainer _container;

        public Component()
        {
            _container = new UnityContainer();
            Register();
        }

        private void Register()
        {
            _container.RegisterType<RobotContracts.IActionValidator, RobotImplementation.FiveByFiveTableActionValidator>();
            _container.RegisterType<RobotContracts.IActionable, RobotImplementation.TableRobot>();

        }

        public T Resolve<T>()
        {
           return  _container.Resolve<T>();
        }
    }
}
