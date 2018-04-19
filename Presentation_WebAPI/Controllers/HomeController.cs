using Common;
using Presentation_WebAPI.Models;
using Presentation_WebAPI.TodoItemServiceReference;
using Presentation_WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation_WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoItemService todoItemServiceClient;

        public HomeController(ITodoItemService todoItemServiceClient)
        {
            this.todoItemServiceClient = todoItemServiceClient;
        }

        // GET: Item
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        // GET: Item/Details/5
        public ActionResult Details(long id)
        {
            TodoItemModel model = getTodoItemById(id);
            return PartialView("_Details", model);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        
        // GET: Item/Edit/5
        public ActionResult Edit(long id)
        {
            TodoItemModel model = getTodoItemById(id);
            return PartialView("_Edit", model);
        }
        
        // GET: Item/Delete/5
        public ActionResult Delete(long id)
        {
            TodoItemModel model = getTodoItemById(id);
            return PartialView("_Delete", model);
        }
        
        private TodoItemModel getTodoItemById(long id)
        {
            TodoItemDTO todoItemDTO = todoItemServiceClient.findById(id);
            if (todoItemDTO == null)
            {
                return null;
            }
            return MVCModelToDTOUtil.ToTodoItemModelMap(todoItemDTO);
        }
    }
}
