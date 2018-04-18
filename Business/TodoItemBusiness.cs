using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using DataAccess_EF;
using Business.Util;

namespace Business
{
    public class TodoItemBusiness : ITodoItemBusiness
    {
        private TodoItemDbContext context = new TodoItemDbContext();

        public IList<TodoItemDTO> findAll()
        {
            var todoItemList = context.TodoItens.ToList();
            return todoItemList.Select(p => EFModelToDTOUtil.ToTodoItemDTOMap(p)).ToList();
        }

        public ContainerDTO<TodoItemDTO> findAll(int start, int length)
        {
            int total = context.TodoItens.Count();
            var todoItemList = context.TodoItens.OrderBy(p => p.Id).Skip(start).Take(length).ToList();
            var todoItemDTOList = todoItemList.Select(p => EFModelToDTOUtil.ToTodoItemDTOMap(p)).ToList();
            return new ContainerDTO<TodoItemDTO>() { list = todoItemDTOList, total = total };
        }

        public TodoItemDTO findById(long id)
        {
            var todoItem = context.TodoItens.Single(p => p.Id == id);
            return EFModelToDTOUtil.ToTodoItemDTOMap(todoItem);
        }

        public bool create(TodoItemDTO todoItemDTO)
        {
            var todoItem = EFModelToDTOUtil.ToTodoItemMap(todoItemDTO);
            TodoItem insertedTodoItem = context.TodoItens.Add(todoItem);
            int savedObjects = context.SaveChanges();
            return savedObjects > 0 && insertedTodoItem.Id != 0;
        }

        public bool update(TodoItemDTO todoItemDTO)
        {
            var todoItemOldValues = context.TodoItens.Single(p => p.Id == todoItemDTO.Id);
            var todoItemNewValues = EFModelToDTOUtil.ToTodoItemMap(todoItemDTO);

            context.Entry(todoItemOldValues).CurrentValues.SetValues(todoItemNewValues);

            int savedObjects = context.SaveChanges();
            return savedObjects > 0;
        }

        public bool delete(long id)
        {
            var todoItem = context.TodoItens.Single(p => p.Id == id);
            context.TodoItens.Remove(todoItem);
            int deletedObjects = context.SaveChanges();
            return deletedObjects > 0;
        }
    }
}