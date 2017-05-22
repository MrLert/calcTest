using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalcNew.Managers;
using WebCalcNew.Models;

namespace WebCalcNew.Controllers
{
    public class HomeController : Controller
    {
        private IOperationResultRepository OperationResultRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = new TableVIewModel();
            OperationResultRepository = new OperationManager();
            model.ViewList = OperationResultRepository.GetAll();
            
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}