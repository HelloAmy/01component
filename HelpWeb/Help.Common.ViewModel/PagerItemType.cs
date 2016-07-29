using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.ViewModel
{
    internal enum PagerItemType : byte
    {
        FirstPage = 0,
        LastPage = 3,
        MorePage = 4,
        NextPage = 1,
        NumericPage = 5,
        PrevPage = 2
    }
}
