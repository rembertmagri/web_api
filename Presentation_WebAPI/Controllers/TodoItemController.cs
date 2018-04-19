using Presentation_WebAPI.Models;
using Presentation_WebAPI.TodoItemServiceReference;
using Presentation_WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_WebAPI.Controllers
{
    public class TodoItemController : ApiController
    {
        private readonly ITodoItemService todoItemServiceClient;

        public TodoItemController(ITodoItemService todoItemServiceClient)
        {
            this.todoItemServiceClient = todoItemServiceClient;
        }

        // GET api/<controller>
        public IEnumerable<TodoItemModel> Get()
        {
            var listTodoItemDto = todoItemServiceClient.findAll();
            return listTodoItemDto.Select(todoItemDto => MVCModelToDTOUtil.ToTodoItemModelMap(todoItemDto)).ToList();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(long id)
        {
            TodoItemModel item = getTodoItemModelById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]TodoItemModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            TodoItemDTO todoItemDTO = MVCModelToDTOUtil.ToTodoItemDTOMap(item);
            bool result = todoItemServiceClient.create(todoItemDTO);
            if (result)
            {
                return Created("/api/todoitem/" + item.Id, item);
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(long id, [FromBody]TodoItemModel item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            TodoItemDTO todoItemDTO = MVCModelToDTOUtil.ToTodoItemDTOMap(item);
            bool result = todoItemServiceClient.update(todoItemDTO);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(long id)
        {
            bool result = todoItemServiceClient.delete(id);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return InternalServerError();
        }

        private TodoItemModel getTodoItemModelById(long id)
        {
            TodoItemDTO todoItemDto = todoItemServiceClient.findById(id);
            if (todoItemDto == null)
            {
                return null;
            }
            return MVCModelToDTOUtil.ToTodoItemModelMap(todoItemDto);
        }

        #region extraMethods
        [Route("api/TodoItem/GetByName/{name}/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetByName(string name, long id)
        {
            if (name == null)
            {
                return BadRequest();
            }

            var listTodoItemDto = todoItemServiceClient.findAll();
            
            if (listTodoItemDto == null || listTodoItemDto.Count() == 0)
            {
                return NotFound();
            }

            IList<TodoItemDTO> filteredItens = new List<TodoItemDTO>();
            foreach(TodoItemDTO item in listTodoItemDto)
            {
                if (name.Equals(item.Name))
                {
                    filteredItens.Add(item);
                }
            }
            var itens = filteredItens.Select(todoItemDto => MVCModelToDTOUtil.ToTodoItemModelMap(todoItemDto)).ToList();
            return Ok(itens);
        }
        #endregion
    }
}