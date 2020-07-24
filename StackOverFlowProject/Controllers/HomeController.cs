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
   //     ICategoryService cs;
        public HomeController(IQuestionService qs)
        {
            this.qs = qs;
           // this.cs = cs;
        }
        public ActionResult Index()
        {
          List<QuestionViewModel> questions =   this.qs.GetQuestions().Take(10).ToList();
            return View(questions);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Questions()
        {
            List<QuestionViewModel> qlist = this.qs.GetQuestions();
            return View(qlist);
        }
        //public ActionResult Categories()
        //{
        //    List<CategoriesViewModel> categories = this.cs.GetCategories();
        //    return View(categories);
        //}
    }
}