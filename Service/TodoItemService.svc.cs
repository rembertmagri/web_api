using Business;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TodoItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TodoItemService.svc or TodoItemService.svc.cs at the Solution Explorer and start debugging.
    public class TodoItemService : ITodoItemService
    {

        private ITodoItemBusiness todoItemBusiness = new TodoItemBusiness();

        public IList<TodoItemDTO> findAll()
        {
            return todoItemBusiness.findAll();
        }

        public ContainerDTO<TodoItemDTO> findAllPaged(int start, int length)
        {
            return todoItemBusiness.findAll(start, length);
        }

        public TodoItemDTO findById(long id)
        {
            return todoItemBusiness.findById(id);
        }

        public Boolean create(TodoItemDTO todoItem)
        {
            return todoItemBusiness.create(todoItem);
        }

        public Boolean update(TodoItemDTO todoItem)
        {
            return todoItemBusiness.update(todoItem);
        }

        public Boolean delete(long id)
        {
            return todoItemBusiness.delete(id);
        }
    }
}
