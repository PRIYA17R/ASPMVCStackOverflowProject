using System.Web.Http;
using Unity;
using System.Web.Mvc;
using Unity.WebApi;
using Unity.Mvc5;
using StackOverflow.ServiceLayer;
using StackOverflowProject.ServiceLayer;

namespace StackOverFlowProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IQuestionService, QuestionService>();
			container.RegisterType<IUsersService, UsersService>();
            //container.RegisterType<ICategoryService, CategoryService>();
             DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
             GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
        }
    }
}