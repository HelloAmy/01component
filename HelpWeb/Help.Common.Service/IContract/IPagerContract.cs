using Help.DBAccessLayer.Model.PagerQueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Service.IContract
{
    public interface IPagerContract
    {
        MPagerReturn PagerQuery(MPagerInParam para);
    }
}
