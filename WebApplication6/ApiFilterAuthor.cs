using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication6
{
    public class ApiFilterAuthor : IAuthorizationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> usernames;
            if (!actionContext.Request.Headers.TryGetValues("username", out usernames))
            {
                return  new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("报文头中的UserName为空") };
            }
            IEnumerable<string> passwords;
            if (!actionContext.Request.Headers.TryGetValues("password", out passwords))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("报问头中的password为空") };
            }
            string username = usernames.First();
            string password = passwords.First();
            if (username == "admin" && password == "123456")
            {
                return await continuation();
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("验证失败") };
            }
        }
    }
}