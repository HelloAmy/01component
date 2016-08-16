using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personnel.Amy.Model;

namespace Personnel.Amy.Business
{
    public class BBook
    {
        public bool AddBook(MBook model)
        {
            BAddBookTrans bll = new BAddBookTrans(model);
            bll.Execute();
            return bll.IsSuccess;
        }
    }
}
