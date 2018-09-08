using System;

namespace PSC.PT13.BSL.ServiceFactory
{
    public sealed class Builder
    {
        public static PSC.PT13.BSL.IService.IAccountService AccountService()
        {
            return new PSC.PT13.BSL.Service.AccountService();
        }
    }
}
