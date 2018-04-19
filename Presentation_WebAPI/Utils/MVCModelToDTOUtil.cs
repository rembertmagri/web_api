using Common;
using Presentation_WebAPI.Models;
using Presentation_WebAPI.TodoItemServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation_WebAPI.Utils
{
    public class MVCModelToDTOUtil
    {
        public static TodoItemDTO ToTodoItemDTOMap(TodoItemModel todoItem)
        {
            return new TodoItemDTO()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }

        public static TodoItemModel ToTodoItemModelMap(TodoItemDTO todoItem)
        {
            return new TodoItemModel()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }
    }
}