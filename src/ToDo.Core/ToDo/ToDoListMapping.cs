using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.ViewModels;
using ToDo.Domain.ToDo.Entities;

namespace ToDo.Core.Common.Mapping
{
    public class ToDoListMapping : Profile
    {
        public ToDoListMapping()
        {
            CreateMap<ToDoList, ToDoListVm>();
        }
    }
}
