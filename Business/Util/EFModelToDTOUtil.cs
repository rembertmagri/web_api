using Common;
using DataAccess_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Util
{
    public class EFModelToDTOUtil
    {
        public static TodoItemDTO ToTodoItemDTOMap(TodoItem todoItem)
        {
            return new TodoItemDTO()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }

        public static TodoItem ToTodoItemMap(TodoItemDTO todoItem)
        {
            return new TodoItem()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }
    }
}