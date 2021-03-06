﻿
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

using CRUD.API.Core;
using CRUD.API.Core.Repositories;
using CRUD.API.Persistence.Factory;
using CRUD.API.Persistence.Repositories;

namespace CRUD.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            Users = RepositoryFactory.Create<UserRepository>(context);
        }

        public IUserRepository Users { get; private set; }

        public async Task<bool> Complete()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await _context.SaveChangesAsync();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                //we can implment in here a log to track errors
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            return false;
        }

        public void Dispose()
            => _context.Dispose();


    }
}
