using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.ViewModel
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IList<T> list, int pageIndex, int pagesize)
        {
            this.CurrentPageIndex = pageIndex;
            this.PageSize = pagesize;
            if (list != null)
            {
                base.AddRange(list);
            }
        }

        public PagedList(IEnumerable<T> list, int pageindex, int pagesize, int totalItemCount)
        {
            this.CurrentPageIndex = pageindex;
            this.PageSize = pagesize;
            this.TotalItemCount = totalItemCount;
            if (list != null)
            {
                base.AddRange(list);
            }
        }

        public int CurrentPageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int TotalItemCount
        {
            get;
            set;
        }

        public int TotalPageCount
        {
            get { return (int)Math.Ceiling((double)((double)this.TotalItemCount / (double)this.PageSize)); }
        }
    }
}
