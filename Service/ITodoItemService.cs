using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITodoItemService" in both code and config file together.
    [ServiceContract]
    public interface ITodoItemService
    {
        [OperationContract]
        IList<TodoItemDTO> findAll();

        [OperationContract]
        ContainerDTO<TodoItemDTO> findAllPaged(int start, int length);

        [OperationContract]
        TodoItemDTO findById(long id);
        
        [OperationContract]
        Boolean create(TodoItemDTO todoItem);

        [OperationContract]
        Boolean update(TodoItemDTO todoItem);

        [OperationContract]
        Boolean delete(long id);
    }
}
