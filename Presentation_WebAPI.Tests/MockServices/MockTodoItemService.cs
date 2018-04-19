using Presentation_WebAPI.TodoItemServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_WebAPI.Tests.MockServices
{
    class MockTodoItemService : ITodoItemService
    {
        private readonly IList<TodoItemDTO> db = new List<TodoItemDTO>();

        public TodoItemDTO[] findAll()
        {
            return db.ToArray();
        }

        public Task<TodoItemDTO[]> findAllAsync()
        {
            throw new NotImplementedException();
        }

        public ContainerDTOOfTodoItemDTOKmbgGhhj findAllPaged(int start, int length)
        {
            throw new NotImplementedException();
        }

        public Task<ContainerDTOOfTodoItemDTOKmbgGhhj> findAllPagedAsync(int start, int length)
        {
            throw new NotImplementedException();
        }

        public TodoItemDTO findById(long id)
        {
            return db.Where(item => item.Id==id).Single();
        }

        public Task<TodoItemDTO> findByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool create(TodoItemDTO todoItem)
        {
            db.Add(todoItem);
            return true;
        }

        public Task<bool> createAsync(TodoItemDTO todoItem)
        {
            throw new NotImplementedException();
        }

        public bool update(TodoItemDTO todoItem)
        {
            TodoItemDTO todoItemToUpdate = db.Where(item => item.Id == todoItem.Id).Single();
            todoItemToUpdate.Name = todoItem.Name;
            todoItemToUpdate.IsComplete = todoItem.IsComplete;
            return true;
        }

        public Task<bool> updateAsync(TodoItemDTO todoItem)
        {
            throw new NotImplementedException();
        }

        public bool delete(long id)
        {
            return db.Remove(db.Where(item => item.Id == id).Single());
        }

        public Task<bool> deleteAsync(long id)
        {
            throw new NotImplementedException();
        }
        
    }
}
