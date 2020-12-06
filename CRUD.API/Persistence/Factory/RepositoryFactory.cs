using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CRUD.API.Core.Repositories;

namespace CRUD.API.Persistence.Factory
{
    public class RepositoryFactory
    {
        public static T Create<T>(DataBaseContext context) where T : IRepository
        {
            Type tipo = typeof(T);
            return (T)Activator.CreateInstance(tipo, context);
        }
    }
}
