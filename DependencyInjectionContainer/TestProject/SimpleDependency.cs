using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public interface IService { }

    public class ServiceImpl1 : IService
    {

    }

    public class ServiceImpl2 : IService
    {

    }

    //Generics

    public interface IRepository { }

    public interface IService<TRepository> where TRepository : IRepository { }

    public class ServiceImpl<TRepository> : IService<TRepository> where TRepository : IRepository
    {
        public TRepository checkConstructor;
        public ServiceImpl(TRepository repository)
        {
            checkConstructor = repository;
        }
    }

    public class RepositoryImpl : IRepository { }

    public abstract class AbstractClass : IService { }

    public class NonConstructor : IService
    {
        private NonConstructor() { }
    }
}
