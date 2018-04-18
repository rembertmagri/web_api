using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public interface ITodoItemBusiness
    {
        IList<TodoItemDTO> findAll();

        ContainerDTO<TodoItemDTO> findAll(int start, int length);

        TodoItemDTO findById(long id);

        Boolean create(TodoItemDTO todoItemDTO);

        Boolean update(TodoItemDTO todoItemDTO);

        Boolean delete(long id);
    }
}