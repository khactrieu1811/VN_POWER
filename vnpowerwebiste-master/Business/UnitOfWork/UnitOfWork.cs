using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Business.Repository;
using Entities.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        public VNPowerContext Context { get; }

        public UnitOfWork(VNPowerContext context)
        {
            Context = context;
        }

        #region Public Properties  

        private PostTagRepository _prescriptionRepository;

        public PostTagRepository PrescriptionRepository => _prescriptionRepository ?? (_prescriptionRepository = new PostTagRepository(Context));


        #endregion
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

