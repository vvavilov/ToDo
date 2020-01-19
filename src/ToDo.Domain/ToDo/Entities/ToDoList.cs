using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Common;

namespace ToDo.Domain.ToDo.Entities
{
    public class ToDoList : BaseEntity
    {
        public string Title { get; set; } = "";
    }
}
