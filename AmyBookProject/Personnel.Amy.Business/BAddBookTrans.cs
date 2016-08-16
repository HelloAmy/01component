using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Better.Infrastructures.DBUtility;
using Personnel.Amy.Factory;
using Personnel.Amy.IDAO;
using Personnel.Amy.Model;

namespace Personnel.Amy.Business
{
    public class BAddBookTrans : DbTransaction
    {
        private MBook book = null;

        public BAddBookTrans(MBook model)
        {
            this.book = model;
            this.Connection = ConnectionFactory.AmyDBWrite();
            this.IsolationLevel = System.Data.IsolationLevel.ReadUncommitted;
            this.IsBeginTransaction = true;
        }

        protected override void ExecuteMethods()
        {
            IBook IDAL = DalFactory.GetBookDao();
            this.IsSuccess = IDAL.AddBook(this.Transaction, null, book);
        }

        public bool IsSuccess
        {
            get;
            set;
        }
    }
}
