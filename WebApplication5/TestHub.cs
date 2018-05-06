using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication5
{
    public class TestHub : Hub
    {
        public void Hello(string name)
        {
            Clients.All.hello(name+"你好");
        }
    }
}