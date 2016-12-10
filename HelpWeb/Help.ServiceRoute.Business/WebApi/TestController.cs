using Help.Common.Service.IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Help.ServiceRoute.Business.WebApi
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private IUserManagerDataContract userManagerDataContract;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// 这种可以依赖注入进去
        /// </summary>
        /// <param name="userManagerDataContract">The user manager data contract.</param>
        public TestController(IUserManagerDataContract userManagerDataContract)
        {
            this.userManagerDataContract = userManagerDataContract;
        }

        [HttpGet, Route("get/helloworld")]
        public IHttpActionResult Get()
        {
            return this.Ok("HelloWorld");
        }
    }
}
