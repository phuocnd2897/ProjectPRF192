﻿using HM.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace VG.Context
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public HMContext dbContext { get; }
        public UnitOfWork(HMContext dataContext)
        {
            this.dbContext = dataContext;
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
