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
                return new List<string>() { "Not Found!" };//Error here
            }
            ToDoList output = new ToDoList() { Items = castedResponse };
            return output.ToJson();
        }

        // GET: api/ToDo/5
        public ToDo Get(int id)
        {
            var response = _dal.FetchItem(id);
            ToDo castedResponse = response as ToDo;
            if (castedResponse == null)
            {
                return null;//Error here
            }
            return castedResponse;
        }

        // POST: api/ToDo
        public ToDo Post([FromBody]string value)
        {
            if (value == null)
                return null;
            ToDo convertedObj;
            try
            {
                convertedObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDo>(value);
                ToDo createdItem = _dal.CreateItem(convertedObj);
                return createdItem;
            }
            catch (Exception)
            {
                return null;
                //handle error
            }
        }

        // PUT: api/ToDo/5 
        public ToDo Put([FromBody]string value)
        {
            if (value == null)
                return null;
            ToDo convertedObj;
            try
            {
                convertedObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDo>(value);
                return _dal.UpdateItem(convertedObj);
            }
            catch (Exception)
            {
                return null;
                //handle error
            }
        }

        // DELETE: api/ToDo/5
        public void Delete(int id)
        {
            _dal.DeleteItem(id);
        }
    }
}
