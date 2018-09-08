using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.PT13.BSL.Entities
{
    public class AccountEntity
    {
        #region Private members section
        private string _accountNo;
        private decimal _money;
        #endregion

        #region Public methods section
        public string AccountNo
        {
            get { return this._accountNo; }
            set { this._accountNo = value; }
        }
        public decimal Money
        {
            get { return this._money; }
            set { this._money = value; }
        }
        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
             
        }
    }
}
