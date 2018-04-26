using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation_WebAPI.Models
{
    public class TodoItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}