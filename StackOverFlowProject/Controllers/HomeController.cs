using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stackOverflow.ViewModels;
using StackOverflow.ServiceLayer;

namespace StackOverFlowProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IQuestionService qs;
        public HomeController(IQuestionService qs)
        {
            this.qs = qs;
        }
        public ActionResult Index()
        {
          List<QuestionViewModel> questions =   this.qs.GetQuestions().Take(10).ToList();
            return View(questions);
        }
    }
}