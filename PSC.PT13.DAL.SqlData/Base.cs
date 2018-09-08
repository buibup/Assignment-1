using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.PT13.DAL.SqlData
{
    public abstract class Base : IDisposable
    {
        #region Private members section
        private bool disposed = false;
        #endregion

        #region Protected methods section
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {                    
                }
            }
            disposed = true;
        }
        #endregion

        #region Constructure section
        public Base()
        {            
        }
        #endregion

        #region Destructor section
        ~Base()
        {
            Dispose(false);
        }
        #endregion

        #region Public methods section
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
