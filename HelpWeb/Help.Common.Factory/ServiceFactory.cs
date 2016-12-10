using Help.Common.Service.IContract;
using Help.Common.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Factory
{
    public class ServiceFactory
    {
        public static IPagerContract GetPagerContractDAO()
        {
            return new PagerService();
        }

        public static IUserManagerDataContract GetUserManagerDataDAO()
        {
            return new UserManagerDataService();
        }
    }
}
