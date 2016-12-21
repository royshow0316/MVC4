using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class ProjectListViewModel
    {
        public IEnumerable<Project> ProjectList { get; set; }
    }
}