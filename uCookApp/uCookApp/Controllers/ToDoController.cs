using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using uCookApp.Constants;
using uCookApp.Converters;
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
            _dal = new ToDoDal(new BaseDal<ToDo>(TableNames.ToDoItems, new ToDoItemWriteParameters(), new ToDoMapper()));
        }
        // GET: api/ToDo
        public IEnumerable<string> Get()
        {
            var response = _dal.FetchAllItems();
            List<ToDo> castedResponse = response as List<ToDo>;
            if (castedResponse == null)
            {
                return new List<string>() { "Not Found!" };//MustDO: Do JSON Error here
            }
            ToDoList output = new ToDoList() { Items = castedResponse };
            return output.ToJson();
        }

        // GET: api/ToDo/5
        public string Get(int id)
        {
            var response = _dal.FetchItem(id);
            ToDo castedResponse = response as ToDo;
            if (castedResponse == null)
            {
                return "Not Found!";//MustDO: Do JSON Error here
            }
            return castedResponse.ToJson();
        }

        // POST: api/ToDo
        public void Post([FromBody]string value)
        {
            //For Creates
            ToDo toCreate = new ToDo()
            {
                Title = "",
                Summary = "",
                DateCompleted = DateTime.Now,
            };
            _dal.CreateItem(toCreate);
            //MustDO: Post method
        }

        // PUT: api/ToDo/5 
        public void Put(int id, [FromBody]string value)
        {
            //For Updates
            //MustDO: Put method
            ToDo toUpdate = new ToDo()
            {
                Id=id,
                Title="",
                Summary="",
                DateCompleted = DateTime.Now,                
            };
            _dal.UpdateItem(toUpdate);
        }

        // DELETE: api/ToDo/5
        public void Delete(int id)
        {
            _dal.DeleteItem(id);
        }
    }
}
