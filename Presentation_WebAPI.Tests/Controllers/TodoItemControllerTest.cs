using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation_WebAPI;
using Presentation_WebAPI.Controllers;
using Presentation_WebAPI.Tests.MockServices;
using Presentation_WebAPI.Models;
using System.Net;

namespace Presentation_WebAPI.Tests.Controllers
{
    [TestClass]
    public class TodoItemControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            TodoItemController controller = new TodoItemController(new MockTodoItemService());

            // Act
            controller.Post(new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            });
            IEnumerable<TodoItemModel> result = controller.Get();
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Test", result.ElementAt(0).Name);

            // Teardown
            controller.Delete(1);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            TodoItemController controller = new TodoItemController(new MockTodoItemService());

            // Act
            controller.Post(new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            });
            OkNegotiatedContentResult<TodoItemModel> result = controller.Get(1) as OkNegotiatedContentResult<TodoItemModel>;
            
            // Assert
            Assert.IsNotNull(result.Content);
            Assert.AreEqual("Test", result.Content.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            TodoItemController controller = new TodoItemController(new MockTodoItemService());

            // Act
            CreatedNegotiatedContentResult<TodoItemModel> result = controller.Post(new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            }) as CreatedNegotiatedContentResult<TodoItemModel>;

            // Assert
            Assert.IsNotNull(result.Content);
            Assert.AreEqual("Test", result.Content.Name);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            TodoItemController controller = new TodoItemController(new MockTodoItemService());

            // Act
            controller.Post(new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            });
            StatusCodeResult result = controller.Put(1, new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            }) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            TodoItemController controller = new TodoItemController(new MockTodoItemService());

            // Act
            controller.Post(new TodoItemModel()
            {
                Id = 1,
                IsComplete = false,
                Name = "Test"
            });
            StatusCodeResult result = controller.Delete(1) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
