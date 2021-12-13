namespace TestProject
{
    public interface ICar
    {
        public IDriver getValue();
    }

    public class Bmw : ICar
    {
        public IDriver driver;
        public Bmw(IDriver _driver)
        {
            driver = _driver;
        }
        public IDriver getValue()
        {
            return driver;
        }

    }

    public interface IDriver
    {
        public ICar getValue();
    }

    public class Woman : IDriver
    {
        public ICar car;
        public Woman(ICar _car)
        {
            car = _car;
        }
        public ICar getValue()
        {
            return car;
        }
    }
}
