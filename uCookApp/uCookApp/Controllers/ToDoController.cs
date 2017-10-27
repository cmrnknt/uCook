using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using uCookApp.Constants;
using uCookApp.DbConnection;
using uCookApp.Interfaces;
using uCookApp.Models;

namespace uCookApp.Controllers
{
    public class ToDoController : ApiController
    {
        IDal<ToDo> _dal;
        public ToDoController()
        {
            _dal = new ToDoDal(new BaseDal<ToDo>(TableNames.ToDoItems, new ToDoItemWriteParameters()));
        }
        // GET: api/ToDo
        public IEnumerable<string> Get()
        {
            return new string[] { "test", "string" };//Fetch all here
        }

        // GET: api/ToDo/5
        public string Get(int id)
        {
            var response = _dal.FetchItem(id);
            ToDo castedResponse = response as ToDo;
            if (castedResponse == null)
            {
                return "Not Found!";//Do JSON Error here
            }
            return castedResponse.ToJson();
        }

        // POST: api/ToDo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ToDo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ToDo/5
        public void Delete(int id)
        {
        }
    }
}
