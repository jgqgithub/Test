using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        List<Person> lists = new List<Person>();
        [HttpGet]
        [Route("GetPerson")]
        public IEnumerable<Person> GetPerson()
        {
          
            lists.Add(new Person() { Name = "xiaoming", Id = 2 });
            lists.Add(new Person() { Name = "xiaohong", Id = 3 });
            return lists;
        }
        [Route("GetPerson")]
        public Person GetPerson(int id)
        {
            return lists.Where(i => i.Id == id).SingleOrDefault();
        }
        [HttpPost]
        [Route("AddPerson")]
        public bool AddPerson([FromBody]Person p)
        {
            lists.Add(p);
            return lists.Count >=1;
        }

    }
}
