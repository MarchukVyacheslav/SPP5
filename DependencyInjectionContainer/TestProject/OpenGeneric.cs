using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public interface IGenericRepository
    {

    };

    public interface IGenericService
    {

    };

    public interface IGenericService<TGenericRepository> where TGenericRepository : IGenericRepository
    {

    };


    public class GenericRepositoryImpl : IGenericRepository
    {
        public GenericRepositoryImpl(int a) { }

    };

    public class GenericServiceImpl<TGenericRepository> : IGenericService<TGenericRepository> where TGenericRepository : IGenericRepository
    {
        public TGenericRepository constructorCheck;
        public GenericServiceImpl(TGenericRepository a)
        {
            constructorCheck = a;
        }

    };
}
