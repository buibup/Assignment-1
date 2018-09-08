using System;

namespace PSC.PT13.DAL.DataFactory
{
    public sealed class Builder
    {
        public static PSC.PT13.DAL.IData.IAccountData AccountData()
        {
            return new PSC.PT13.DAL.SqlData.AccountData();
        }
    }
}
