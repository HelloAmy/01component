using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.APIModel.PagerService
{
    public class MSQLParameter
    {
        private string parameterName;
        private MySqlDbTypeDefine dbType;
        private object value;

        public MSQLParameter(string parameterName, MySqlDbTypeDefine dbType)
        {
            this.parameterName = parameterName;
            this.dbType = dbType;
        }

        public string ParameterName
        {
            get { return this.parameterName; }
            set { this.parameterName = value; }
        }

        public MySqlDbTypeDefine DBType
        {
            get { return this.dbType; }
            set { this.dbType = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
