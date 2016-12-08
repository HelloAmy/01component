using Help.Common.Service.IContract;
using Help.DBAccessLayer.Business;
using Help.DBAccessLayer.Model.PagerQueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Service.Service
{
    public class PagerService : IPagerContract
    {
        public MPagerReturn PagerQuery(MPagerInParam para)
        {
            return new BPagerQuery().PagerQuery(para);
        }
    }
}
