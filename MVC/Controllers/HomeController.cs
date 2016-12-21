using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.Interface;
using MVC.Models.Repository;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Project> projectRepository;

        public HomeController()
        {
            this.projectRepository = new GenericRepository<Project>();
        }

        public ActionResult Index()
        {
            var projects = projectRepository.GetAll();
            var viewModel = new ProjectListViewModel();
            viewModel.ProjectList = projects;

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new ProjectViewModel();
            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var viewModel = new ProjectViewModel();
            var model = projectRepository.GetById(x => x.Id == id);
            viewModel.Id = id;
            viewModel.Name = model.Name;

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == Guid.Empty)
                {
                    var model = new Project();
                    model.Id = Guid.NewGuid();
                    model.Name = viewModel.Name;
                    projectRepository.Create(model);
                }
                else
                {
                    var model = projectRepository.GetById(x => x.Id == viewModel.Id);
                    model.Name = viewModel.Name;
                    projectRepository.Update(model);
                }
                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
        }

        public ActionResult Delete(Guid id)
        {
            var model = projectRepository.GetById(x => x.Id == id);
            projectRepository.Delete(model);

            return RedirectToAction("Index");
        }
    }
}