using Microsoft.Practices.Unity;
using Robot.Contracts;
using Robot.Implementation;
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
            _container.RegisterType<IActionValidator, FiveByFiveTableActionValidator>();
            _container.RegisterType<IActionable, TableRobot>();

        }

        public T Resolve<T>()
        {
           return  _container.Resolve<T>();
        }
    }
}
