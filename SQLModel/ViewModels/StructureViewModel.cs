using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class StructureViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class StructureListViewModel
    {
        public IEnumerable<Structure> StructureList { get; set; }
    }
}